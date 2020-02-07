using System;
using System.Collections.Generic;

namespace HarveysEscape
{
    
    class TextAdventure
    {
        public List<Room> AllRooms;
        public Player Player;
        public Room CurrentRoom;

        public bool gameStatus = true;
        
        //For creating a new Textadventure in Program.cs
        public TextAdventure(List<Room> _allRooms, Player _player, Room currentRoom)
        {
            this.AllRooms = _allRooms;
            this.Player = _player;
            this.CurrentRoom = currentRoom;
        }

        public void Play()
        {
            while (gameStatus == true)
            {
                Console.WriteLine();
            }
        }
    }
}