################################################################################
# Modules and functions import statements
################################################################################

import logging as log

from helpers.app_logging import setup_logging, print_test_log_messages

from celery import Celery

################################################################################
# Main function
################################################################################

# app = Celery('tasks', backend='rpc://', broker='pyamqp://')               # use the rpc result backend, that sends states back as transient messages. 
# app = Celery('tasks', backend='redis://localhost', broker='pyamqp://')    # use Redis as the result backend, but still use RabbitMQ as the message broker

# in-memory broker is for testing for (it cannot be put to practical use)
#app = Celery('tasks', broker="memory://", backend='file://D:/src/github.com/ongzhixian/impulse/code/wksp-python/data/broker/results')

app = Celery('tasks', backend='file://D:/src/github.com/ongzhixian/impulse/code/wksp-python/data/broker/results')
app.conf.update({
    'broker_url': 'filesystem://',
    'broker_transport_options': {
        'data_folder_in'        : 'D:/src/github.com/ongzhixian/impulse/code/wksp-python/data/broker/queue',
        'data_folder_out'       : 'D:/src/github.com/ongzhixian/impulse/code/wksp-python/data/broker/queue',
        'data_folder_processed' : 'D:/src/github.com/ongzhixian/impulse/code/wksp-python/data/broker/processed'
    }
})

########################################
# Task definitions
########################################

@app.task
def add(x, y):
    return x + y


########################################
# Main script
########################################

if __name__ == '__main__':
    setup_logging()
    log.info("[PROGRAM START]")

    # TODO: Test tasks here

    log.info("[PROGRAM END]")