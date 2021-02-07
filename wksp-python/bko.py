################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages
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
    logging.info("[PROGRAM END]")
    #app.run(host='127.0.0.1', port=8080, debug=True)
