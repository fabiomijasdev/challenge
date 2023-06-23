using CsvChallenge.Models;

namespace CsvChallenge.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(string id);
        Task Create(Person person);
        Task Update(string id, Person person);
        Task Delete(string id);
    }
}
