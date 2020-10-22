using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Room
    {
        public double Price { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public int[,] room;
        [JsonIgnore]
        public string[] comprados=new string[64];
        
        char[] letter = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        
        int index = 0;
        public int Disponibles { get; set; }
        
        public Room()
        {
        }

        public Room(double price, string type)
        {
            Price = price;
            Type = type;
           
        }
        public void AddRoom() {
           
            if (Type == "Estandar") room = new int[8, 8];
            else {
                if (Type == "Premium") room = new int[5, 5];
                else room = new int[5, 6];
            }            
            for (int i = 0; i < room.GetLength(0); i++) {
                for (int j = 0; j < room.GetLength(1); j++) {
                    room[i, j] = 1;
                }
            }
            Disponibles = room.Length;
        }
        public void PrintRoom(int x, int y) {
            int k = x;
          
            for (int i = 0; i < room.GetLength(0); i++)
            {
                Console.SetCursorPosition(k, y);
                Console.Write(" {0} ", letter[i]);
                for (int j = 0; j < room.GetLength(1); j++)
                {
                    if(room[i,j]==1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                    else Console.BackgroundColor = ConsoleColor.DarkYellow;
                    
                    Console.Write(" {0} ",(j+1));
                    Console.ResetColor();
                    Console.Write(" ");
                    
                }
                y += 2;
                k = x;
                
            }
        }
        public void MoveCursor(int xInitial,int yInitial,int number){
            ConsoleKeyInfo key;
            int x = xInitial, y = yInitial;
            int j;
            int i;

            //INFORMACION****************************************

            Console.SetCursorPosition(54, yInitial);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Informacion de la Sala {0}",Type);
            Console.ResetColor();
            Console.SetCursorPosition(50, yInitial+1);
            Console.Write("- Para moverse sobre los asientos, use las flechas.");
            Console.SetCursorPosition(50, yInitial + 2);
            Console.Write("- Para seleccionar la que desee, presiene ENTER.");
            Console.SetCursorPosition(50, yInitial + 3);
            Console.Write("- Los asientos disponibles son los de color Cyan");
            Console.SetCursorPosition(50, yInitial + 4);
            Console.Write("- Los asientos ocupados son los de color Amarillo");
            Console.SetCursorPosition(50, yInitial + 5);
            Console.Write("- La posicion actual se muestra de color verde");
            //*************************************************************
            while (jump(x, y)){
                x += 4;
                if (x > (room.GetLength(1) * 4) + 4)
                {
                    y += 2;
                    x = xInitial;
                }
                if (y >= (room.GetLength(0) * 2) + yInitial) y = yInitial;
            }
            j = (x - xInitial) / 4;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" {0} ", j+1);
            do {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow|| key.Key == ConsoleKey.LeftArrow ||
                    key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                    
                {
                    i = (y - yInitial) / 2;
                    j = (x - xInitial) / 4;
                    if (room[i, j] == 1) {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.SetCursorPosition(x, y);
                        Console.Write(" {0} ", j + 1);
                        Console.ResetColor();
                    }                    
                }
               
                if (key.Key == ConsoleKey.RightArrow) {                  
                  
                    do{
                        x += 4;
                        if (x > (room.GetLength(1) * 4) + 4){
                            y += 2;
                            x = xInitial;                            
                        }
                        if (y >= (room.GetLength(0) * 2) + yInitial) y = yInitial;
                    } while (jump(x, y)) ;
                }

                if (key.Key == ConsoleKey.LeftArrow) {
                   
                   do{
                        x -= 4;
                        if (x < xInitial)
                        {
                            y -= 2;
                            if (y < yInitial) y = (room.GetLength(0) * 2) + 5;
                            x = (room.GetLength(1) * 4) + 4;
                        }
                    } while (jump(x, y)) ;


                }
                if (key.Key == ConsoleKey.UpArrow) {
                 
                    do{
                        y -= 2;
                        if (y < yInitial)
                        {
                            y = (room.GetLength(0) * 2) + 5;
                            x -= 4;
                            if (x < xInitial) x = (room.GetLength(1) * 4) + 4;
                        }
                    } while (jump(x, y)) ;

                }

                if (key.Key == ConsoleKey.DownArrow) {
                  
                    do
                    {
                        y += 2;
                        if (y > (room.GetLength(0) * 2) + 5)
                        {
                            y = yInitial;
                            x += 4;
                            if (x >= (room.GetLength(1) * 4) + xInitial) x = xInitial;
                        }
                    } while (jump(x, y));
                }
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                j = (x - 8) / 4;
                i = (y - 7) / 2;
                Console.Write(" {0} ", j+1);
                if (key.Key == ConsoleKey.Enter) {                    
                   
                    Console.SetCursorPosition(x,y);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" {0} ", j+1);
                    if (room[i, j] == 1) {
                        number--;
                        Disponibles--;
                        comprados[index] = letter[i] + (j + 1).ToString();
                        index++;
                        ShoiceAsiento(i, j);
                    }

                }
               
            } while (key.Key != ConsoleKey.Enter || number>0);
            Console.ResetColor();
            Console.SetCursorPosition(5, (room.GetLength(0) * 2)+yInitial);
            Console.Write("Generando ticker... Presione cualquier letra para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public void ShoiceAsiento(int x, int y) {            
            room[x, y] = 0;
        }
        public bool jump(int x, int y) {
            int i = (y - 7) / 2;
            int j = (x - 8) / 4;
            return room[i, j] == 0;
        }
        public void printComprados() {
            Console.SetCursorPosition(5, 8);
            Console.Write("| Asientos: ");
            for (int i = 0; i < index; i++)
                Console.Write("{0}, ", comprados[i]);
            index = 0;
        }
    }
}
