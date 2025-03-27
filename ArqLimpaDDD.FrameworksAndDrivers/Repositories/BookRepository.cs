using AutoMapper;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.FrameWrkDrivers.Data.Context;
using ArqLimpaDDD.FrameWrkDrivers.Repositories.Generic;

namespace ArqLimpaDDD.FrameWrkDrivers.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly DbSQLContext _context;
        public BookRepository(DbSQLContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
        IUnitOfWork UnitOfWork => _context;
    }
}
