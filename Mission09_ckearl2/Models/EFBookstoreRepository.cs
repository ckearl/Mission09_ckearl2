using System.Linq;

namespace Mission09_ckearl2.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository(BookstoreContext temp) => context = temp;
        public IQueryable<Book> Books => context.Books;
    }
}