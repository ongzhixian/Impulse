################################################################################
# Define package composition
################################################################################

#__all__ = ["site", "user"]

# ZX: There's a better way to do this; see other source code from elsewhere


import logging as log
from flask import render_template


@app.route('/')
def webroot_get():
    log.info("Step=1")
    # view_model = get_model()
    # return view(view_model)
    return render_template('root_get.html')