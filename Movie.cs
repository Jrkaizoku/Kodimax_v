using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Movie
    {
        public int IDMovie { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
        public Room roomStandar;
        public Room roomVIP;
        public Room roomPremium;

        public Movie()
        {
        }

        public Movie(int iDMovie, string name, int duration, string type)
        {
            IDMovie = iDMovie;
            Name = name;
            Duration = duration;
            Type = type;
            AddRoom();


        }
        public void AddRoom() {
            roomStandar = new Room(3.55, "Estandar");
            roomPremium = new Room(4.75, "Premium");
            roomVIP = new Room(6.5, "VIP");
            roomStandar.AddRoom();
            roomPremium.AddRoom();
            roomVIP.AddRoom();
        }
    }
}
