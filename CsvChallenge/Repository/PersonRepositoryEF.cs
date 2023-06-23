using CsvChallenge.Database;
using CsvChallenge.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CsvChallenge.Repository
{
    public class PersonRepositoryEF : IPersonRepositoryEF
    {
        private readonly EFDataContext _context;

        public PersonRepositoryEF(EFDataContext context)
        {
            _context = context;
        }

        public Person GetById(string id)
        {
            return _context.Set<Person>().FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Person person)
        {
            _context.Person.Add(person);
            return _context.SaveChanges();
        }
    }
}
