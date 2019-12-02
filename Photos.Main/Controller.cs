using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Main
{
	public class Controller
	{
		//TODO:  Find a better place for the url of the api.
		readonly string site = @"https://jsonplaceholder.typicode.com/";


		public async Task<List<Photo>> GetPhotosAsync(string queryString)
		{
			var photoList = new List<Photo>();

			using (var client = new HttpClient())
			{

				HttpResponseMessage response = await client.GetAsync(site + queryString);

				using (HttpContent content = response.Content)
				{
					string responseBody = await response.Content.ReadAsStringAsync();

					photoList = JsonConvert.DeserializeObject<List<Photo>>(responseBody);
				}
			}
			return photoList;
		}


		public async Task<string> GetPhotoInformationAsync(string queryString)
		{
			string outputResult = "\n";

			var photoList = new List<Photo>();

			photoList = await GetPhotosAsync(queryString);

			foreach (var photo in photoList)
			{
				outputResult += $"[{photo.Id}] {photo.Title}\n\n";
			}

			return outputResult;
		}

	}
}
