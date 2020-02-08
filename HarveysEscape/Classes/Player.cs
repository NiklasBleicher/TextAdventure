using System;
using System.Collections.Generic;

namespace HarveysEscape
{
    //Creates Player (Name, Introtext, Inventory)
    //Methods: ShowInventory() PickUpItem(), DropItem(), 
    public class Player
    {
        public string Name;
        public int Health;
        public List<Item> Inventory;
        public string StartText;
        public string EndText;

        public Player(string _name, int _health, List<Item> _inventory, string _startText, string _endText)
        {
            this.Name = _name;
            this.Health = _health;
            this.Inventory = _inventory;
            this.StartText = _startText;
            this.EndText = _endText;

        }

        public void ShowInventory()
        {
            
        }
    }
}