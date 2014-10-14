using MassTransit;
using MassTransit.TestSamples.Messaging;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MassTransit.TestSamples.Tests
{
	/// <summary>
	/// This example uses Moq to intercept the Bus's Publish method
	/// </summary>
	[TestClass]
	public class MockBusWithMoq
	{
		/// <summary>
		/// Intercept Publish with Moq in order to inspect the published message.
		/// </summary>
		[TestMethod]
		public void InspectPublishedMessageWithMoq()
		{
			var mockBus = new Mock<IServiceBus>();
			string message = null;
			//Intercept the publish method and grab the message for inspection
			mockBus.Setup(b => b.Publish(It.IsAny<MyMessage>()))
				.Callback<MyMessage>(m => message = m.Message).Verifiable();
			
			//Still using shims for the BusDepot since there is no virtual or interface.
			//I'm not a fan of changing class design to make Moq easier.
			using (ShimsContext.Create())
			{
				// Replace the bus with the mocked version.
				Publisher.Fakes.ShimBusDepot.BusGet =
					() => mockBus.Object;

				Publisher.Publisher.Publish();
				mockBus.Verify(b => b.Publish(It.IsAny<MyMessage>())); //Make sure the mock was called.
				Assert.IsNotNull(message);
			}

		}
	}
}
