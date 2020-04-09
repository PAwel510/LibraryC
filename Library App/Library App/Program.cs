using System;
using System.Threading;

namespace Library_App
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            Library library = new Library();


            var button ="";  
            do
            {
                Console.WriteLine("\n1.List Books\n\n2.Add Book \n\n3.Remove Book\n\n" +
                    "4.Find Book\n\n5.Others\n\nq to exit");
                button= Console.ReadLine();
                switch (button)
                {
                    case "1":
                        Console.Clear();
                        
                        foreach (var item in library.Books)
                        {
                            Console.WriteLine("{0}  {1} Nr: {2}",item.Title,item.Author,item.ISBN);
                        }
                        Thread.Sleep(1000);
                        break;
                    case "2":
                        
                        Console.WriteLine("Title?");
                        var a = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Author?");
                        var b = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Serial number?");
                        var c = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        
                        library.AddBook(a,b,c);
                        library.JsonMapper.UpdateLibrary(library.Books);
                        break;
                    case "3":
                        Console.WriteLine("Type number");
                        library.RemoveBook(Convert.ToInt32(Console.ReadLine()));
                        Console.Clear();
                        library.JsonMapper.UpdateLibrary(library.Books);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Type Title or Author.");
                        foreach (var item in library.Search(Convert.ToString(Console.ReadLine())))
                        {
                            Console.WriteLine("{0}  {1} Nr: {2}", item.Title, item.Author, item.ISBN);
                            
                        }
                        Thread.Sleep(500);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("\n6.Search by ISBN\n\n7.Client List \n\n8.Find Unwanted\n\n" +
                            "9.Borrow\n\n0.Back");
                        switch (Convert.ToString(Console.ReadLine()))
                        {
                            case "6":
                                Console.Clear();
                                Console.WriteLine("Type ISBN.");
                                Console.WriteLine(library.Search(Convert.ToInt32(Console.ReadLine())).ToString()); 

                                break;
                            case "7":
                                Console.Clear();
                                library.FindClients();

                                break;
                            case "8":
                                Console.Clear();
                                Console.WriteLine("Search for books that have not been borrowed for the last X weeks? \n\n" +
                                    "How many weeks back?");
                                foreach (var item in library.FindUnwanted(Convert.ToInt32(Console.ReadLine())))
                                {
                                    Console.WriteLine(item.ToString());
                                } 

                                break;
                            case "9":
                                Console.Clear();
                                Console.WriteLine("Book number?");
                                var number= Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("To whom ?");
                                var name = Convert.ToString(Console.ReadLine());

                                library.BorrowBook(number, name);
                                library.JsonMapper.UpdateLibrary(library.Books);
                                break;
                            case "0":
                                Console.Clear();
                                break;
                        }
                        
                        break;
                    case "":
                        Console.Clear();
                        break;  
                }
            } while (button != "q");
        }   
    }      
}          
