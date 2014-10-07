MassTransit.TestSamples
=======================

Experimenting with different ways to test MassTransit

## MockBusWithMoq ##

Mock IServiceBus.Publish in order to intercept published message for verification.

## MockBusWithFakes ##

Shim the bus instance with a mock implementation of IServiceBus in order to inspect the published message for testing without publishing to the real bus.

## TestSubscriberWithLoopback ##

Shim the bus instance with a simple instance that uses the loopback protocol.  Attach a test subscriber to consume the message.  Use simple polling to verify that the message was consumed.

## TestSubscriberWithRabbitMQ ##

Subscribe to the configured RabbitMQ cluster.  Attach a test subscriber to consume the message.  Use simple polling to verify that the message was consumed.