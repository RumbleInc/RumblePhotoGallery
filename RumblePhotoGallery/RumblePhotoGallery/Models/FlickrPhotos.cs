using System.Collections.Generic;

using Newtonsoft.Json;

namespace RumblePhotoGallery.Models
{
    public class FlickrPhotos
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pages")]
        public int Pages { get; set; }

        [JsonProperty(PropertyName = "perpage")]
        public int PhotosPerPage { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string TotalPhotos { get; set; }

        [JsonProperty(PropertyName = "photo")]
        public List<FlickrPhoto> Photos { get; set; }
    }
}
