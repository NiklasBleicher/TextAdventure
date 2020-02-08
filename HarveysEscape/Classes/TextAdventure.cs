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
            while (this.GameStatus == true)
            {
               
                Console.WriteLine("What do you want to do?");
                Console.Write(">");
                string input = Console.ReadLine();
                input = input.ToLower();

                switch (input)
                {
                    case "commands":
                    case    "c":
                        this.DisplayCommands();
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