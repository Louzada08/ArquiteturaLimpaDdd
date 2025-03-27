using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.FrameWrkDrivers.Data.Context;
using ArqLimpaDDD.FrameWrkDrivers.Repositories.Generic;

namespace ArqLimpaDDD.FrameWrkDrivers.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly DbSQLContext _context;
        public PersonRepository(DbSQLContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
        IUnitOfWork UnitOfWork => _context;

        public async Task<Person> Disable(long id)
        {
            if (!await _context.Persons.AnyAsync(p => p.Id.Equals(id))) return null;
            var person = await _context.Persons.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (person != null)
            {
                person.Enabled = false;

                try
                {
                    _context.Entry(person).CurrentValues.SetValues(person);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
            }

            return person;
        }
    }
}
