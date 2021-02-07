import logging
from time import sleep
from google.cloud import pubsub_v1

publisher = pubsub_v1.PublisherClient()
subscriber = pubsub_v1.SubscriberClient()


def subscribe(project_id, subscription_id, callback_function):
    timeout = 5.0
    subscription_path = get_subscription_path(project_id, subscription_id)
    streaming_pull_future = subscriber.subscribe(subscription_path, callback=callback_function)
    with subscriber:
        try:
            # When `timeout` is not set, result() will block indefinitely,
            # unless an exception is encountered first.
            #streaming_pull_future.result(timeout=timeout)
            streaming_pull_future.result()
        except TimeoutError:
            streaming_pull_future.cancel()
        return streaming_pull_future


def create_subscription(project_id, topic_id, subscription_id):
    topic_path = get_topic_path(project_id, topic_id)
    subscription_path = get_subscription_path(project_id, subscription_id)
    # Wrap the subscriber in a 'with' block to automatically call close() to
    # close the underlying gRPC channel when done.
    with subscriber:
        subscription = subscriber.create_subscription(
            request={"name": subscription_path, "topic": topic_path}
        )
    logging.info(f"Subscription created: {subscription}")

def create_topic(project_id, topic_id):
    topic_path = get_topic_path(project_id, topic_id)
    topic = publisher.create_topic(request={"name": topic_path})
    logging.info("Created topic: {}".format(topic.name))
    return topic

def delete_topic(project_id, topic_id):
    topic_path = get_topic_path(project_id, topic_id)
    publisher.delete_topic(request={"topic": topic_path})
    logging.info("Topic deleted: {}".format(topic_path))

def get_subscription_path(project_id, subscription_id):
    subscription_path = subscriber.subscription_path(project_id, subscription_id)
    return subscription_path

def get_topic_path(project_id, topic_id):
    topic_path = publisher.topic_path(project_id, topic_id)
    return topic_path

def publish_to_topic(topic_path, data):
    data = data.encode("utf-8")
    future = publisher.publish(topic_path, data)
    logging.info(future.result())
    #print(future.result())


def test_create_delete_topic():
    project_id = "hci-admin"
    topic_id = "test-tax-refund-transaction"
    create_topic(project_id, topic_id)
    delete_topic(project_id, topic_id)

def test_publish_to_topic():
    project_id = "hci-admin"
    topic_id = "tax-refund-transaction"

    topic_path = get_topic_path(project_id, topic_id)
    for n in range(1, 10):
        data = "Message number {}".format(n)
        publish_to_topic(topic_path, data)
        sleep(1.67) # Sleep for 1.67 secpmds
    logging.info(f"Published messages to {topic_path}.")
