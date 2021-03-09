################################################################################
# Modules and functions import statements
################################################################################

import logging as log

# import numpy
# from scipy import stats
# import matplotlib.pyplot as plt

from web_pages import *
from web_api import *
from helpers.app_runtime import app
from helpers.app_logging import setup_logging, print_test_log_messages


################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    setup_logging()
    log.info("[PROGRAM START]")
    app.run(host='127.0.0.1', port=8080, debug=True)
    log.info("[PROGRAM END]")