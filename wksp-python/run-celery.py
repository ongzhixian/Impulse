################################################################################
# Modules and functions import statements
################################################################################

import logging as log

from helpers.app_logging import setup_logging, print_test_log_messages

from celery_tasks import add

################################################################################
# Main function
################################################################################


if __name__ == '__main__':
    setup_logging()
    log.info("[PROGRAM START]")

    # add.delay(3, 5)
    #add(1, 2)


    # import json
    # with open('app-settings.json') as f:
    #     app_settings = json.load(f)
    a = add.delay(3, 5)

    log.info("[PROGRAM END]")