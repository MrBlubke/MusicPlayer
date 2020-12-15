﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlayer
{
    internal class GetSongs
    {
        public string DirPath { get; set; }
        public string[] FindMp3(string dir)   
        {
            List<string> songList = new List<string>();

            foreach (string file in Directory.EnumerateFiles(dir, "*.mp3"))
            {
                songList.Add(file);
            }
            string[] songArray = new string[songList.Count];

            for (int i = 0; i < songArray.Length; i++)
            {
                songArray[i] = songList[i];
            }
            return songArray;
        }

        public void GetMetaData(string file)
        {
            
            TagLib.File tagFile = TagLib.File.Create(file);
            bool booltje = tagFile.Tag.IsEmpty;
            if (!booltje) { 
            string artist = tagFile.Tag.Performers[0];
            string album = tagFile.Tag.Album;
            string title = tagFile.Tag.Title;
           
            Console.Write($"{album}  |  ");
            Console.Write($"{artist}  |  ");
            Console.WriteLine(title);
            } else
            {
                Console.WriteLine(file);
            }
        }

        public string ViewSongs(string dirPath)
        {
            DirPath = dirPath;
            string[] songlist = FindMp3(dirPath);
            int selectIndex;
            Console.WriteLine();
            for (int i = 0; i < songlist.Length; i++)
            {
                if (i < 10)
                {
                    Console.Write("0");
                }
                selectIndex = i + 1;
                Console.Write($"{selectIndex}  ");
                GetMetaData(songlist[i]);
            }
            Console.Write("\nSelect number, type full path to file\nor drag and drop an mp3 on this console:");
            string invoer;
            do { invoer = Console.ReadLine(); } while (invoer == "");

            bool success = Int32.TryParse(invoer, out int selection); //check of invoer een integer is 
            string path;
            if (success) //integer -> song selectie uit lijst
            {
                path = songlist[selection-1]; // -1 want 0 based 
            }
            else
            {
                invoer = invoer.Replace("\"", ""); // verwijder de mogelijke extra " " van drag n drop uit de string
                path = invoer;
            }
            return path;
        }
    }
}