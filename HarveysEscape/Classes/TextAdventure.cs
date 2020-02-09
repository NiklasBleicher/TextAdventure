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
                    case "look":
                    case "l":
                        CurrentRoom.ShowRoom();
                        break;
                    case "inventory":
                    case "i":
                        Player.ShowInventory();
                        break;
                    case "attack":
                    case     "a":
                        CurrentRoom.FightNPC(Player);
                        break;
                    case "show item":
                    case     "si":
                        Player.ShowItem();
                        break;
                    case "talk":
                    case  "tk":
                        CurrentRoom.TalkToNpc();
                        break;
                    case "drop item":
                    case     "di":
                        Player.DropItem(CurrentRoom);
                        break;
                    case "take item":
                    case "ti":
                        Player.TakeItem(CurrentRoom);
                        break;
                    case "give item":
                    case     "gi":
                        CurrentRoom.GiveItemToNPC(Player);
                        break;
                    case "quit":
                    case "q":
                        GameStatus = false;
                        break;

                }
                Play();
            }
        }

        public void DisplayCommands()
        {
            Console.WriteLine("commands(c), look(l), inventory(i), attack(a), show item(si), talk(tk),take item(ti),drop item(di), give item(gi), north(n), south(s), west(w), east(e), quit(q)");
        }
    }
}