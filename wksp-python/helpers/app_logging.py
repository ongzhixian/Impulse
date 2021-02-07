import logging
from datetime import datetime

def setup_logging(logging_level=logging.DEBUG, log_file_name='wksp-python.log'):
    logging_format = logging.Formatter('%(asctime)-15s %(levelname)-8s %(funcName)-20s %(message)s')
    root_logger = logging.getLogger()
    root_logger.setLevel(logging_level)
    # Setup console logging
    default_console_logger = logging.StreamHandler()
    default_console_logger.setFormatter(logging_format)
    root_logger.addHandler(default_console_logger)
    # Setup file logging
    file_logger = logging.FileHandler(log_file_name)
    file_logger.setFormatter(logging_format)
    root_logger.addHandler(file_logger)

def print_test_log_messages(ts=datetime.utcnow()):
    timestamp = str(ts)
    message_template = "%8s test message %s"
    logging.critical(   message_template % ("CRITICAL"  , timestamp))
    logging.error(      message_template % ("ERROR"     , timestamp))
    logging.warning(    message_template % ("WARNING"   , timestamp))
    logging.info(       message_template % ("INFO"      , timestamp))
    logging.debug(      message_template % ("DEBUG"     , timestamp))
