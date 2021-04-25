import json
import logging
import os

def get_aws_credentials():

    profile_filepath = os.path.join(
        os.environ["USERPROFILE"],
        "Documents\PowerShell\wkspboto_dev.json"
    )

    with open(profile_filepath, "r") as aws_credential_file:
        return json.loads(aws_credential_file.read())

