using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using ModernHttpClient;

using Newtonsoft.Json;

using RumblePhotoGallery.Enums;
using RumblePhotoGallery.Models;

namespace RumblePhotoGallery.Services
{
    public class FlickrPhotoService
    {
        private const string FLICKR_API_BASE_URL = "api.flickr.com/services/rest/";
        private const string FLICKR_API_KEY = "03a55c360e541645802218a861602c44";
        private const string FLICKR_SEARCH_METHOD = "flickr.photos.search";
        private const string FLICKR_RESPONSE_FORMAT = "json";
        
        public async Task<List<string>> GetPhotosByKeyword(string keyword, PhotoSize photoSize, int resultsPerPage, int pageNumber)
        {
            List<string> photosUrls = new List<string>();

            string imageSearchUrl = $"https://{FLICKR_API_BASE_URL}?method={FLICKR_SEARCH_METHOD}&api_key={FLICKR_API_KEY}&per_page={resultsPerPage}&page={pageNumber}&tags={keyword}&format={FLICKR_RESPONSE_FORMAT}";

            string responseString;

            using (HttpClient httpClient = GetHttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync(imageSearchUrl);
                responseString = await response.Content.ReadAsStringAsync();
            }

            if (string.IsNullOrEmpty(responseString))
            {
                return photosUrls;
            }

            var startJson = responseString.IndexOf('{');
            var endJson = responseString.LastIndexOf('}');
            var jsonString = responseString.Substring(startJson, endJson - startJson + 1);

            FlickrReturnObject flickrReturnObject = JsonConvert.DeserializeObject<FlickrReturnObject>(jsonString);

            foreach (FlickrPhoto flickrPhoto in flickrReturnObject.FlickrPhotos.Photos)
            {
                string photoSizeSuffix = string.Empty;

                switch (photoSize)
                {
                    case PhotoSize.Small:
                        photoSizeSuffix = "n";
                        break;
                    case PhotoSize.Medium:
                        photoSizeSuffix = "c";
                        break;
                    case PhotoSize.Large:
                        photoSizeSuffix = "b";
                        break;
                    case PhotoSize.ExtraLarge:
                        photoSizeSuffix = "h";
                        break;
                    case PhotoSize.ExtraExtraLarge:
                        photoSizeSuffix = "k";
                        break;
                }

                string photoUrl = $"https://farm{flickrPhoto.Farm}.staticflickr.com/{flickrPhoto.Server}/{flickrPhoto.Id}_{flickrPhoto.Secret}_{photoSizeSuffix}.jpg";

                photosUrls.Add(photoUrl);
            }

            return photosUrls;
        }

        private HttpClient GetHttpClient()
        {
            return new HttpClient(new NativeMessageHandler());
        }
    }
}
