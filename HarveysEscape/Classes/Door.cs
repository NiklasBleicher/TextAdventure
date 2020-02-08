using System;

namespace HarveysEscape
{
    public class Door
    {
        public bool IsOpen;
        public string LeadsTo;
        public Item OpenedBy;
        public string Description;

        public Door(bool _IsOpen, string _LeadsTo, Item _OpenedBy, string _Description)
        {
            this.IsOpen = _IsOpen;
            this.LeadsTo = _LeadsTo;
            this.OpenedBy = _OpenedBy;
            this.Description = _Description;
        }

    }
}