using System.Collections.Generic;
using System.Threading.Tasks;

using RumblePhotoGallery.Enums;

namespace RumblePhotoGallery.Services
{
    public class PhotoService
    {
        private readonly FlickrPhotoService _flickrPhotoService = new FlickrPhotoService();

        public async Task<List<string>> GetPhotos(string keyword, PhotoSize photoSize = PhotoSize.Large, int resultsPerPage = 200, int pageNumber = 1)
        {
            List<string> photoUrls = await _flickrPhotoService.GetPhotosByKeyword(keyword, photoSize, resultsPerPage, pageNumber);

            return photoUrls;
        }
    }
}
