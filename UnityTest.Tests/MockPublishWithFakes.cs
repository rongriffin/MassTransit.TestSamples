
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnityTest.Tests
{
	/// <summary>
	/// This example mocks the bus' publish method using a test version of IServiceBus
	/// </summary>
	[TestClass]
	public class MockPublishWithFakes
	{

		/// <summary>
		/// Fake the bus creation with the MockServiceBus to control the Publish method.
		/// </summary>
		[TestMethod]
		public void InspectMessageWithFakes()
		{
			var mockBus = new MockServiceBus();
			var busCreation = false;
			using (ShimsContext.Create())
			{
				//Use our version if IServiceBus....
				Publisher.Fakes.ShimBusDepot.BusGet =
					() =>
					{
						busCreation = true;
						return mockBus;
					};

				Publisher.Publisher.Publish();

				Assert.IsNotNull(mockBus);				
				Assert.IsNotNull(mockBus.PublishedMessage);
				Assert.IsTrue(busCreation);  //Don't forget to verify that the fake was called.

			}
		}
	}
}
