using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


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
            
        }

        public void RemoveNPC()
        {
            
        }

        public void AddNPC()
        {
            
        }

        public void GiveItemToNPC(TextAdventure _TA)
        {
            
        }

        public void GiveItemToPlayer(TextAdventure _TA)
        {
            
        }
    }
     
    
    
}