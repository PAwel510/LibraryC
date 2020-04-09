using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_App
{
    internal class Library : ILibrary
    {
        List<Book> books;
        readonly JsonParser jsonParser= new JsonParser(); 

        public Library()
        {
            this.books = jsonParser.LoadLibrary(@"C:\Users\pawel.tryniszewski\source\repos\Library App\Library App\Files\new2.json");
            this.jsonParser = new JsonParser();
        }

        internal List<Book> Books { get => books; set => books = value; }
        internal JsonParser JsonMapper { get => jsonParser; }


        public void AddBook(string title, string author, int iSBN)
        {
            books.Add(new Book (title, author, iSBN));
            
        }
        public void RemoveBook(int ISBN)
        {
            books.RemoveAll(x => x.ISBN == ISBN);
        }

        public List<Book> Search(string searchedPhrase)
        {
            return books.Where(oBook =>(oBook.Title.Contains(searchedPhrase) || oBook.Author.Contains(searchedPhrase))).ToList();
        }

        public Book Search(int searchedNumber)
        {
            return books.Where(oBook =>(oBook.ISBN==searchedNumber)).FirstOrDefault();   
        }

        public void FindClients()
        {
            var oSelectedPersons = (from oElement in books where oElement.BookBorrower != null
                                   select oElement.BookBorrower).GroupBy(i=>i);

            foreach (var grp in oSelectedPersons)
            {
                Console.WriteLine("{0} książki: {1}", grp.Key, grp.Count());
            }
        }

        public void BorrowBook(int searchedNumber,string name)
        {
            Book findBook = Search(searchedNumber);
            findBook.BookBorrower = name;
            findBook.LastRental = DateTime.Now;  
        }

        public List<Book> FindUnwanted(int weeks)
        {
            return books.Where(oBook =>(oBook.LastRental < DateTime.Now.AddDays(-7 * weeks))).ToList();
        }
    }
}
