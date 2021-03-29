import logging
from datetime import datetime

def setup_logging(logging_level=logging.DEBUG, log_file_name='wksp-python.log'):
    logging_format = logging.Formatter('%(asctime)-15s %(levelname)-8s %(module)-12s %(funcName)-20s %(message)s')
    logging_format = logging.Formatter('%(asctime)-15s [%(levelname).3s] [%(module)s,%(funcName)-20s] %(message)s')
    root_logger = logging.getLogger()
    root_logger.setLevel(logging_level)
    
    # Setup file logging
    file_logger = logging.FileHandler(log_file_name)
    file_logger.setLevel(logging.DEBUG)
    file_logger.setFormatter(logging_format)
    root_logger.addHandler(file_logger)

    # Setup console logging
    default_console_logger = logging.StreamHandler()
    default_console_logger.setLevel(logging_level)
    default_console_logger.setFormatter(logging_format)
    root_logger.addHandler(default_console_logger)
    

def print_test_log_messages(ts=datetime.utcnow()):
    timestamp = str(ts)
    message_template = "%8s test message %s"
    logging.critical(   message_template % ("CRITICAL"  , timestamp))
    logging.error(      message_template % ("ERROR"     , timestamp))
    logging.warning(    message_template % ("WARNING"   , timestamp))
    logging.info(       message_template % ("INFO"      , timestamp))
    logging.debug(      message_template % ("DEBUG"     , timestamp))

def example_format(x):
    logging.info(f"Mean speed is [{x:^30}]")    # [      89.76923076923077       ]
    logging.info(f"Mean speed is [{x:*^30}]")   # [******89.76923076923077*******]
    logging.info(f"Mean speed is [{x:^.3}]")    # [89.8]
    logging.info(f"Mean speed is [{x:^30.3}]")  # [             89.8             ]
    logging.info(f"Mean speed is [{x:%}]")      # [8976.923077%]
    logging.info(f"Mean speed is [{x:f}]")      # [89.769231]
    logging.info(f"Mean speed is [{x:.2f}]")    # [89.77]
    logging.info(f"Mean speed is [{x:10.2f}]")  # [     89.77]
    logging.info(f"Mean speed is [{x:010.2f}]") # [0000089.77]
