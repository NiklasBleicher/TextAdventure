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

                //Get all Room Data from XML
                List<Room> rooms = new List<Room>(); //Create Empty List of Rooms
                XmlNodeList xmlRooms = doc.GetElementsByTagName("Value"); 
                XmlNodeList xmlDescription = doc.GetElementsByTagName("Description");
                
                //Get all Door Data from XML
                XmlNodeList xmlDoors = doc.GetElementsByTagName("Doors");
                XmlNodeList xmlNorthDoor = doc.GetElementsByTagName("NorthDoor");
                XmlNodeList xmlSouthDoor = doc.GetElementsByTagName("SouthDoor");
                XmlNodeList xmlWestDoor = doc.GetElementsByTagName("WestDoor");
                XmlNodeList xmlEastDoor = doc.GetElementsByTagName("EastDoor");
                
                //Get all NPC Data from XML
                
                for(int i = 0; i < xmlRooms.Count; i++)
                {
                    //Get Data for Room
                    string name = (xmlRooms[i].InnerXml);
                    string description = xmlDescription[i].InnerXml;

                    //Get Data for Doors in Room
                    Door northDoor = new Door(Convert.ToBoolean(xmlNorthDoor[i].FirstChild.InnerText), xmlNorthDoor[i].LastChild.InnerText);
                    Door southDoor = new Door(Convert.ToBoolean(xmlSouthDoor[i].FirstChild.InnerText), xmlSouthDoor[i].LastChild.InnerText);
                    Door westDoor = new Door(Convert.ToBoolean(xmlWestDoor[i].FirstChild.InnerText), xmlWestDoor[i].LastChild.InnerText);
                    Door eastDoor = new Door(Convert.ToBoolean(xmlEastDoor[i].FirstChild.InnerText), xmlEastDoor[i].LastChild.InnerText);
                    
                    //Get Data for Items in Room
                    List<Item> items = new List<Item>();


                    
                    //Get Data for NPC in Room
                    List<NPC> npcs = new List<NPC>();
                    
                    foreach (XmlNode child in xmlRooms[i].ChildNodes)
                    {
                        if (child.Name == "NPC")
                        {
                            string npcName = child
                            NPC npc = new NPC(npcName);
                            npcs.Add(npc);
                        }
                    }
                    
                    //rooms.Add(new Room(name, description, northDoor, southDoor, westDoor, eastDoor, items, npcs));
                }

                Console.WriteLine(rooms);
                
                //Set first Room to Start Room
                Room currentRoom = rooms[0];
                
                //Filter Player Elements fromXML
                Player player = new Player();
                XmlDocument pla = new XmlDocument();
                doc.Load(@"../../GameBuild/Player.xml");
                
                
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