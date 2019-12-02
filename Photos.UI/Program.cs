using Photos.Main;
using System;


namespace Photos.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			string strInput = null;
			while (true)
			{
				Console.WriteLine(" ");
				Console.WriteLine("1 - Display information from a specific album");
				Console.WriteLine("2 - Display information from a specific photo");
				Console.WriteLine("3 - Display all photo ids and titles (not recommended)");
				Console.WriteLine("q - Quit");
				Console.Write("Enter an option number or q to quit:  ");
				Console.Out.Flush();

				strInput = Console.ReadLine();

				//TODO:  Add methods to query min and max id numbers 
				//			of albums and photos.
				//			Replace hard-coded values below with variables.

				switch (strInput)
				{
					case "1":
						Console.Write("Enter an album id (1 thru 100):  ");
						Console.Out.Flush();
						strInput = Console.ReadLine();
						strInput = $"photos?albumId={strInput}";
						ShowPhotoInformation(strInput);
						break;
					case "2":
						Console.Write("Enter a photo id (1 thru 5000):  ");
						Console.Out.Flush();
						strInput = Console.ReadLine();
						strInput = $"photos?id={strInput}";
						ShowPhotoInformation(strInput);
						break;
					case "3":
						strInput = "photos";
						ShowPhotoInformation(strInput);
						break;
					case "q":
						return;
					default:
						Console.WriteLine("Option not recognized.");
						break;
				}

			}
		}


		private static async void ShowPhotoInformation(string queryString)
		{
			var controller = new Controller();
			string output = await controller.GetPhotoInformationAsync(queryString);
			Console.WriteLine(output);
		}



	}
}
