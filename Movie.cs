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
        public Autocine autocineS;
        public Autocine autocineV;
        public Autocine autocineP;

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

            autocineS = new Autocine(4.55, "Estandar", 0.50, 64);
            autocineP = new Autocine(5.75, "Premium", 1, 30);
            autocineV = new Autocine(7.5, "VIP", 2.5, 25);

        }
    }
}
