

namespace WytSky.Mobile.Maui.Skoola.Views.Courses;

public partial class VideoPlayerPage : BaseContentPage
{
    private LibVLCSharp.Shared.LibVLC _libVLC;
    private LibVLCSharp.Shared.MediaPlayer _mediaPlayer;
    private string Url;

    public VideoPlayerPage(string url)
    {
        try
        {
            InitializeComponent();
            Url = url;
        }
        catch (Exception ex)
        {
            string er = ex.Message;
        }
    }

    protected override void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            if (Url.Contains("https://www.youtube.com/"))
            {
                webView.Source = Url;
                webView.IsVisible = true;
                videoPlayerStack.IsVisible = false;
            }
            else
            {
                LibVLCSharp.Shared.Core.Initialize();
                _libVLC = new LibVLCSharp.Shared.LibVLC();
                _mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
                VideoView.MediaPlayer = _mediaPlayer;
                var media = new LibVLCSharp.Shared.Media(_libVLC, new Uri(Url));
                _mediaPlayer.Play(media);
                webView.IsVisible = false;
                videoPlayerStack.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex, "", "VideoPlayerPage", "OnAppearing");
        }
    }

    private void OnPlayVideoClicked(object sender, EventArgs e)
    {
        //var media = new LibVLCSharp.Shared.Media(_libVLC, new Uri(Url));
        _mediaPlayer.Play();
    }

    private void OnPauseVideoClicked(object sender, EventArgs e)
    {
        _mediaPlayer.Pause();
    }

    private void OnStopVideoClicked(object sender, EventArgs e)
    {
        _mediaPlayer.Stop();
    }

    protected override void OnDisappearing()
    {
        try
        {
            base.OnDisappearing();
            _mediaPlayer.Dispose();
            _libVLC.Dispose();
        }
        catch (Exception ex)
        {
            ExtensionLogMethods.LogExtension(ex,"", "VideoPlayerPage", "OnDisappearing");
        }
      
    }
}