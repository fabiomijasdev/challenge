using CsvChallenge.Models;

namespace CsvChallenge.Repository
{
    public interface IPersonRepositoryDapper
    {
        Task<IEnumerable<Person>> GetAll();

        Task<Person> GetById(string Id);

        Task Create(Person person);

        Task Update(Person person);

        Task Delete(string Id);
    }
}
