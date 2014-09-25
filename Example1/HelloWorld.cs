using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
	class HelloWorld
	{
		static void Main(string[] args)
		{
			WriteGreeting(args[0]);
		}

		public static string Greeting
		{
			get { return "Hello, "; }
			set { }
		}

		public static void WriteGreeting(string name)
		{
			Console.Write(Greeting);
			Console.Write(name);
			Console.ReadKey();

		}
	}
}
