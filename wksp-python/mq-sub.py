################################################################################
# Modules and functions import statements
################################################################################

import logging
#from helpers.app_logging import setup_logging, print_test_log_messages
#from modules.gcloud import get_topic_path, publish_to_topic, test_publish_to_topic, create_subscription, subscribe

import os

# from modules import *
# from api import *
# from pages import *
# from os import getenv

################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    
    setup_logging()
    logging.info("[PROGRAM START]")
    
    # Test publish
    #test_publish_to_topic()
    import pika, os

    # Access the CLODUAMQP_URL environment variable and parse it (fallback to localhost)
    url = os.environ.get('CLOUDAMQP_URL', 'amqp://guest:guest@localhost:5672/%2f')
    params = pika.URLParameters(url)
    connection = pika.BlockingConnection(params)
    channel = connection.channel() # start a channel
    channel.queue_declare(queue='hello') # Declare a queue
    def callback(ch, method, properties, body):
    print(" [x] Received " + str(body))

    channel.basic_consume('hello',
                        callback,
                        auto_ack=True)

    print(' [*] Waiting for messages:')
    channel.start_consuming()
    connection.close()
    
    logging.info("[PROGRAM END]")
