# Rumble Photo Gallery

# OVERVIEW

This project aims to show basic usage of Xamarin and Xamarin Forms. The solution consists of two projects: a Portable Class Library (PCL) project, containing shared logic for all mobile platforms, as well as UI components in Xamarin Forms’ XAML implementation, and an Android project, utilising the PCL project. iOS and Windows Phone can easily be added to reuse the logic and UI components found in the PCL project. To modify this project, very little knowledge of Android is required. For further reading on Xamarin and Xamarin Forms:

1. [Xamarin](http://developer.xamarin.com/)

2. [Xamarin Forms](http://developer.xamarin.com/guides/xamarin-forms/)

# PCL Project Composition

The PCL project in the solution consists of the following classes:

1. A cross platform view, written in XAML, displaying photos retrieved from Flickr in a scrollable list.

2. A view model, which is bound to the view, and manages it.

3. A photo service, which is responsible for retrieving photos from an external service. The view model uses PhotoService to get the urls of the photos.

4. A Flickr photo service, which fetches photos from Flickr. PhotoService uses FlickrPhotoService internally, while setting some defaults, in case some values are not supplied by the service consumer.

# Goals

1. Currently, when running the project, the app displays a blank view, and then the list of images appear. No indication is given to the user that a network call is being made, although the view does contain an [ActivityIndicator](http://developer.xamarin.com/api/type/Xamarin.Forms.ActivityIndicator/). Find out why the activity indicator isn’t showing and fix the issue.

2. At the moment, the search for photos in Flickr is done by a keyword which is hard coded in the view model. Add a textbox and a search button to the UI, which will allow the users to search for photos using whatever keyword they want.

3. When scrolling the list of photos, you’ll notice that there is no indication to the user that images are being loaded, but instead, blank cells are displayed. Your task is to modify the image renderer behavior such that it will display a placeholder image, loaded from the device (rather than the network), until the real image is available for display. You can use the image "placeholder.png" found in the resources folder of the Android project. 
**Note**: do not use any additional image controls. Instead, create a [custom Image Renderer](https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/).

