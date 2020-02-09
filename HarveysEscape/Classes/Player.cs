using System;
using System.Collections.Generic;

namespace HarveysEscape
{
    //Creates Player (Name, Introtext, Inventory)
    //Methods: ShowInventory() PickUpItem(), DropItem(), 
    class Player
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
            if (Inventory.Count > 0)
            {
                Console.Write("Items in your Inventory: ");
                foreach (Item item in Inventory)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("There are no Items in your Inventory");
            }
            
        }

        public void DropItem(Room _R)
        {
            Console.WriteLine("Which Item do you want to drop?");
            string input = Console.ReadLine();
            if (Inventory.Count > 0)
            {
                int counter = 0;
                foreach (Item item in Inventory)
                {

                    if (input == item.Name)
                    {
                        _R.Items.Add(item);
                        Console.WriteLine("You dropped item: " + item.Name);
                        Inventory.RemoveAt(counter);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Item is not in Inventory");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("No Items in Inventory");
            }
        }

    

        public void TakeItem(Room _R)
        {
            Console.WriteLine("Which Item do you want to pick up?");
            string input = Console.ReadLine();
            if (_R.Items.Count > 0)
            {
                int counter = 0; 
                foreach (Item item in _R.Items)
                {
                    if (input == item.Name)
                    {
                        Inventory.Add(item);
                        Console.WriteLine(item.Name + " has been added to your Inventory");
                        _R.Items.RemoveAt(counter);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Are you sure about this?");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no Items in this Room");
            }
        }

        public void ShowItem()
        {
            Console.WriteLine("Which Item do you want to inspect?");
            string input = Console.ReadLine();

            if (Inventory.Count > 0)
            {
                foreach (Item item in Inventory)
                {
                    if (input == item.Name)
                    {
                        Console.WriteLine( item.Description + "\n");
                    }
                }
            }
        }
    }
}