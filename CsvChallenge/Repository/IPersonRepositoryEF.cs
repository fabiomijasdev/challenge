using CsvChallenge.Models;

namespace CsvChallenge.Repository
{
    public interface IPersonRepositoryEF
    {
        int Insert(Person person);

        Person GetById(string Id);

    }
}
