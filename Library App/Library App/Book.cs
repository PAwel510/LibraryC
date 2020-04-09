using System;

namespace Library_App
{
    class Book
    {
        private string _title;
        private string _author;
        private string _bookBorrower;
        private int _ISBN;
        private DateTime _lastRental;

        public override string ToString()
        {
            return _title+" " + _author + " " + _bookBorrower + " " + _ISBN + " " +_lastRental;
        }

        public Book(){}
        public Book(string title, string author, string bookBorrower, int iSBN, DateTime lastRental) : this(title, author, bookBorrower, iSBN)
        {
            _lastRental = lastRental;
        }
        public Book(string title, string author, string bookBorrower, int iSBN)
        {
            _title = title;
            _author = author;
            _bookBorrower = bookBorrower;
            _ISBN = iSBN;
        }
        public Book(string title, string author, int iSBN)
        {
            _title = title;
            _author = author;
            _ISBN = iSBN;
        }

        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public string BookBorrower { get => _bookBorrower; set => _bookBorrower = value; }
        public int ISBN { get => _ISBN; set => _ISBN = value; }
        public DateTime LastRental { get => _lastRental; set => _lastRental = value; }
    }
}
