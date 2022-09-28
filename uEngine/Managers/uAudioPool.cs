using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

using uEngine.Exceptions;

namespace uEngine.Managers
{
    public class uAudioPool
    {
        static private string AudioPath = "Assets/Audio/";
        static private Dictionary<string, MemoryStream> AudioMap = new Dictionary<string, MemoryStream>();

        static private int PlayingIndex = 0;
        static private Dictionary<int, WaveOutEvent> PlayingAudioMap = new Dictionary<int, WaveOutEvent>();


        public static void Load(string filaname, string id)
        {
            string pathname = AudioPath + filaname;
            if (File.Exists(pathname))
            {
                if (AudioMap.ContainsKey(id))
                {
                    throw new uResourceIdDuplicatedException(id);
                }
                else
                {
                    MemoryStream stream = new MemoryStream(File.ReadAllBytes(pathname));
                    AudioMap.Add(id, stream);
                }
            }
            else
            {
                throw new uResourceNotFoundException(pathname);
            }
        }

        static public int Play(string id)
        {
            if(AudioMap.ContainsKey(id))
            {
                MemoryStream stream = AudioMap[id];
                StreamMediaFoundationReader reader = new StreamMediaFoundationReader(stream);
                WaveOutEvent player = new WaveOutEvent();
                player.Init(reader);
                player.Play();

                int index = PlayingIndex;
                PlayingIndex++;
                PlayingAudioMap.Add(index, player);

                return index;
            }

            throw new uResourceIdNotFoundException(id);
        }

        static public void Stop(int playingId)
        {
            if(PlayingAudioMap.ContainsKey(playingId))
            {
                WaveOutEvent player = PlayingAudioMap[playingId];
                player.Stop();
                PlayingAudioMap.Remove(playingId);
            }
        }

        static public void Pause(int playingId)
        {
            if (PlayingAudioMap.ContainsKey(playingId))
            {
                WaveOutEvent player = PlayingAudioMap[playingId];
                player.Pause();
            }
        }

        static public void Resume(int playingId)
        {
            if (PlayingAudioMap.ContainsKey(playingId))
            {
                WaveOutEvent player = PlayingAudioMap[playingId];
                player.Play();
            }
        }

    }
}
