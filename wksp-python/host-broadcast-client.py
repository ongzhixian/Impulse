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

# Uncomment to log to file
file_logger = logging.FileHandler('bcast-clt.log')
file_logger.setFormatter(logging_format)
root_logger.addHandler(file_logger)


################################################################################
# Main function
################################################################################


def listen_broadcast(host_ip, host_port):
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    client_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    #client_socket.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
    client_socket.bind((host_ip, host_port))
    while 1:
        data_received = client_socket.recv(1024 * 64)
        logging.info("Data received [%s]" % data_received)


if __name__ == '__main__':
    logging.info("[PROGRAM START]")
    
    host_port = 5005
    host_ip = "0.0.0.0"

    listen_broadcast(host_ip, host_port)

    # logging.critical("%8s test message %s" % ("CRITICAL", str(datetime.utcnow())))
    # logging.error("%8s test message %s" % ("ERROR", str(datetime.utcnow())))
    # logging.warning("%8s test message %s" % ("WARNING", str(datetime.utcnow())))
    # logging.info("%8s test message %s" % ("INFO", str(datetime.utcnow())))
    # logging.debug("%8s test message %s" % ("DEBUG", str(datetime.utcnow())))
    # app.run(host='127.0.0.1', port=8080, debug=True)
