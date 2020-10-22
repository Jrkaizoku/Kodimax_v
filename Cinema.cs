using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Cinema
    {
        public List<User> users;
        public List<Movie> movies;      
        public List<Snack> snacks;
        User user = new User("Jenniffer","Granados","Admin", "admin", 0);
        User user4 = new User("Jenniffer", "Granados", "Admin1", "admin1", 1);
        User user2 = new User("Barrons", "admin2020", 2);
        User user3 = new User("admin-max", "@dminM@x", 0);
        public int[] userArray = new int[10];


        public Cinema()
        {
            users = new List<User>();
            movies = new List<Movie>();
            snacks = new List<Snack>();
            Movie movie = new Movie(01, "Parasites", 130, "Realismo");
            AddMovies(movie);
            movie = new Movie(02, "FlashPoint", 100, "Animada");
            AddMovies(movie);
            movie = new Movie(03, "Harry Potter", 100, "Fantasia");
            AddMovies(movie);
            Snack snack = new Snack(01, "Pop corn", "Comida", 3.55);
            AddSnack(snack);
            snack = new Snack(01, "Gaseosa", "Bebida", 1);
            AddSnack(snack);
            snack = new Snack(01, "Nachos", "Comida", 4.50);
            AddSnack(snack);
            AddUser(user);
            AddUser(user2);
            AddUser(user3);
            AddUser(user4);


        }
        public void AddUser(User user) {
            users.Add(user);
            
        }
        public bool ValidateUser(string user, string password) {
            bool login = false;
            int i = 0;
            string name = "";
            foreach (User _user in  users) {
                
                if (user == _user.Users)
                {
                    name = _user.Users;
                    if (password == _user.Password)
                        login = true;
                    else i++;                    
                }
            }
            if (login) Console.WriteLine("Datos correctos; {0} Bienvenid@", name);
            else {
                if(i>0) Console.WriteLine("{0}, Contraseña incorrecta", name);
                else Console.WriteLine("Datos Incorrectos; Usuario {0} Contraseña {1},Registrese en el sistema", user, password);
            }
            return login;
        }
        public void AddMovies(Movie movie) {
            movies.Add(movie);
        }
        public void AddSnack(Snack snack)
        {
            snacks.Add(snack);
        }
        public int SearchUser(string user,string password) {
            int id=0;
            foreach (User _user in users)
            { 
                if (user == _user.Users)  
                    if (password == _user.Password)
                        id = _user.Id;                                    
            }
            return id;
        }
        public void ShowMovies(){            
            Console.WriteLine("     Listado de peliculas");
            Console.WriteLine("     ID\tNombre\t\t   Duracion\t   Tipo");
            Console.WriteLine("     -------------------------------------------------");
            int y = 3;
            foreach (Movie movie in movies) {
                Console.SetCursorPosition(5, y);
                Console.WriteLine(y-2);
                Console.SetCursorPosition(8, y);
                Console.WriteLine(movie.Name);
                Console.SetCursorPosition(28, y);
                Console.WriteLine(movie.Duration);
                Console.SetCursorPosition(42, y);
                Console.WriteLine(movie.Type);
                y++;
                
            }
        }
        public void ShowSnack() {
            Console.WriteLine("        Tienda de Golosinas");
            Console.WriteLine("     ID\tNombre\t\t   Tipo\t\t   Precio");
            Console.WriteLine("     -------------------------------------------------");
            int y = 3;
            foreach (Snack snack in snacks)
            {
                Console.SetCursorPosition(5, y);
                Console.WriteLine(y-2);
                Console.SetCursorPosition(8, y);
                Console.WriteLine(snack.Name);
                Console.SetCursorPosition(28, y);
                Console.WriteLine(snack.Type);
                Console.SetCursorPosition(44, y);
                Console.WriteLine("${0}",snack.Price);
                y++;
            }
        }
        public int ShowEmployes()
        {
            int totUsers = 0;
            int count = 0;
            Console.WriteLine("        Lista de empleados");
            Console.WriteLine("     ID\tNombre\t\t Apellido\t   Usuario");
            Console.WriteLine("     -------------------------------------------------");
            int y = 3;
            foreach (User user in users)
            {
               
                if (user.Id == 1)
                {
                    
                    Console.SetCursorPosition(5, y);
                    Console.WriteLine(y - 2);
                    Console.SetCursorPosition(8, y);
                    Console.WriteLine(user.Name);
                    Console.SetCursorPosition(25, y);
                    Console.WriteLine(user.Surname);
                    Console.SetCursorPosition(44, y);
                    Console.WriteLine( user.Users);
                    userArray[totUsers] = count;
                    y++;
                    totUsers++;

                }
                count++;
            }
            return totUsers;
        }

    }
}
