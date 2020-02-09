using System;
using System.Collections.Generic;

namespace HarveysEscape
{
    class Item
    {
        public string Name;
        public string Description;
        public bool IsWeapon;

        public Item(string _name, string _description, bool _isWeapon)
        {
            this.Name = _name;
            this.Description = _description;
            this.IsWeapon = _isWeapon;
        }

    }
}