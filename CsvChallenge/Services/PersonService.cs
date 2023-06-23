using CsvChallenge.Models;
using CsvChallenge.Repository;

namespace CsvChallenge.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepositoryDapper _personRepositoryDapper;

        public PersonService(IPersonRepositoryDapper personRepositoryDapper)
        {
            _personRepositoryDapper = personRepositoryDapper;
        }

        public async Task Create(Person person)
        {
            await _personRepositoryDapper.Create(person);
        }

        public async Task Delete(string id)
        {
            await _personRepositoryDapper.Delete(id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personRepositoryDapper.GetAll();
        }

        public async Task<Person> GetById(string id)
        {
            return await _personRepositoryDapper.GetById(id);
        }

        public async Task Update(string id, Person person)
        {
            var entity = await _personRepositoryDapper.GetById(id);

            if (entity == null)
                throw new KeyNotFoundException("Person not found");

            await _personRepositoryDapper.Update(person);
        }
    }
}
