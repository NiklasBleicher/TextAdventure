using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Xml;

namespace HarveysEscape
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            LoadGame();
        }

        private static void LoadGame()
        {
            TextAdventure TA;
            Console.WriteLine("Type the number of the Option you need:");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Quit Game");
            String input = Console.ReadLine();
            if (input == "1")
            {
                
                XmlDocument doc = new XmlDocument();
                doc.Load(@"../../GameBuild/Content.xml");
                string content = doc.InnerXml;
                
                //Create Textadventure Object: List of Rooms, CurrentRoom, Player
                List<Room> rooms = new List<Room>();
                XmlNodeList elements = doc.GetElementsByTagName("Rooms");
                Console.WriteLine(elements);
                Room currentRoom = rooms[0];
                //Filter Player Elements fromXML
                Player player = new Player();
                
                
                TA = new TextAdventure(rooms, player, currentRoom);
                //Call StartGame
                StartGame(TA);
            }
            else if(input == "2")
            {
                return; //Ends Game
            }
            else
            {
                Console.WriteLine("Error! Please try again!");
                LoadGame();
            }

            //Load Data from XML to Create Structure

        }
        
        //Initialize New Game with all Parameters from LoadGame()
        private static void StartGame(TextAdventure _TA)
        {
            //Calls Play() from Text-Adventure-Class
            _TA.Play();
        }
    }
}