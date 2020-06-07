using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace W3
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void WeatherData()
        {
            while(true)
            {
                try 
                {
                    Console.WriteLine("╔════════════╤══════════════════════════════╗");
                    Console.WriteLine("   Hot key   │            Function       ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      A      │          Add product  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      S      │     Search product by name  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      D      │     Delete product by name ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      T      │         Show products  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("    Space    │         Clear console  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("     Esc     │          Exit program  ");
                    Console.WriteLine("╚════════════╧══════════════════════════════╝");

                    var data = JsonConvert.DeserializeObject<List<Tickets_shop>>(File.ReadAllText(FilePath));

                    int menuselect = 0;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            menuselect = 1;
                            break;
                        case ConsoleKey.S:
                            menuselect = 2;
                            break;
                        case ConsoleKey.T:
                            menuselect = 3;
                            break;
                        case ConsoleKey.Escape:
                            menuselect = 4;
                            break;
                        case ConsoleKey.D:
                            menuselect = 5;
                            break;
                    }

                    if (menuselect == 1)
                    {
                        Console.Clear();

                        Console.WriteLine("Enter ticket info\n");
                        Console.WriteLine("Ticket count");
                        string cnt = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Film: ");
                        string film = Console.ReadLine();
                        Console.WriteLine("Price: ");
                        string price = Console.ReadLine();
                        Console.WriteLine("Adge: ");
                        string age = Console.ReadLine();

                        if (cnt != null && name != null && film != null && price != null && age != null)
                        {
                            data.Add(new Tickets_shop { tickCount = cnt, Name = name, Film = film, Price = price, Age = age });
                        }
                        else
                        {
                            Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                        }
                        Console.Clear();
                    }

                    if (menuselect == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter film name: ");
                        string name = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Tickets_shop FoundData = data.Find(found => found.Name == name);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("    Count    │    Name    │   Film   │    Price    │      Adge");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,9} {1, 13} {2, 12} {3, 9} {4, 12}", FoundData.tickCount, FoundData.Name, FoundData.Film, FoundData.Price, FoundData.Age);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                                Console.WriteLine("\nTo edit press 'E'");
                                Console.WriteLine("\n\nTo edit press 'D'");
                                if (Console.ReadKey().Key == ConsoleKey.E)
                                {

                                    Console.WriteLine("Edit ticket info\n");
                                    Console.WriteLine("Ticket count");
                                    string cnt = Console.ReadLine();
                                    Console.WriteLine("Name: ");
                                    string namE = Console.ReadLine();
                                    Console.WriteLine("Film: ");
                                    string film = Console.ReadLine();
                                    Console.WriteLine("Price: ");
                                    string price = Console.ReadLine();
                                    Console.WriteLine("Adge: ");
                                    string age = Console.ReadLine();

                                    if (cnt == null || namE == null || film == null || price == null || age == null)
                                    {
                                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                    }
                                    FoundData.tickCount = cnt;
                                    FoundData.Name = namE;
                                    FoundData.Film = film;
                                    FoundData.Price = price;
                                    FoundData.Age = age;
                                    Console.Clear();
                                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                    Console.WriteLine("    Count    │    Name    │   Film   │    Price    │      Adge");
                                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                    Console.WriteLine("{0,9} {1, 13} {2, 12} {3, 9} {4, 12}", FoundData.tickCount, FoundData.Name, FoundData.Film, FoundData.Price, FoundData.Age);
                                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                }
                                if (Console.ReadKey().Key == ConsoleKey.D)
                                {
                                    data.RemoveAll(x => x.Name == name);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "Fi not found");
                            }
                             
                            
                        }
                    }

                    if (menuselect == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("    Count    │    Name    │   Film   │    Price    │      Adge");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        for (int i = 0; i < data.Count; i++)
                        {
                            Console.WriteLine("{0,9} {1, 13} {2, 12} {3, 9} {4, 12}", data[i].tickCount, data[i].Name, data[i].Film, data[i].Price, data[i].Age);
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");

                        }
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        Console.WriteLine("\nTo sort by count press 'S'");
                        if (Console.ReadKey().Key == ConsoleKey.S)
                        {

                            Console.Clear();
                            List<Tickets_shop> SortData = data.OrderBy(o => o.tickCount).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Count    │    Name    │   Film   │    Price    │      Age");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,9} {1, 13} {2, 12} {3, 9} {4, 12}", SortData[i].tickCount, SortData[i].Name, SortData[i].Film, SortData[i].Price, SortData[i].Age);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }
                    }

                    if (menuselect == 4)
                    {
                        Environment.Exit(0);
                    }

                    if (menuselect == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter city to delete: ");
                        string name = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Tickets_shop FoundData = data.Find(found => found.Name == name);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("    Count    │    Name    │   Film   │    Price    │      Adge");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,9} {1, 13} {2, 12} {3, 9} {4, 12}", FoundData.tickCount, FoundData.Name, FoundData.Film, FoundData.Price, FoundData.Age);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                data.RemoveAll(x => x.Name == name);
                                Console.WriteLine("This information has been deleted");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "City not found");
                            }


                        }
                    }

                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }

                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Close();
                        }
                        File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                
            } 
        }
        static void Main(string[] args)
        {
            WeatherData();
        }
    }

    public class Tickets_shop
    {
        public string tickCount { get; set;}
        public string Name { get; set; }
        public string Film { get; set; }
        public string Price { get; set; }
        public string Age { get; set; }

    }
}
