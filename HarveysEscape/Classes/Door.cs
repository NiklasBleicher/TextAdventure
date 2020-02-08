using System;
using System.Net.Mime;

namespace HarveysEscape
{
    class Door
    {
        public bool IsOpen;
        public string LeadsTo;

        public Door(bool _IsOpen, string _LeadsTo)
        {
            this.IsOpen = _IsOpen;
            this.LeadsTo = _LeadsTo;
        }

        public void TryPassDoor(TextAdventure _TA)
        {
            if (this.IsOpen == true)
            {
                this.PassDor(_TA);
            }
            else
            {
                Console.WriteLine(this.LeadsTo);
            }
        }

        public void PassDor(TextAdventure _TA)
        {
            foreach (Room room in _TA.AllRooms)
            {
                if (LeadsTo == room.Name)
                {
                    _TA.CurrentRoom = room;
                    _TA.CurrentRoom.ShowRoom();
                }
            }
        }

    }
}