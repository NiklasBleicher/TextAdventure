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
            Console.WriteLine(this.Description);
        }
    }
    
    
}