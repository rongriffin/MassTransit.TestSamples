using System.Configuration;
using MassTransit;

namespace UnityTest.Publisher
{
	internal static class BusDepot
	{
		private static IServiceBus _bus;

		/// <summary>
		/// Return an instance of the bus.
		/// </summary>
		public static IServiceBus Bus
		{
			get
			{
				return _bus ?? (_bus = ServiceBusFactory.New(sbc =>
						{
							sbc.UseRabbitMq();
							sbc.ReceiveFrom(ConfigurationManager.AppSettings["EndpointAddress"]);
						}
					));

			}
		}

	}
}
