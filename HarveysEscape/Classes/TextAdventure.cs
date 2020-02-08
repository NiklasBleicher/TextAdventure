using System;
using System.Collections.Generic;

namespace HarveysEscape
{
    
    class TextAdventure
    {
        public List<Room> AllRooms;
        public Player Player;
        public Room CurrentRoom;
        public bool GameStatus;
        
        //For creating a new Textadventure in Program.cs
        public TextAdventure(List<Room> _allRooms, Player _player, Room currentRoom)
        {
            this.AllRooms = _allRooms;
            this.Player = _player;
            this.CurrentRoom = currentRoom;
            this.GameStatus = true;
        }

        public void Play()
        {
            Console.WriteLine(Player.StartText);
            Console.WriteLine(AllRooms[0].Npcs[0].Interactions);
            if (GameStatus)
            {
               
                Console.WriteLine("What do you want to do?");
                Console.Write(">");
                string input = Console.ReadLine();
                input = input.ToLower();

                switch (input)
                {
                    case "commands":
                    case    "c":
                        DisplayCommands();
                        break;
                    case "east":
                    case    "e":
                        CurrentRoom.EastDoor.TryPassDoor(this);
                        break;
                    case "west":
                    case "w":
                        CurrentRoom.WestDoor.TryPassDoor(this);
                        break;
                    case "south":
                    case "s":
                        CurrentRoom.SouthDoor.TryPassDoor(this);
                        break;
                    case "north":
                    case "n":
                        CurrentRoom.NorthDoor.TryPassDoor(this);
                        break;
                    case "quit":
                    case "q":
                        GameStatus = false;
                        break;

                }
                
            }
        }

        public void DisplayCommands()
        {
            Console.WriteLine("commands(c), look(l), ..");
        }
    }
}