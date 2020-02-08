using System.Collections.Generic;


namespace HarveysEscape
{
    //Constructor
    //Methods
    public class NPC
    {
        public string Name;
        public string Loot;
        public List<string> Interactions;

        public NPC(string _Name, string _Loot, List<string> _Interactions)
        {
            this.Name = _Name;
            this.Loot = _Loot;
            this.Interactions = _Interactions;
        }
    }
}