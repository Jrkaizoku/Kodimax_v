using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Menus
    {
        string[] nameButton = { "   Login   ", "   Salir   " };
        string[] menuInitial = { "Login", "Registarse", "Salir" };

        public Menus()
        {
        }
        public void Button(int x, int y, string type, int color)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" _______________");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|");
            if (color == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("  {0}  ", type);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("|");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");


        }
        public void Login()
        {
            Console.Clear();
            int y = 3;
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("_______________________________________________");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("_______________________________________________");

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(14, y);
                Console.WriteLine("|");
                Console.SetCursorPosition(62, y);
                Console.WriteLine("|");
                y++;
            }

            Console.SetCursorPosition(20, 5);
            Console.Write("Usuario: ");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Password: ");

            Button(19, 9, "   Login   ", 0);
            Button(40, 9, "   Salir   ", 0);

        }
        public int MoveButton(int x, int y, int x2, string[] nameButton)
        {
            ConsoleKeyInfo key;
            int initial_position = 1;
            Button(x, y, nameButton[0], 1);
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (initial_position > 1) initial_position = 0;
                    initial_position += 1;

                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (initial_position < 1) initial_position = 2;
                    initial_position -= 1;
                }
                if (initial_position == 1)
                {
                    Button(x, y, nameButton[0], 1);
                    Button(x2, y, nameButton[1], 0);

                }
                else
                {
                    Button(x, y, nameButton[0], 0);
                    Button(x2, y, nameButton[1], 1);
                }

            } while (key.Key != ConsoleKey.Enter);
            Console.SetCursorPosition(5, 13);
            return initial_position;
        }

        public int MenuInitial(string[] menu, string title)
        {
            int m;
            Console.WriteLine("         ____________________________________________");
            Console.WriteLine("        /\\                                     	     \\");
            Console.WriteLine("        \\_| {0}", title);
            Console.SetCursorPosition(53, 2);
            Console.WriteLine("|");
            Console.WriteLine("          | KODIMAX MENÚ - Seleccione una opcion     |\n");
            int y = 4;
            for (int i = 0; i < menu.Length + 2; i++)
            {
                Console.SetCursorPosition(53, y);
                Console.WriteLine("|");
                Console.SetCursorPosition(10, y);
                Console.WriteLine("|");

                y++;
            }
            y = 5;
            Console.SetCursorPosition(0, 4);
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(15, y);
                Console.WriteLine("{0}.  {1}", i + 1, menu[i]);
                y++;

            }
            Console.SetCursorPosition(11, y);
            Console.WriteLine("  ________________________________________|_");
            Console.SetCursorPosition(10, y + 1);
            Console.WriteLine("\\_/_________________________________________/");
            do
            {
                Console.SetCursorPosition(10, y + 3);
                Console.WriteLine("           ");
                Console.SetCursorPosition(10, y + 3);
                m = int.Parse(Console.ReadLine());
            } while (m < 1 || m > menu.Length);

            Console.Clear();
            return m;
        }
        public int MoveMenu(int yInitial, int count,string type) {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("->>");
            Console.SetCursorPosition(60, 3);
            Console.WriteLine("- Mueva con las flechas arriba y abajo");
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("- Presione ENTER sobre la {0} para eliminar",type);
            Console.SetCursorPosition(60, 5);
            Console.WriteLine("- Presione ENTER sobre AGREGAR para agregar");
            Console.SetCursorPosition(60, 6);
            Console.WriteLine("- Presione ENTER sobre SALIR para salirse");
            ConsoleKeyInfo key;
            Console.SetCursorPosition(0, count + 3);
            Console.Write("     {0}  Agregar", count+1);

            Console.SetCursorPosition(0, count + 4);
            Console.Write("     {0}  Salir", count + 2);
            int y = 3;
            do
            {

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("   ");
                    y++;
                    if (y > count + yInitial) y = 3;
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine("->>");

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("   ");
                    y--;
                    if (y < 3) y = count + yInitial;
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine("->>");
                    if (y > count + yInitial) y = 3;
                }

            } while (key.Key != ConsoleKey.Enter);
            return y;
        }
    }
}
