using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;


namespace HarveysEscape
{
    //Method 
    //Constructor
     class Room
    {
        public String Name;
        public String Description;
        public Door NorthDoor;
        public Door SouthDoor;
        public Door WestDoor;
        public Door EastDoor;

        public List<Item> Items;
        public List<NPC> Npcs;
        
        public Room(string _Name, string _Description, Door _Northdoor, Door _SouthDoor, Door _WestDoor, Door _EastDoor, List<Item> _Items, List<NPC> _Npcs)
        {
            this.Name = _Name;
            this.Description = _Description;
            this.SouthDoor = _SouthDoor;
            this.NorthDoor = _Northdoor;
            this.EastDoor = _EastDoor;
            this.WestDoor = _WestDoor;
            this.Items = _Items;
            this.Npcs = _Npcs;

        }


        public void ShowRoom()
        {
            Console.WriteLine(Description + "\n");
            
            if (Items.Count > 0)
            {
                Console.WriteLine("These Items are in this Room: ");
                foreach (Item item in Items)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("There is nothing useful here");
            }

            if (this.Npcs.Count > 0)
            {
                Console.WriteLine("People in this Room: ");
                foreach (NPC npc in Npcs)
                {
                    Console.Write(npc.Name + ", ");
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("We are all alone in here");
            }
        }

        public void TalkToNpc()
        {
            Console.WriteLine("Who do you want to talk to?");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (Npcs.Count > 0)
            {
                foreach (NPC npc in Npcs)
                {
                    if (input == npc.Name)
                    {
                        Console.WriteLine(npc.Interactions[0]);
                    }
                }
            }
        }

        public void FightNPC(TextAdventure _TA)
        {
            Console.WriteLine("Who do you want to attack?");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (Npcs.Count > 0)
            {
                foreach (NPC npc in Npcs)
                {
                    if (input == npc.Name)
                    {
                        if (input != "dr.marcel")
                        {
                            Console.WriteLine("Attacking " + npc.Name + " would cause even more trouble");
                        }
                        else
                        {
                            Console.WriteLine("Which Weapon do you want to choose: ");
                            foreach (Item item in _TA.Player.Inventory)
                            {
                                Console.Write(item.Name + ", ");
                            }
                            string weapon = Console.ReadLine();
                            weapon = weapon.ToLower();
                            foreach (Item item in _TA.Player.Inventory)
                            {
                                if (weapon == item.Name)
                                {
                                    if (item.IsWeapon)
                                    {
                                        Console.WriteLine(npc.Interactions[2]);
                                        Console.WriteLine("You defeated Dr.Marcel access to Freedome is now yours");
                                        _TA.CurrentRoom.SouthDoor.IsOpen = true;
                                        RemoveNPC(npc);
                                        break;
                                    }
                                    else
                                    {
                                        if (_TA.Player.Health > 0)
                                        {
                                            Console.WriteLine(npc.Interactions[1]);
                                            _TA.Player.Health = _TA.Player.Health - 5;
                                            Console.WriteLine("You got hit by Dr. Marcel!");
                                            Console.WriteLine("Your current Health is: " + _TA.Player.Health + ". Maybe you should Overthink your Strategy");   
                                        }
                                        else
                                        {
                                            Console.WriteLine("You lost better Luck next time!");
                                            Console.ReadLine();
                                            _TA.GameStatus = false;
                                        }
                                      
                                    }

                                  
                                }
                            }
                            break;
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine(npc.Name + " is not here");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Danger in this Room");
            }
        }

        public void RemoveNPC(NPC _npc)
        {
            int count = 0;
            foreach (NPC npc in this.Npcs)
            {
                if (npc == _npc)
                {
                    Npcs.RemoveAt(count);
                    break;
                }
            }
        }

        public void GiveItemToNPC(TextAdventure _TA)
        {
            Console.WriteLine("Who do you want to give an Item?");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (Npcs.Count > 0)
            {
                foreach (NPC npc in Npcs)
                {
                    if (input == npc.Name)
                    {
                        Console.WriteLine("Which Item do you want to give to " + input);
                        string item = Console.ReadLine();
                        item = item.ToLower();
                        if (item == npc.Interactions[2])
                        {
                            Console.WriteLine("Thank you so much for the " + item);
                            int counter = 0;
                            foreach (Item it in _TA.Player.Inventory)
                            {
                                if (item == it.Name)
                                {
                                    _TA.Player.Inventory.RemoveAt(counter);
                                    Console.WriteLine(item + " was removed from Inventory");
                                    Console.WriteLine("Here is Something in return: " + npc.Loot.Name);
                                    _TA.Player.Inventory.Add(npc.Loot);
                                    break;

                                }
                                else
                                {
                                    counter = counter + 1;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(npc.Interactions[1]);
                        }
                        
                    }
                }
            }
        }
    }
     
    
    
}