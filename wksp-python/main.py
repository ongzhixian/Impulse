################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages
from modules.gcloud import get_topic_path, publish_to_topic, test_publish_to_topic, create_subscription
# from modules import *
# from api import *
# from pages import *
# from os import getenv

################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    setup_logging()
    print_test_log_messages()
    logging.info("[PROGRAM START]")

    project_id = "hci-admin"
    topic_id = "tax-refund-transaction"
    subscription_id = "test_sub_id"

    #delete_topic(project_id, topic_id)
    
    #test_publish_to_topic()
    
    create_subscription(project_id, topic_id, subscription_id)
    
    
    logging.info("[PROGRAM END]")
    #app.run(host='127.0.0.1', port=8080, debug=True)

