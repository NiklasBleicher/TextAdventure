using System.Collections.Generic;


namespace HarveysEscape
{
    //Constructor
    //Methods
     class NPC
    {
        public string Name;
        public Item Loot;
        public List<string> Interactions;

        public NPC(string _Name, Item _Loot, List<string> _Interactions)
        {
            this.Name = _Name;
            this.Loot = _Loot;
            this.Interactions = _Interactions;
        }
    }
}