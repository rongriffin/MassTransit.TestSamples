using System;
using MassTransit;


namespace UnityTest.Messaging
{
	/// <summary>
	/// A message to send over the bus.
	/// </summary>
	[Serializable]
	public class MyMessage : CorrelatedBy<Guid>
	{
		private readonly Guid _correlationId = Guid.NewGuid();

		public string Message { get; set; }

		Guid CorrelatedBy<Guid>.CorrelationId
		{
			get { return _correlationId; }
		}
	}
}
