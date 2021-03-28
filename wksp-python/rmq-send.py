################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages

# from modules import *
# from api import *
# from pages import *
# from os import getenv

import pika

################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    
    # setup_logging()
    setup_logging(logging_level=logging.DEBUG, log_file_name='rmq-send.log')
    
    # Disable logging for pika
    logging.getLogger(pika.__name__).setLevel(logging.WARNING)

    logging.info("[PROGRAM START]")

    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()    

    channel.queue_declare(queue='hello')
    
    channel.basic_publish(
        exchange='',
        routing_key='hello',
        body='Hello World!')

    print(" [x] Sent 'Hello World!'")
    connection.close()
    
    logging.info("[PROGRAM END]")
