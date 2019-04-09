using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.DataModel;

namespace Books.Services
{
    public class BookServices : IBookServices
    {
        DAL _dal;
        public BookServices()
        {
            _dal = new DAL();
        }
        public IList<Book> GetBooks(BookCategories type) => _dal.GetBooks().Where(p => p.BookCategories == type).ToList();


        public IList<Book> GetBooks() => _dal.GetBooks().ToList();

        public IDictionary<int, string> GetBooksCategories<T>() => ((T[])Enum.GetValues(typeof(T))).ToDictionary(t => (int)(object)t, t => t.ToString());

        public dynamic GetBooksCategories<T>(int id)
        {
            var data = ((T[])Enum.GetValues(typeof(T))).ToDictionary(t => (int)(object)t, t => t.ToString()).FirstOrDefault(p => p.Key == id);
            return new { Id = data.Key, Value = data.Value };
          
        }
    }
}
