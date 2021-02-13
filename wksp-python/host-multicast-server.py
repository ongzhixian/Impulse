import logging
import socket
import signal
import struct
import time


################################################################################
# Set logging levels
################################################################################
# Setup for logging in non-AppEngine environments
# logging_format = logging.Formatter('%(asctime)-15s %(levelname)-8s %(name)-5s %(message)s')
logging_format = logging.Formatter('%(asctime)-15s %(levelname)-8s %(funcName)-20s %(message)s')

logging.basicConfig() # Need this; otherwise getLogger will not have handlers
root_logger = logging.getLogger()
root_logger.setLevel(logging.DEBUG)

# ZX: Not sure why different platforms (or maybe its Python version related)
# if not root_logger.hasHandlers():
#     root_logger.addHandler(logging.StreamHandler())

default_console_logger = root_logger.handlers[0]
default_console_logger.setFormatter(logging_format)

# Uncomment to log to file (Comment out for GCP)
file_logger = logging.FileHandler('mcast-svr.log')
file_logger.setFormatter(logging_format)
root_logger.addHandler(file_logger)


################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    # Note: This is used when running locally only. 
    # When deploying to Google App Engine, a webserver process such as Gunicorn will serve the app. 
    # This can be configured by adding an `entrypoint` to app.yaml (to run under uwsgi).

    # Flask's development server will automatically serve static files in the "static" directory. See:
    # http://flask.pocoo.org/docs/1.0/quickstart/#static-files.
    # Once deployed, App Engine itself will serve those files as configured in app.yaml.
    # from modules import app_version
    # app_version.incr_revision()

    logging.info("[PROGRAM START]")
    
    host_port = 4567
    host_ip = "224.5.6.7"

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    server_socket.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_TTL, 32)

    num = 0
    while (True):
        message = "Message {0}".format(num)
        num = num + 1
        server_socket.sendto(message.encode("UTF8"), (host_ip, host_port))
        print(message)
        time.sleep(1)

    #from datetime import datetime

    

    # logging.critical("%8s test message %s" % ("CRITICAL", str(datetime.utcnow())))
    # logging.error("%8s test message %s" % ("ERROR", str(datetime.utcnow())))
    # logging.warning("%8s test message %s" % ("WARNING", str(datetime.utcnow())))
    # logging.info("%8s test message %s" % ("INFO", str(datetime.utcnow())))
    # logging.debug("%8s test message %s" % ("DEBUG", str(datetime.utcnow())))
    # app.run(host='127.0.0.1', port=8080, debug=True)
