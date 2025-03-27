using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Interfaces.ConverterVO;

namespace ArqLimpaDDD.Domain.ValueObjects.ConverterVO
{
    public class BookConverter : IBook<BookVO, Book>, IBook<Book, BookVO>
    {
        public Book Book(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                author = origin.Author,
                launch_date = origin.Launch_Date,
                price = origin.Price,
                title = origin.title,
                createdat = origin.createdat,
                updatedat = origin.updatedat,
                deletedat = origin.deletedat
            };
        }
        public BookVO Book(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.author,
                Launch_Date = origin.launch_date,
                Price = origin.price,
                title = origin.title,
                createdat = origin.createdat,
                updatedat = origin.updatedat,
                deletedat = origin.deletedat
            };
        }

        public List<Book> Book(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Book(item)).ToList();
        }


        public List<BookVO> Book(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Book(item)).ToList();
        }
    }
}
