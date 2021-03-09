# 
################################################################################
# Modules and functions import statements
################################################################################

#import json
import logging as log

from datetime import datetime
from time import time

# from flask import request, make_response, abort

from helpers.app_runtime import app

#from modules.security import make_keys

################################################################################
# Setup routes
# /api/datetime     -- Get server UTC datetime
# /api/epochtime    -- Get server epoch time 
# /api/test         -- Function to 
################################################################################

@app.route('/api/datetime', methods=['GET', 'POST'])
def api_datetime():
    log.info("Execute")
    result = str(datetime.utcnow())
    log.info(f"Result: {result}")
    return result


@app.route('/api/epochtime', methods=['GET', 'POST'])
def api_epochtime():
    log.info("Execute")
    result = str(int(time()))
    log.info(f"Result: {result}")
    return result


# @app.route('/api/echo', methods=['GET'])
# def api_echo(errorMessages=None):

#     logging.info("In api_echo()")

#     if "msg" in request.args:
#         return "re:{0}".format(request.args["msg"])
#     abort(400)

# @app.route('/api/make_keys', methods=['GET'])
# def api_make_keys(errorMessages=None):

#     logging.info("In api_make_keys()")

#     keys = make_keys("aes", 32, 16)

#     return json.dumps(keys)