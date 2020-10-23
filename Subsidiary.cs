using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Subsidiary
    {

        private string _name;
        private string _city;

        public string Name { get => _name; set => _name = value; }
        public string City { get => _city; set => _city = value; }

        public Subsidiary(string name,string city)
        {
            _name = name;
            _city = city;
        }
        public Subsidiary()
        {
           
        }
    }
}
