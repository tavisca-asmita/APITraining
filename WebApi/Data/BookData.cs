using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebApi.Data
{
    public class BookData
    {
        public List<Book> BookList { get; set; }

        private void InitializeBookList()
        {
            BookList = new List<Book>();            
        }

        private void JsonSerializer()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\assharma\source\repos\APITraining\BookList.json"))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("BookList");
                serializer.Serialize(writer, BookList);
                writer.WriteEndObject();
            }
        }

        private void JsonDeserializer()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader file = File.OpenText(@"C:\Users\assharma\source\repos\APITraining\BookList.json"))
            {
                BookData bookData = (BookData)serializer.Deserialize(file, typeof(BookData));
                if (bookData != null)
                    this.BookList = bookData.BookList;
                else
                    this.BookList = null;
            }
        }

        public List<Book> GetBookList()
        {
            JsonDeserializer();
            return BookList;
        }

        public Book GetBookById(int id)
        {
            JsonDeserializer();
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void AddBook(Book book)
        {
            if (BookList == null)
                InitializeBookList();
            BookList.Add(book);
            JsonSerializer();            
        }

        public int CheckIfBookExists(Book book)
        {
            JsonDeserializer();
            foreach(var item in BookList)
            {
                if (item.Id == book.Id)
                    return 0;
            }
            AddBook(book);
            return 1;                           
        }

        public int UpdateBook(int id, Book book)
        {
            JsonDeserializer();
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    item.Id = book.Id;
                    item.Name = book.Name;
                    item.Price = book.Price;
                    item.Author = book.Author;
                    item.Category = book.Category;
                    JsonSerializer();
                    return 1;
                }
            }
            return 0;
        }

        public int DeleteBook(int id)
        {
            JsonDeserializer();
            foreach (var item in BookList)
            {
                if (item.Id == id)
                {
                    BookList.Remove(item);
                    JsonSerializer();
                    return 1;
                }                
            }
            return 0;            
        }

    }
}
