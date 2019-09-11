using System.IO;
using System.Collections.Generic;
using WebApi.Model;
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
        
        public void AddBook(Book book)
        {
            JsonDeserializer();
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

        public void UpdateBook(int index, Book book)
        {
            JsonDeserializer();            
            BookList[index].Id = book.Id;
            BookList[index].Name = book.Name;
            BookList[index].Price = book.Price;
            BookList[index].Author = book.Author;
            BookList[index].Category = book.Category;
            JsonSerializer();
        }

        public void DeleteBook(Book book)
        {
            JsonDeserializer();
            BookList.Remove(book);
            JsonSerializer();
        }

    }
}
