using System;
using Windows.ApplicationModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace launchYoutubeInApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       public static string url = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            url = (string)e.Parameter;

           
            
        }

        private async void launchButton_Click(object sender, RoutedEventArgs e)
        {
          
            //Testing 
            //string videoID = getVideoIDFromUrl("https://www.youtube.com/watch?v=9bDEQJ2w4KA");


            string videoID = getVideoIDFromUrl(url);
            await Launcher.LaunchUriAsync(new Uri($"rykentube:Video?ID={videoID}"));
            Application.Current.Exit();
            //await Launcher.LaunchUriAsync(new Uri("mytube://"));
        }

       

        private string getVideoIDFromUrl(string url)
        {

            string videoID = "";


            if (url.Contains("http"))
            {
                if (url.Contains("https"))
                {
                    url = url = url.Replace("https://", "");
                }
                else
                {
                 url = url.Replace("http://", "");
                }
            }

           
            //and return nothing in final else



            if (url.Contains("www"))
            {
                url = url.Replace("www.", "");
            }

            //Handle all m.youtube cases in one if
            //all youtube cases in else if
            //all youtu.be in another else if

            if (url.Contains("m.youtube.com"))
            {
                if (url.Contains("m.youtube.com/embed"))
                {
                    videoID = url.Replace("m.youtube.com/embed/", "");
                }
                else
                {
                    videoID = url.Replace("m.youtube.com/watch?v=", "");
                }
            }

            else if (url.Contains("youtube.com"))
            {
                if (url.Contains("youtube.com/embed"))
                {
                    videoID = url.Replace("youtube.com/embed/", "");
                }
                else
                {
                    videoID = url.Replace("youtube.com/watch?v=", "");
                }

            }








            else if (url.Contains("youtu.be"))
            {
                videoID = url.Replace("youtu.be/", "");

            }

            else videoID = $"{url} is invalid.";

            byte videoIDLength = (byte)videoID.Length;
            if (videoID[videoIDLength - 2] == '?' && videoID[videoIDLength - 1] == 'a')
            {
                videoID = videoID.Remove(videoIDLength - 2, 2);
            }

            if (videoID.Contains("?autoplay"))
            {
                int startOfRemoval = videoID.LastIndexOf("?autoplay");
                videoID = videoID.Remove(startOfRemoval);
            }




            return videoID;
        }

        
    }
}

