using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    internal class MusicPlayer
    {       
        public static void Initialize()
        {
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
        }
        public static void PlaySong(ContentManager content, int number)
        {
            Song song;
            if (number == 1)
                song = content.Load<Song>("Sprites/Music/Forest - Under The Great Tree");
            else if(number == 2)
                song = content.Load<Song>("Sprites/Music/Field - Greysand Desert");
            else if (number == 3)
                song = content.Load<Song>("Sprites/Music/Dungeon - Deception Dungeon");
            else
                song = content.Load<Song>("Sprites/Music/Airship - Flowing till the end");
            MediaPlayer.Play(song);
        }

        public static void Paused(bool toggle)
        {
            if (toggle)
                MediaPlayer.Pause();
            else
                MediaPlayer.Resume();
        }
    }
}
