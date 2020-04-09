using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library_App
{
    class JsonParser
    {
        public void UpdateLibrary(List<Book> books)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(@"C:\Users\pawel.tryniszewski\source\repos\Library App\Library App\Files\new2.json", jsonString);
        }

        public List<Book> LoadLibrary(string filePath)
        {
            List<Book> books = new List<Book>();
            string jsonString = File.ReadAllText(filePath);
            books=JsonSerializer.Deserialize<List<Book>>(jsonString);
            return books;
        }
    }
}
