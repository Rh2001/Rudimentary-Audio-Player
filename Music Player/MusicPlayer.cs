/*
 * Very rudimentary implementation of the Factory Design Pattern for handling audio files using C# and the NAudio library
 * 
 * by Roham Harandi Fasih

*/
using NAudio.Wave;

namespace Music_Player
{
    public interface IMusicPlayer
    {
        public void Play(string filePath);
        public void Stop();
    }


    public class MP3Player : IMusicPlayer
    {
        private WaveOutEvent WaveOut = new WaveOutEvent();
        public void Play(string filePath)
        {
            Mp3FileReader MP3Reader = new Mp3FileReader(filePath);
            WaveOut.Init(MP3Reader);
            WaveOut.Play();

        }

        public void Stop() 
        {
            WaveOut.Stop();
        }

    }
    public class WavPlayer : IMusicPlayer
    {
        private WaveOutEvent WaveOut = new WaveOutEvent();
        public void Play(string filePath)
        {
            WaveFileReader WavReader = new WaveFileReader(filePath);
            WaveOut.Init(WavReader);
            WaveOut.Play();
        }
        public void Stop()
        {
            WaveOut.Stop();
        }
    } 



    public class MusicPlayerFactory 
    {
        //Due to the way NAudio works you have to only create one instance of each of your players

        MP3Player mp3player = new MP3Player();
        WavPlayer wavplayer = new WavPlayer();
        public IMusicPlayer CreateMusicPlayer(string filepath) 
        {
            //Requires System.IO to be used. C# 6.0 does not need using statements for these

            string extension = Path.GetExtension(filepath);

            switch (extension) 
            {
                case ".mp3":
                    wavplayer.Stop();
                    mp3player.Stop();
                    return mp3player;
          
                case ".wav":
                    wavplayer.Stop();
                    mp3player.Stop();
                    return wavplayer;
 
                default:
                    throw new NotSupportedException("Audio file format not supported by player.");
                    
            }
        }

        
    }
}
