using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kodimax
{
    class Program
    {
        static int initial_Login = 1, initial_Register = 1;
        static Cinema cinema = new Cinema();
        static Menus menus = new Menus();
        static Random random = new Random();
        static void Main(string[] args)
        {
            string users="", password="";
            int option;           
            string[] nameButton = { "   Login   ", "   Salir   " };
            string[] menuInitial = { "Login", "Registarse", "Salir" };
         
            int isValid = 0;
          
            do
            {
                Console.Clear();
                option = menus.MenuInitial(menuInitial, "Bienvenido, inicia sesion o registrate");
               
                if (option == 1)
                {
                    do
                    {
                        menus.Login();
                        Console.SetCursorPosition(31, 5);
                        users = Console.ReadLine();
                        Console.SetCursorPosition(31, 8);
                        password = Console.ReadLine();                       
                        initial_Login = menus.MoveButton(19, 9, 40, nameButton);

                        if (initial_Login == 1)
                        {
                            if (cinema.ValidateUser(users, password))
                                isValid = 1;
                        }
                        else
                            break;
                    } while (isValid != 1);

                }
                if (option == 2) CheckIn();

                if (isValid == 1)
                {                  
                    if (cinema.SearchUser(users,password) == 1) MenuEmployee(users);
                    if (cinema.SearchUser(users,password) == 2) MenuCustomer(users);
                    if (cinema.SearchUser(users, password) == 0) MenuAdmin(users);
                }

            } while (option != 3);

                Console.WriteLine("Presione cualquier tecla para Terminar...");
                Console.ReadKey();
            
        }

    
        static void CheckIn()
        {

            string[] nameButton = { "  Guardar  ", "  Cancelar " };
            Console.Clear();
            Console.WriteLine("                Registro de Usuario");
            Console.WriteLine("     -----------------------------------------");
            User user = new User();
            Console.WriteLine("     Nombre: \n");
            Console.WriteLine("     Apellidos: \n");
            Console.WriteLine("     Correo: \n");
            Console.WriteLine("     Telefono: \n");
            Console.WriteLine("     Sexo: \n");
            Console.WriteLine("     Fecha de cumpleaño: \n");
            Console.WriteLine("     Usuario: \n");
            Console.WriteLine("     password: \n");
            menus.Button(8, 18, "  Guardar  ", 0);
            menus.Button(30, 18, "  Cancelar ", 0);
            Console.SetCursorPosition(13, 2);
            user.Name = Console.ReadLine();
            Console.SetCursorPosition(16, 4);
            user.Surname = Console.ReadLine();
            Console.SetCursorPosition(13, 6);
            user.Email = Console.ReadLine();
            Console.SetCursorPosition(15, 8);
            user.Telephone = Console.ReadLine();
            Console.SetCursorPosition(11, 10);
            user.Sex = Convert.ToChar(Console.ReadLine());
            Console.SetCursorPosition(25, 12);
            user.Birthday = Console.ReadLine();
            Console.SetCursorPosition(14, 14);
            user.Users = Console.ReadLine();
            Console.SetCursorPosition(15, 16);
            user.Password = Console.ReadLine();

            initial_Register = menus.MoveButton(8, 18, 30, nameButton);
           
            if (initial_Register == 1)
            {
                Console.Clear();
                Console.Write("     Digite El codigo de su empresa: ");
                user.AddId(int.Parse(Console.ReadLine()));
                cinema.AddUser(user);
            }
            Console.Clear();
            Console.WriteLine("     Presione cualquier tecla para Terminar...");
            Console.ReadKey();



        }
        static void MenuCustomer(string users) {
            int option_menu;
            string[] menu1 = { "Ver Cartelera", "Ver Tienda", "Comprar Boletos", "Comprar Golosinas", "Logout" };
            Console.Clear();          
            do{
                option_menu = menus.MenuInitial(menu1, "Bienvenido " + users + " - Usuario cliente");
                switch (option_menu){
                    case 1:
                        cinema.ShowMovies();
                        break;
                    case 2: cinema.ShowSnack();
                        break;
                    case 3:
                        BuyMovieTicket();
                        break;
                    case 4:
                        BuySnack();
                        break;
                }
                Console.WriteLine("\n     Presione cualquier tecla para Terminar...");
                Console.ReadKey();
                Console.Clear();
            } while (option_menu != menu1.Length);

        }

        static void BuyMovieTicket() {
            int id, room,y=4;
            double MovieTicket = 0,money;
            DateTime dateTime = DateTime.Now;

            Console.Clear();
            Console.WriteLine("     Bienvenido a la compra de Boletos");
            Console.Write("\n     Por favor Digite el ID de la pelicula: ");
            do {
                Console.SetCursorPosition(44, 2);
                Console.WriteLine("     ");
               Console.SetCursorPosition(44, 2);
                id = int.Parse(Console.ReadLine());
            } while (id<1||id>cinema.movies.Count);
            
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID: {0}                                   ", cinema.movies[id - 1].IDMovie);
            Console.WriteLine("     Nombre: {0}", cinema.movies[id - 1].Name);
            Console.WriteLine("     Tipo: {0}", cinema.movies[id - 1].Type);
            Console.WriteLine("     Duracion: {0}", cinema.movies[id - 1].Duration);
            Console.SetCursorPosition(33, 2);
            Console.WriteLine("Digite la sala:");
            Console.SetCursorPosition(36, 3);
            Console.WriteLine("1. Estandar");
            Console.SetCursorPosition(36, 4);
            Console.WriteLine("2. Premium");
            Console.SetCursorPosition(36, 5);
            Console.WriteLine("3. VIP");
            do {
                Console.SetCursorPosition(52, 2);
                Console.WriteLine("    ");
                Console.SetCursorPosition(52, 2);
                room = int.Parse(Console.ReadLine());
            } while (room<1||room>3);

            Console.SetCursorPosition(36, 4);
            Console.WriteLine("            ");
            Console.SetCursorPosition(36, 5);
            Console.WriteLine("           ");
            switch (room)
            {
                case 1:
                    MovieTicket = Standard();
                    break;
                case 2:
                    MovieTicket = Premium();
                    break;
                case 3:
                    MovieTicket = VIP();
                    break;
            }
            Console.SetCursorPosition(0,0);
            Console.WriteLine("                       TICKET DE COMPRA - CINE KODIMAX");
            Console.WriteLine("     |¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|");
            Console.WriteLine("     | Detalle de Funcion                                                |");
            Console.WriteLine("     |-------------------------------------------------------------------|");
            Console.WriteLine("     | ID: {0}", cinema.movies[id - 1].IDMovie);
            Console.WriteLine("     | Nombre: {0}", cinema.movies[id - 1].Name);
            Console.WriteLine("     | Tipo: {0}", cinema.movies[id - 1].Type);
            Console.WriteLine("     | Duracion: {0}", cinema.movies[id - 1].Duration);
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("Detalle de Compra");
            do
            {
                id = random.Next(cinema.users.Count);
            } while (cinema.users[id].Id != 1);
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("     |-------------------------------------------------------------------|");
            Console.WriteLine("     | Detalles empleado");
            Console.WriteLine("     | ID: {0}   Nombre: {1} {2}", id, cinema.users[id].Name, cinema.users[id].Surname );
            Console.WriteLine("     |                                              {0}", dateTime);
            Console.WriteLine("      ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(73, y);
                Console.WriteLine("|");
                y++;
            }

            do {
                
                Console.SetCursorPosition(5, 15);
                Console.Write("Digite la cantidad a pagar, debe se mayor que ${0} ", MovieTicket);
                Console.SetCursorPosition(5, 16);
                Console.Write("         ");
                Console.SetCursorPosition(5, 16);
                money = Convert.ToDouble(Console.ReadLine());

            } while (money< MovieTicket);
            if (money == MovieTicket) Console.WriteLine("     Cobro exacto, gracias por comprar en KODIMAX");
            else Console.WriteLine("     Su cambio es ${0}, gracias por comprar en KODIMAX.", money - MovieTicket);



        }
        static double Standard() {
            int boletos=0;
            double subTotal;
            cinema.movies[0].roomStandar.PrintRoom(5, 7);
            Console.SetCursorPosition(33, 2);
            int disponibles = cinema.movies[0].roomStandar.Disponibles;
            Console.Write("Boletos Disponibles: {0}", disponibles);
            if (disponibles > 0)
            {
                do
                {
                    Console.SetCursorPosition(33, 3);
                    Console.Write("Cantidad de boletos: ");
                    Console.SetCursorPosition(54, 3);
                    Console.Write("     ");
                    Console.SetCursorPosition(54, 3);
                    boletos = int.Parse(Console.ReadLine());
                } while (boletos < 1 || boletos > disponibles);

                cinema.movies[0].roomStandar.MoveCursor(8, 7, boletos);
                cinema.movies[0].roomStandar.printComprados();
            }
            else {
                Console.SetCursorPosition(33, 3);
                Console.Write("Boletos para la sala Estandar agotados!!!!!");
            }
            subTotal = cinema.movies[0].roomStandar.Price * boletos;
            subTotal = Math.Round(subTotal, 2);
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Sala: Estandar");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("N° de entradas: {0}", boletos);
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Precio: ${0}", cinema.movies[0].roomStandar.Price);
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Subtotal: ${0}", subTotal);
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("TAX: ${0}", Math.Round((subTotal) * 0.3533));
            Console.SetCursorPosition(35, 7);
            Console.WriteLine("Total: ${0}", Math.Round(((subTotal) * 0.3533) + subTotal));
            return Math.Round(((subTotal) * 0.3533) + subTotal);
        }
        static double Premium()
        {
            int boletos=0;
            double subTotal;
            cinema.movies[0].roomPremium.PrintRoom(5, 7);
            Console.SetCursorPosition(33, 2);
            int disponibles = cinema.movies[0].roomPremium.Disponibles;
            Console.Write("Boletos Disponibles: {0}", disponibles);
            if (disponibles > 0)
            {
                    do
                {
                    Console.SetCursorPosition(33, 3);
                    Console.Write("Cantidad de boletos: ");
                    Console.SetCursorPosition(54, 3);
                    Console.Write("     ");
                    Console.SetCursorPosition(54, 3);
                    boletos = int.Parse(Console.ReadLine());
                } while (boletos < 1 || boletos > disponibles);

                cinema.movies[0].roomPremium.MoveCursor(8, 7, boletos);
                cinema.movies[0].roomPremium.printComprados();
            }
            else
            {
                Console.SetCursorPosition(33, 3);
                Console.Write("Boletos para la sala Premium agotados!!!!!");
            }
            subTotal = cinema.movies[0].roomPremium.Price * boletos;
            subTotal = Math.Round(subTotal, 2);
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Sala: Premium");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("N° de entradas: {0}", boletos);
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Precio: ${0}", cinema.movies[0].roomPremium.Price);           
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Subtotal: ${0}", subTotal);
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("TAX: ${0}", Math.Round((subTotal) * 0.3533));
            Console.SetCursorPosition(35, 7);
            Console.WriteLine("Total: ${0}", Math.Round(((subTotal) * 0.3533) + subTotal));
            return Math.Round(((subTotal) * 0.3533) + subTotal);
        }
        static double VIP()
        {
            int boletos=0;
            double subTotal;
            cinema.movies[0].roomVIP.PrintRoom(5, 7);
            Console.SetCursorPosition(33, 2);
            int disponibles = cinema.movies[0].roomVIP.Disponibles;
            Console.Write("Boletos Disponibles: {0}", disponibles);
            if (disponibles > 0)
            {
                do
                {
                    Console.SetCursorPosition(33, 3);
                    Console.Write("Cantidad de boletos: ");
                    Console.SetCursorPosition(54, 3);
                    Console.Write("     ");
                    Console.SetCursorPosition(54, 3);
                    boletos = int.Parse(Console.ReadLine());
                } while (boletos < 1 || boletos > disponibles);

                cinema.movies[0].roomVIP.MoveCursor(8, 7, boletos);
                cinema.movies[0].roomVIP.printComprados();
            }
            else {
                Console.SetCursorPosition(33, 3);
                Console.Write("Boletos para la sala VIP agotados!!!!!");
            }
            subTotal = cinema.movies[0].roomVIP.Price * boletos;
            subTotal = Math.Round(subTotal, 2);
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Sala: VIP");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("N° de entradas: {0}", boletos);
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("Precio: ${0}", cinema.movies[0].roomVIP.Price);
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Subtotal: ${0}", subTotal);
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("TAX: ${0}", Math.Round((subTotal) * 0.3533));
            Console.SetCursorPosition(35, 7);
            Console.WriteLine("Total: ${0}", Math.Round(((subTotal) * 0.3533) + subTotal));
            return Math.Round(((subTotal) * 0.3533) + subTotal);
        }
        static void BuySnack() {
            int id,cantidad,idEmployee, y=4;
            
            double subtotal,money;
            DateTime dateTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine("     Bienvenido a la compra de Golosinas");
            Console.Write("\n     Por favor Digite el ID de la golosina: ");
            do {
                Console.SetCursorPosition(44,2);
                Console.WriteLine("     ");
               Console.SetCursorPosition(44, 2);
                id = int.Parse(Console.ReadLine());
            } while (id<1||id>cinema.snacks.Count);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID: {0}                                   ", cinema.movies[id - 1].IDMovie);
            Console.WriteLine("     Nombre: {0}", cinema.snacks[id - 1].Name);
            Console.WriteLine("     Tipo: {0}", cinema.snacks[id - 1].Type);
            Console.WriteLine("     Precio: {0}", cinema.snacks[id - 1].Price);
            Console.Write("\n     Cantidad: ");
            cantidad = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("                       TICKET DE COMPRA - CINE KODIMAX");
            Console.WriteLine("     |¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|");
            Console.WriteLine("     | Detalle de Compra           Detalles de Empleado                  |");
            Console.WriteLine("     |-------------------------------------------------------------------|");
            Console.WriteLine("     | Cantidad: {0}", cantidad);
            Console.WriteLine("     | Nombre: {0}", cinema.snacks[id - 1].Name);
            Console.WriteLine("     | Tipo: {0}", cinema.snacks[id - 1].Type);
            Console.WriteLine("     | Precio: ${0}\n     |", cinema.snacks[id - 1].Price);
            subtotal = cinema.snacks[id - 1].Price * cantidad;
            Console.WriteLine("     | Subtotal: ${0}", Math.Round (subtotal,2));
            Console.WriteLine("     | Impuesto: ${0}", Math.Round (subtotal*0.0453,2));
            subtotal = subtotal + (subtotal * 0.0453);
            Console.WriteLine("     | Total: ${0}", Math.Round(subtotal, 2));
            Console.WriteLine("      ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            for (int i = 0; i < 8; i++) {
                Console.SetCursorPosition(73, y);
                Console.WriteLine("|");
                y++;
            }
            do {
                idEmployee = random.Next(cinema.users.Count);
            } while (cinema.users[idEmployee].Id!=1);
            Console.SetCursorPosition(30, 4);
            Console.WriteLine("     ID Empleado: {0}",id);
            Console.SetCursorPosition(30, 5);
            Console.WriteLine("     Nombre Empleado: {0} {1}", cinema.users[id].Name, cinema.users[id].Surname);
            Console.SetCursorPosition(30, 6);
            Console.WriteLine("     Fecha: {0}", dateTime);


            do
            {

                Console.SetCursorPosition(5, 15);
                Console.Write("Digite la cantidad a pagar, debe se mayor que ${0} ", subtotal);
                Console.SetCursorPosition(5, 16);
                Console.Write("         ");
                Console.SetCursorPosition(5, 16);
                money = Convert.ToDouble(Console.ReadLine());

            } while (money < subtotal);
            if (money == subtotal) Console.Write("     Cobro exacto, gracias por comprar en KODIMAX");
            else Console.Write("     Su cambio es ${0}, gracias por comprar en KODIMAX.", Math.Round( money - subtotal));

        }
        static void MenuEmployee(string users) {
            int option_menu;
            string[] menu1 = { "Modificar Cartelera", "Modificar Tienda", "Logout" };
            Console.Clear();
            do
            {
                option_menu = menus.MenuInitial(menu1, "Bienvenido " + users + " - Usuario Empleado");
                switch (option_menu)
                {
                    case 1:
                        TicketOffice(users);
                        break;
                    case 2:
                        Candy(users);
                        break;                  

                }
                Console.WriteLine("Presione cualquier tecla para Terminar...");
                Console.ReadKey();
                Console.Clear();
            } while (option_menu != menu1.Length);
        }
        static void TicketOffice(string users) {
            int y;
            int option_menu;
            string[] menu1 = { "Agregar/Eliminar Peliculas", "Modificar sala", "Salir" };
            do {
                Console.Clear();
            option_menu = menus.MenuInitial(menu1, "Bienvenido " + users + " - Usuario Empleado");

            if (option_menu == 1)
            {
                do
                {
                    Console.Clear();
                    cinema.ShowMovies();
                    y = menus.MoveMenu(4, cinema.movies.Count,"pelicula");
                    if ((y - 3) < cinema.movies.Count)
                        cinema.movies.RemoveAt(y - 3);
                    if ((y - 3) == cinema.movies.Count)
                        addMovies();
                    

                } while ((y - 3) != cinema.movies.Count + 1);
                Console.SetCursorPosition(0, cinema.movies.Count + 6);
                Console.Write("Presiona cualquier tecla para continuar...");
            }
          
            if(option_menu == 2)
            {
                Console.Clear();
                int id;
                Console.WriteLine("     Modificar sala");
                Console.WriteLine("     ----------------------");
                Console.Write("     Digite id de la pelicula: ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("     Sala Estandar\n");
                Console.WriteLine("     Precio: \n");
                Console.WriteLine("     Sala Premium\n");
                Console.WriteLine("     Precio: \n");
                Console.WriteLine("     Sala VIP\n");
                Console.WriteLine("     Precio: \n");
                Console.SetCursorPosition(14, 5);
                cinema.movies[id - 1].roomStandar.Price = Convert.ToDouble(Console.ReadLine());
                Console.SetCursorPosition(14, 9);
                cinema.movies[id - 1].roomPremium.Price = Convert.ToDouble(Console.ReadLine());
                Console.SetCursorPosition(14, 13);
                cinema.movies[id - 1].roomVIP.Price = Convert.ToDouble(Console.ReadLine());
                Console.SetCursorPosition(5, 15);
                Console.Write("Presiona cualquier tecla para continuar...");
            }

            } while (option_menu != 3);

        }
        static void addMovies() {
            Console.Clear();
            Movie movie = new Movie();
            Console.WriteLine("     Agregar Pelicula");
            Console.WriteLine("     ----------------------");
            Console.WriteLine("     Nombre:\n");
            Console.WriteLine("     Duracion: \n");
            Console.WriteLine("     Tipo: \n");
            movie.IDMovie = cinema.movies.Count+1;
            Console.SetCursorPosition(14, 2);
            movie.Name = Console.ReadLine();
            Console.SetCursorPosition(15, 4);
            movie.Duration = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(11, 6);
            movie.Type = Console.ReadLine();
            cinema.AddMovies(movie);
        }
        static void Candy(string users) {
            int y;
            int option_menu;
            string[] menu1 = { "Agregar/Eliminar Golosinas", "Modificar Golosinas", "Salir" };
            do
            {
                Console.Clear();
                option_menu = menus.MenuInitial(menu1, "Bienvenido " + users + " - Usuario Empleado");

                if (option_menu == 1)
                {
                    do
                    {
                        Console.Clear();
                        cinema.ShowSnack();
                        y = menus.MoveMenu(4, cinema.snacks.Count,"Golosina");
                        if ((y - 3) < cinema.snacks.Count)
                            cinema.snacks.RemoveAt(y - 3);
                        if ((y - 3) == cinema.snacks.Count)
                            addSnack();

                    } while ((y - 3) != cinema.snacks.Count + 1);
                    Console.SetCursorPosition(0, cinema.snacks.Count + 6);
                    Console.Write("Presiona cualquier tecla para continuar...");
                }

                if (option_menu == 2)
                {
                    Console.Clear();
                    int id;
                    Console.WriteLine("     Modificar Golosina");
                    Console.WriteLine("     ----------------------");
                    Console.Write("     Digite id de la Golosina: ");
                    do {
                        Console.SetCursorPosition(31, 2);
                        Console.Write("     ");
                        Console.SetCursorPosition(31, 2);
                        id = int.Parse(Console.ReadLine());
                    } while (id > cinema.snacks.Count || id < 1);
                    Console.WriteLine("     Nombre: {0}",cinema.snacks[id-1].Name);
                    Console.WriteLine("     Tipo: ");
                    Console.WriteLine("     Precio: ");
                    
                    Console.SetCursorPosition(9, 4);
                    cinema.snacks[id-1].Type = Console.ReadLine();
                    Console.SetCursorPosition(13, 5);
                    cinema.snacks[id - 1].Price = Convert.ToDouble(Console.ReadLine());
                   
                    Console.SetCursorPosition(5, 8);
                    Console.Write("Presiona cualquier tecla para continuar...");
                }

            } while (option_menu != 3);
        }
        static void addSnack()
        {
            Console.Clear();
            Snack snack = new Snack();
            Console.WriteLine("     Agregar Golosina");
            Console.WriteLine("     ----------------------");
            Console.WriteLine("     Nombre:\n");            
            Console.WriteLine("     Tipo: \n");
            Console.WriteLine("     Precio: \n");
            snack.Id = cinema.snacks.Count + 1;
            Console.SetCursorPosition(14, 2);
            snack.Name = Console.ReadLine();
            Console.SetCursorPosition(15, 4);
            snack.Type = Console.ReadLine();
            Console.SetCursorPosition(11, 6);
            snack.Price = Convert.ToDouble( Console.ReadLine());
            cinema.AddSnack(snack);
        }
        static void MenuAdmin(string users) {
            int option_menu;
            string[] menu1 = { "Crear/Eliminar empleados ", "Modificar Cartelera", "Modificar Tienda", "Reportes", "Logout" };
            Console.Clear();
            do
            {
                option_menu = menus.MenuInitial(menu1, "Bienvenido " + users + " - Usuario Administrador");
                switch (option_menu)
                {
                    case 1:
                        ManageEmployees();
                    break;
                    case 2:
                        TicketOffice(users);
                        break;
                    case 3:
                        Candy(users);
                        break;
                    case 4:
                        GenerateJson();
                        break;

                }
                Console.WriteLine("Presione cualquier tecla para Terminar...");
                Console.ReadKey();
                Console.Clear();
            } while (option_menu != menu1.Length);
        }
        static void ManageEmployees() {
            int y,c;
            do
            {
                Console.Clear();
                c=cinema.ShowEmployes();
                y = menus.MoveMenu(4, c, "empleados");
                if ((y - 3) < c)
                    cinema.users.RemoveAt(cinema.userArray[y-3]);
                if ((y - 3) == c)
                    CheckIn();


            } while ((y - 3) != c + 1);
            Console.SetCursorPosition(0, cinema.users.Count + 6);
            Console.Write("Presiona cualquier tecla para continuar...");
        }
        static void GenerateJson() {
            char option;
            string json;
            Console.WriteLine("     Generar Reportes");
            Console.WriteLine("     ---------------------------");
            Console.WriteLine("     Opciones");
            Console.WriteLine("      U - Usuarios");
            Console.WriteLine("      G - Golosinas");
            Console.WriteLine("      C - Peliculas");
            Console.SetCursorPosition(6, 6);
            option = Convert.ToChar(Console.ReadLine());
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            switch (option) {
                case 'U': {
                        json = JsonConvert.SerializeObject(cinema.users.ToArray());
                        File.WriteAllText(fullPath+"\\Usuarios.json", json);
                    }
                    break;
                case 'C':
                    {
                        json = JsonConvert.SerializeObject(cinema.movies.ToArray());
                        File.WriteAllText(fullPath + "\\Peliculas.json", json);
                    }
                    break;
                case 'G':
                    {
                        json = JsonConvert.SerializeObject(cinema.snacks.ToArray());
                        File.WriteAllText(fullPath + "\\Golosinas.json", json);
                    }
                    break;

            }
            

            Console.WriteLine("     Reporte generado en  {0}", fullPath);
            Console.ReadKey();
        }
    }
}
