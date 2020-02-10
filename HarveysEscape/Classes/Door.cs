﻿using System;
using System.Net.Mime;

namespace HarveysEscape
{
    class Door
    {
        public bool IsOpen;
        public string LeadsTo;

        public Door(bool _isOpen, string _leadsTo)
        {
            this.IsOpen = _isOpen;
            this.LeadsTo = _leadsTo;
        }

        public void TryPassDoor(TextAdventure _TA)
        {
            if (this.IsOpen == true)
            {
                this.PassDor(_TA);
            }
            else
            {
                if (LeadsTo == "FREEDOME")
                {
                    Console.WriteLine("YOU WON THE GAME");
                    _TA.GameStatus = false;
                }
                else
                {
                    Console.WriteLine("Leeds to: " + this.LeadsTo);
                    if ((LeadsTo == "Entrance Hall") && (IsOpen == false))
                    {
                        if (_TA.Player.Inventory.Count > 0)
                        {
                            foreach (Item item in _TA.Player.Inventory)
                            {
                                if (item.Name == "Key")
                                {
                                    _TA.CurrentRoom.SouthDoor.IsOpen = true;
                                    Console.WriteLine("You unlocked the Door!");
                                    PassDor(_TA);
                                }
                                else
                                {
                                    Console.WriteLine("You need a Key to enter");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no Items in you Inventory, you need a Key to enter");
                        }
                    }
                }
                
            }
        }

        public void PassDor(TextAdventure _TA)
        {
            foreach (Room room in _TA.AllRooms)
            {
                if (LeadsTo == room.Name)
                {
                    _TA.CurrentRoom = room;
                    _TA.CurrentRoom.ShowRoom();
                }
            }
        }

    }
}