

using MassTransit;

namespace MassTransit.TestSamples.Tests
{
	// A mock mass transit service bus for testing.
	class MockServiceBus : IServiceBus
	{
		public object PublishedMessage { get; set; }

		public UnsubscribeAction Configure(System.Func<MassTransit.Pipeline.IInboundPipelineConfigurator, UnsubscribeAction> configure)
		{
			throw new System.NotImplementedException();
		}

		public IServiceBus ControlBus
		{
			get { throw new System.NotImplementedException(); }
		}

		public IEndpoint Endpoint
		{
			get { throw new System.NotImplementedException(); }
		}

		public IEndpointCache EndpointCache
		{
			get { throw new System.NotImplementedException(); }
		}

		public IEndpoint GetEndpoint(System.Uri address)
		{
			throw new System.NotImplementedException();
		}

		public IBusService GetService(System.Type type)
		{
			throw new System.NotImplementedException();
		}

		public MassTransit.Pipeline.IInboundMessagePipeline InboundPipeline
		{
			get { throw new System.NotImplementedException(); }
		}

		public MassTransit.Pipeline.IOutboundMessagePipeline OutboundPipeline
		{
			get { throw new System.NotImplementedException(); }
		}

		public void Publish<T>(object values, System.Action<IPublishContext<T>> contextCallback) where T : class
		{
			throw new System.NotImplementedException();
		}

		public void Publish<T>(object values) where T : class
		{
			throw new System.NotImplementedException();
		}

		public void Publish(object message, System.Type messageType, System.Action<IPublishContext> contextCallback)
		{
			PublishedMessage = message;
		}

		public void Publish(object message, System.Action<IPublishContext> contextCallback)
		{
			PublishedMessage = message;
		}

		public void Publish(object message, System.Type messageType)
		{
			PublishedMessage = message;
		}

		/// <summary>
		/// Just store the message for later retrieval.
		/// </summary>
		/// <param name="message">The message to fake publish</param>
		public void Publish(object message)
		{
			PublishedMessage = message;
		}

		public void Publish<T>(T message, System.Action<IPublishContext<T>> contextCallback) where T : class
		{
			PublishedMessage = message;
		}

		public void Publish<T>(T message) where T : class
		{
			PublishedMessage = message;
		}

		public System.TimeSpan ShutdownTimeout
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		public bool TryGetService(System.Type type, out IBusService result)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public void Inspect(MassTransit.Diagnostics.Introspection.DiagnosticsProbe probe)
		{
			throw new System.NotImplementedException();
		}
	}
}
