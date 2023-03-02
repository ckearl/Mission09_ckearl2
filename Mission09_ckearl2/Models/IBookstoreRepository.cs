using System.Linq;

namespace Mission09_ckearl2.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}