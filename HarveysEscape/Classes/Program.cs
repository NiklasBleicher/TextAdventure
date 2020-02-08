using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Xml;
using System.IO;

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
                
                //Load All Room Data: NPCs, Items, ...
                List<Room> rooms = new List<Room>() {}; //Create Empty List of Rooms
                XmlNodeList xmlRooms = doc.GetElementsByTagName("Value"); 
                XmlNodeList xmlDescription = doc.GetElementsByTagName("Description");
                XmlNodeList xmlNorthDoor = doc.GetElementsByTagName("NorthDoor");
                XmlNodeList xmlSouthDoor = doc.GetElementsByTagName("SouthDoor");
                XmlNodeList xmlWestDoor = doc.GetElementsByTagName("WestDoor");
                XmlNodeList xmlEastDoor = doc.GetElementsByTagName("EastDoor");
                for(int i = 0; i < xmlRooms.Count; i++)
                {
                    //Get Data for Room
                    string name = (xmlRooms[i].InnerXml);
                    string description = xmlDescription[i].InnerXml;
                    
                    //Get Data for Doors in Room

                    //Get Data for NPC in Room
                    //rooms.Add(new Room(name, description, northdoor, ));
                }

                Console.WriteLine(rooms);
                
                //Set first Room to Start Room
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