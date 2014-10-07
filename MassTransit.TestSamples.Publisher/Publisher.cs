using MassTransit.TestSamples.Messaging;

namespace MassTransit.TestSamples.Publisher
{
	internal class Publisher
	{
		/// <summary>
		/// Send a message over the bus.
		/// </summary>
		public static void Publish()
		{
			BusDepot.Bus.Publish(new MyMessage {Message = "hello from publisher"} );
		}
	}
}
