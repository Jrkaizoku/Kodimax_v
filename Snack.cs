using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public Snack()
        {
        }

        public Snack(int id, string name, string type, double price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
