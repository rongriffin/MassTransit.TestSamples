using MassTransit;
using MassTransit.TestSamples.Messaging;

namespace MassTransit.TestSamples.Tests
{

	/// <summary>
	/// This is a test subscriber that grabs a published MyMessage and makes it available 
	/// for inspection.
	/// </summary>
	public class TestSubscriber : Consumes<MyMessage>.All
	{
		public bool MessageRecieved { get; set; }
		public MyMessage TheMessage { get; set; }

		public void Consume(MyMessage message)
		{
			MessageRecieved = true;
			TheMessage = message;
		}
	}
}
