using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Net.Sockets;

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
            Console.Write(">");
            String input = Console.ReadLine();
            
            
            
            if (input == "1")
            {
                System.IO.DirectoryInfo xmlPath = new System.IO.DirectoryInfo(@"../../GameBuild/");
                XmlDocument doc = new XmlDocument();
                
                List<Room> rooms = new List<Room>(); //Create Empty List of Rooms
                for (int j = 0; j <= xmlPath.GetFiles().Length - 3; j++)
                {
                    
                    doc.Load(@"../../GameBuild/Room" + (j + 1) +".xml");

                    //Get all Room Data from XML
                    XmlNodeList xmlRooms = doc.GetElementsByTagName("Value");
                    XmlNodeList xmlDescription = doc.GetElementsByTagName("Description");

                    //Get all Door Data from XML
                    XmlNodeList xmlDoors = doc.GetElementsByTagName("Doors");
                    XmlNodeList xmlNorthDoor = doc.GetElementsByTagName("NorthDoor");
                    XmlNodeList xmlSouthDoor = doc.GetElementsByTagName("SouthDoor");
                    XmlNodeList xmlWestDoor = doc.GetElementsByTagName("WestDoor");
                    XmlNodeList xmlEastDoor = doc.GetElementsByTagName("EastDoor");
                    
                    //Get all Item Data from XML
                    XmlNodeList xmlItem = doc.GetElementsByTagName("Item");
                    XmlNodeList xmlItemName = doc.GetElementsByTagName("ItemName");
                    XmlNodeList xmlItemDescription = doc.GetElementsByTagName("ItemDescription");
                    XmlNodeList xmlItemIsWeapon = doc.GetElementsByTagName("IsWeapon");
                    
                    //Get all NPC Data from XML
                    XmlNodeList xmlNPC = doc.GetElementsByTagName("NPC");
                    XmlNodeList xmlNpcName = doc.GetElementsByTagName("Name");
                    XmlNodeList xmlNpcTalk = doc.GetElementsByTagName("Talk");
                    XmlNodeList xmlNpcWrongItem = doc.GetElementsByTagName("WrongItem");
                    XmlNodeList xmlNpcRightItem = doc.GetElementsByTagName("RightItem");
                    XmlNodeList xmlLootName = doc.GetElementsByTagName("LootName");
                    XmlNodeList xmlLootDescription = doc.GetElementsByTagName("LootDescription");
                    XmlNodeList xmlLootIsWeapon = doc.GetElementsByTagName("LootIsWeapon");
                    
                    for (int i = 0; i < xmlRooms.Count; i++)
                    {
                        //Get Data for Room
                        string name = (xmlRooms[i].InnerXml);
                        string description = xmlDescription[i].InnerXml;
                        
                        //Get Data for Doors in Room
                        Door northDoor = new Door(Convert.ToBoolean(xmlNorthDoor[i].FirstChild.InnerText),
                            xmlNorthDoor[i].LastChild.InnerText);
                        Door southDoor = new Door(Convert.ToBoolean(xmlSouthDoor[i].FirstChild.InnerText),
                            xmlSouthDoor[i].LastChild.InnerText);
                        Door westDoor = new Door(Convert.ToBoolean(xmlWestDoor[i].FirstChild.InnerText),
                            xmlWestDoor[i].LastChild.InnerText);
                        Door eastDoor = new Door(Convert.ToBoolean(xmlEastDoor[i].FirstChild.InnerText),
                            xmlEastDoor[i].LastChild.InnerText);

                        //Get Data for Items in Room
                        List<Item> items = new List<Item>();

                        for (int k = 0; k < xmlItem.Count; k++)
                        {
                            string itemName = xmlItemName[k].InnerXml;
                            string itemDescription = xmlItemDescription[k].InnerXml;
                            bool itemIsWeapon = Convert.ToBoolean(xmlItemIsWeapon[k].InnerText);
                            Item item = new Item(itemName, itemDescription, itemIsWeapon);
                            items.Add(item);
                        }

                        //Get Data for NPC in Room
                        List<NPC> npcs = new List<NPC>();
                        
                        for(int count = 0; count < xmlNPC.Count; count++)
                        {
                            string npcName = xmlNpcName[count].InnerXml;
                            Item npcItem = new Item(xmlLootName[count].InnerXml, xmlLootDescription[count].InnerXml, Convert.ToBoolean(xmlLootIsWeapon[count].InnerText));
                            
                            List<string> npcInteractions = new List<string>();
                            string npcTalk = xmlNpcTalk[count].InnerXml;
                            string npcWrongItem = xmlNpcWrongItem[count].InnerXml;
                            string npcRightItem = xmlNpcRightItem[count].InnerXml;
                            npcInteractions.Add(npcTalk);
                            npcInteractions.Add(npcWrongItem);
                            npcInteractions.Add(npcRightItem);
                            
                            npcs.Add(new NPC(npcName, npcItem, npcInteractions));
                        }

                        rooms.Add(new Room(name, description, northDoor, southDoor, westDoor, eastDoor, items, npcs));
                        break;
                    }
                }

                //Set first Room to Start Room
                Room currentRoom = rooms[0];
                
                //Filter Player Elements fromXML
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(@"../../GameBuild/Player.xml");
                XmlNodeList xmlPlayerName = doc2.GetElementsByTagName("Name");
                XmlNodeList xmlPlayerHealth = doc2.GetElementsByTagName("Health");
                XmlNodeList xmlStartText = doc2.GetElementsByTagName("StartText");
                XmlNodeList xmlEndText = doc2.GetElementsByTagName("EndText");

                string playerName = xmlPlayerName[0].InnerXml;
                int playerHealth = int.Parse(xmlPlayerHealth[0].InnerXml);
                List<Item> playerInventory = new List<Item>();
                string startText = xmlStartText[0].InnerXml;
                string endText = xmlEndText[0].InnerXml;
                
                Player player = new Player(playerName, playerHealth, playerInventory, startText, endText);
                
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
            Console.WriteLine(_TA.Player.StartText);
            _TA.Play();
        }
    }
}