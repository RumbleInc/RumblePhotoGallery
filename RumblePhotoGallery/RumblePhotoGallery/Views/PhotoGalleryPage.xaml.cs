using Xamarin.Forms;

namespace RumblePhotoGallery.Views
{
    public partial class PhotoGalleryPage : ContentPage
    {
        public PhotoGalleryPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
