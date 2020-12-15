﻿using System;
using WMPLib;
using TagLib;

namespace MusicPlayer
{

    
        class Program
        {
        static void Main(string[] args)
        {
            string path = "p:\\Music\\002. Queen - Under Pressure (Remastered).mp3";

            Player myplayer = new Player(path);
            myplayer.PlaySong();
            string keyPress;
 
            do
            {                
                myplayer.ShowMenu();
                Console.WriteLine();
                Console.WriteLine(myplayer.SongArtist);
                Console.WriteLine(myplayer.SongTitle);
                Console.WriteLine(myplayer.SongAlbum);
                Console.WriteLine(myplayer.Volume);
                keyPress = (Console.ReadKey().KeyChar).ToString().ToLower();
                myplayer.Action(keyPress);

            } while (keyPress != "x");
            }
        }
    }