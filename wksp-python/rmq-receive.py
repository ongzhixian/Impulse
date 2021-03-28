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

def callback(ch, method, properties, body):
    print(" [x] Received %r" % body)

if __name__ == '__main__':
    
    # setup_logging()
    setup_logging(logging_level=logging.DEBUG, log_file_name='rmq-recv.log')
    
    # Disable logging for pika
    logging.getLogger(pika.__name__).setLevel(logging.WARNING)

    logging.info("[PROGRAM START]")

    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()    

    channel.queue_declare(queue='hello')

    channel.basic_consume(
        queue='hello',
        auto_ack=True,
        on_message_callback=callback)

    print(' [*] Waiting for messages. To exit press CTRL+C')
    
    channel.start_consuming()
    
    logging.info("[PROGRAM END]")
