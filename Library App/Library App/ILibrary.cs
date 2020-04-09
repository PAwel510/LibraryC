using System.Collections.Generic;

namespace Library_App
{
    interface ILibrary
    {
        public List<Book> Search(string searchedPhrase);
    }
}
