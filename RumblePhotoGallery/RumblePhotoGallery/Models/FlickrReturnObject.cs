using Newtonsoft.Json;

namespace RumblePhotoGallery.Models
{
    public class FlickrReturnObject
    {
        [JsonProperty(PropertyName = "photos")]
        public FlickrPhotos FlickrPhotos { get; set; }

        [JsonProperty(PropertyName = "stat")]
        public string  Status { get; set; }
    }
}
