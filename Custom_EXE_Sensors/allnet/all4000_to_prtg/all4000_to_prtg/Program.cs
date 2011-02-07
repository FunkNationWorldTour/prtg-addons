
/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Marc Fuhrmeister
 * Datum: 13.02.2010
 * Zeit: 19:08
 * 
 */
using System;
using System.Net;

namespace all4000_to_prtg
{
	class Program
	{		
		public static void Main(string[] args)
		{
			ALL4000Reader allreader = new ALL4000Reader(args);
		}
	}
}