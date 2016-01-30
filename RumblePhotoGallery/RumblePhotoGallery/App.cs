using RumblePhotoGallery.ViewModels;
using RumblePhotoGallery.Views;

using Xamarin.Forms;

namespace RumblePhotoGallery
{
    public class App : Application
    {
        public App()
        {
            PhotoGalleryPage photoGalleryPage = new PhotoGalleryPage();
            MainPage = photoGalleryPage;
            CreateMainPageViewModel();
        }

        private async void CreateMainPageViewModel()
        {
            PhotoGalleryViewModel photoGalleryViewModel = new PhotoGalleryViewModel();
            await photoGalleryViewModel.Init();
            MainPage.BindingContext = photoGalleryViewModel;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
