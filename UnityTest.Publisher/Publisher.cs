namespace UnityTest.Publisher
{
	internal class Publisher
	{
		/// <summary>
		/// Send a message over the bus.
		/// </summary>
		public static void Publish()
		{
			BusDepot.Bus.Publish(new Messaging.MyMessage {Message = "hello from publisher"} );
		}
	}
}
