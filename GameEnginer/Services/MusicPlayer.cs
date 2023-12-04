using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
namespace GameEngine.Services
{
    public static class MusicPlayer
    {
        private static MediaPlayer _mediaPlayer = new MediaPlayer();

        public static bool IsOn { get; set; } = false;
        private static double _volume = 0.5;
        public static double Volume
        {
            set
            {
                _volume = value / 100;
                _mediaPlayer.Volume = _volume;
            }
            get
            {
                return _volume * 100;
            }
        }
        public static void Play(string fileName)
        {
            if (!IsOn)
            {
                IsOn = true;
                _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Music/{fileName}"));
                _mediaPlayer.IsLoopingEnabled = true;
                _mediaPlayer.Play();
            }
        }
        public static void Stop()
        {
            IsOn = false;
            _mediaPlayer.Pause();
        }
        public static void ChangeVolume(double volume)
        {
            _volume = volume;
        }
    }
}