using Photos.Main;
using System;
using System.Collections.Generic;
using Xunit;


namespace Photos.Test
{

	public class PhotoInformationShould
	{

		[Fact]
		public async void RetrievePhotoId()
		{
			Controller sut = new Controller();

			List<Photo> photos = await sut.GetPhotosAsync("photos?id=1");

			Assert.Equal(1, photos[0].Id);
		}


		[Fact]
		public async void RetrieveAlbumId()
		{
			Controller sut = new Controller();

			List<Photo> photos = await sut.GetPhotosAsync("photos?albumId=1");

			Assert.Equal(1, photos[0].AlbumId);
		}


		[Fact]
		public async void BeEmptyWithBadPhotoId()
		{
			Controller sut = new Controller();

			List<Photo> photos = await sut.GetPhotosAsync("photos?id=0");

			Assert.Empty(photos);
		}


		[Fact]
		public async void BeEmptyWithBadAlbumId()
		{
			Controller sut = new Controller();

			List<Photo> photos = await sut.GetPhotosAsync("photos?albumId=0");

			Assert.Empty(photos);
		}


		[Fact]
		public async void StartsWithPhotoId()
		{
			Controller sut = new Controller();

			string result = await sut.GetPhotoInformationAsync("photos?id=42");

			Assert.StartsWith("\n[42]", result);
		}


		[Fact]
		public async void StartsWithAlbumId()
		{
			Controller sut = new Controller();

			string result = await sut.GetPhotoInformationAsync("photos?albumId=2");

			Assert.StartsWith("\n[51]", result);
		}


		[Fact]
		public async void RetrieveAllPhotos()
		{
			Controller sut = new Controller();

			List<Photo> photos = await sut.GetPhotosAsync("photos");

			Assert.Equal(5000, photos.Count);
		}


	}
}
