using System.Configuration;
using System.Threading;
using MassTransit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnityTest.Tests
{
	/// <summary>
	/// This example attaches a rabbitmq subscriber to a tested process in order
	/// to inspect received messages.
	/// </summary>
	[TestClass]
	public class TestSubscriberWithRabbitMq
	{

		private IServiceBus _testRabbitMqBus;

		/// <summary>
		/// Init the bus used by the subscriber
		/// </summary>
		[TestInitialize]
		public void Init()
		{
			//WARNING : Test queues will persist unless you delete them manuall or via RabbitMQ policies.
			_testRabbitMqBus = ServiceBusFactory.New(sbc =>
			{
				sbc.UseRabbitMq();
				sbc.ReceiveFrom(ConfigurationManager.AppSettings["SubscriberEndpointAddress"]);
			});
		}

		/// <summary>
		/// Attach our subscriber to the rabbitMq cluster to inspect received messages.
		/// </summary>
		[TestMethod]
		public void VerifyPublishedMessageWithRabbitMq()
		{
			const int waitSeconds = 60;
			var subscriber = new TestSubscriber();

			//Attach our test subscriber to the bus.
			_testRabbitMqBus.SubscribeConsumer(() => subscriber);

			Publisher.Publisher.Publish();
			var second = 0;
			//Crappy Polling...
			while (second < waitSeconds)
			{
				if (subscriber.MessageRecieved)
				{
					break;
				}
				Thread.Sleep(1000);
				second++;
			}

			Assert.IsTrue(subscriber.MessageRecieved);
			Assert.IsNotNull(subscriber.TheMessage);
			// TODO:  Some other validation
			Assert.IsNotNull(subscriber.TheMessage.Message.StartsWith("hello"));

		}
	}
}
