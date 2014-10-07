using System;

namespace MassTransit.TestSamples.Publisher
{
	/// <summary>
	/// Just a demo program that publishes forever
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("Press Enter to publish...");
				Console.ReadLine();
				Publisher.Publish();
			}

		}
	}
}
