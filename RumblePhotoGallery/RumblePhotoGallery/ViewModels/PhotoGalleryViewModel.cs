using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using RumblePhotoGallery.Services;

namespace RumblePhotoGallery.ViewModels
{
    public class PhotoGalleryViewModel : INotifyPropertyChanged
    {
        private readonly PhotoService _photoService = new PhotoService();
        private List<string> _photos;

        public async Task Init()
        {
            Photos = await _photoService.GetPhotos("animals");
        }

        public List<string> Photos
        {
            get
            {
                return _photos;
            }

            set
            {
                _photos = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
