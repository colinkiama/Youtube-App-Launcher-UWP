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
        MatchService matchService = new MatchService();

        public static string url = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            url = (string)e.Parameter;            
        }

        private async void launchmyTubeButton_Click(object sender, RoutedEventArgs e)
        {
            //Testing
            //string videoID = matchService.Match("https://www.youtube.com/watch?v=9bDEQJ2w4KA");

            string videoID = matchService.Match(url);
            await Launcher.LaunchUriAsync(new Uri($"rykentube:Video?ID={videoID}"));
            Application.Current.Exit();
            
        }

        private async void launchPerfectTubeButton_Click(object sender, RoutedEventArgs e)
        {
            //Testing
            //string videoID = matchService.Match("https://www.youtube.com/watch?v=9bDEQJ2w4KA");

            string videoID = matchService.Match(url);
            await Launcher.LaunchUriAsync(new Uri($"perfecttube:{videoID}"));
            Application.Current.Exit();
        }
    }
}

