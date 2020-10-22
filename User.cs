using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class User
    {
        public int IdCinema = 1234;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public char Sex { get; set; }
        public string Birthday { get; set; }
        public string Users { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public User()
        {
        }

        public User( string users, string password, int id)        {
           
            Users = users;
            Password = password;
            Id = id;
        }
        public User(string name, string surname,string users, string password,int id)
        {
            Name = name;
            Surname = surname;
            Users = users;
            Password = password;
            Id = id;
        }

        public User(string name, string surname, string email, string telephone, char sex, string birthday, string users, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Telephone = telephone;
            Sex = sex;
            Birthday = birthday;
            Users = users;
            Password = password;
        }
        public void AddId(int id)
        {
            if (IdCinema == id) Id = 1;
            else Id = 2;
        }

    }
}
