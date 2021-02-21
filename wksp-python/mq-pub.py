################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages
from modules.gcloud import get_topic_path, publish_to_topic, test_publish_to_topic, create_subscription, subscribe

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
    
    logging.info("[PROGRAM END]")
