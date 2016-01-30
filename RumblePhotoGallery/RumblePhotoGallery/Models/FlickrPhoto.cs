using Newtonsoft.Json;

namespace RumblePhotoGallery.Models
{
    public class FlickrPhoto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }

        [JsonProperty(PropertyName = "farm")]
        public string Farm { get; set; }

        [JsonProperty(PropertyName = "originalsecret")]
        public string OriginalSecret { get; set; }

        [JsonProperty(PropertyName = "originalformat")]
        public string OriginalFormat { get; set; }
    }
}