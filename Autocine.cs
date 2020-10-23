using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Autocine
    {
        private double Price;
        private string Type;
        private double Parking;
        private int Available;
        public double _price { get => Price; set => Price = value; }
        public string _type { get => Type; set => Type = value; }
        public double _parking { get => Parking; set => Parking = value; }
        public int _available { get => Available; set => Available = value; }

        public Autocine(double price, string type, double parking, int available)
        {
            Price = price;
            Type = type;
            Parking = parking;
            Available = available;
        }

        public Autocine()
        {
        }
    }
}
