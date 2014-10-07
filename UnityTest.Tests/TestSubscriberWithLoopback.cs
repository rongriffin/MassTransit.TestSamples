using System.Threading;
using MassTransit;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityTest.Publisher;

namespace UnityTest.Tests
{
	/// <summary>
	/// This example replaces the Bus instance with a new bus that uses the loopback protocol
	/// </summary>
	[TestClass]
	public class TestSubscriberWithLoopback
	{

		private IServiceBus _testLoopbackBus;

		/// <summary>
		/// Init the fake bus
		/// </summary>
		[TestInitialize]
		public void Init()
		{
			_testLoopbackBus = ServiceBusFactory.New(sbc => sbc.ReceiveFrom("loopback://localhost/queue"));
		}

		/// <summary>
		/// Replace the real bus with a new one using the loopback protocol to grab the message.
		/// </summary>
		[TestMethod]
		public void VerifyPublishedMessageWithLoopback()
		{
			const int waitSeconds = 60;
			var subscriber = new TestSubscriber();

			using (ShimsContext.Create())
			{
				// Replace the bus instance with our loopback version
				Publisher.Fakes.ShimBusDepot.BusGet =
					() => _testLoopbackBus;

				// Subscribe our instance of the TestSubscriber
				BusDepot.Bus.SubscribeConsumer(() => subscriber);

				Publisher.Publisher.Publish(); 
				var second = 0;
				//Crappy polling...
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
}
