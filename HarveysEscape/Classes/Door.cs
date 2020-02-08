using System;

namespace HarveysEscape
{
    public class Door
    {
        public bool IsOpen;
        public string LeadsTo;

        public Door(bool _IsOpen, string _LeadsTo)
        {
            this.IsOpen = _IsOpen;
            this.LeadsTo = _LeadsTo;
        }

    }
}