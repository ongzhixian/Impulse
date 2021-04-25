import boto3
import logging

from aws_helper import get_aws_credentials

def do_work(credentials):
    polly = boto3.client(
        'polly',
        region_name=credentials['regionName'],
        aws_access_key_id=credentials['accessKeyID'],
        aws_secret_access_key=credentials['secretAccessKey']
    )
    
    result = polly.synthesize_speech(
        Text='Hello World!',
        OutputFormat='mp3',
        VoiceId='Aditi')
    
    # Save the Audio from the response
    audio = result['AudioStream'].read()
    with open("helloworld2.mp3","wb") as file:
        file.write(audio)
        print("File created.")


if __name__ == '__main__':
    aws_credentials = get_aws_credentials()
    do_work(aws_credentials)
