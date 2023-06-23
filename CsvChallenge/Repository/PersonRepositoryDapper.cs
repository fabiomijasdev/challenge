using CsvChallenge.Database;
using CsvChallenge.Models;
using Dapper;

namespace CsvChallenge.Repository
{
    public class PersonRepositoryDapper : IPersonRepositoryDapper
    {
        private readonly DapperDataContext _context;

        public PersonRepositoryDapper(DapperDataContext context)
        {
            _context = context;
        }

        public async Task Create(Person person)
        {
            using var connection = _context.CreateConnection();
            var sql = "INSERT INTO Person (Id,FullName, BirthDate) VALUES (@Id, @FullName, @BirthDate)";
            await connection.ExecuteAsync(sql, person);
        }

        public async Task Delete(string Id)
        {
            using var connection = _context.CreateConnection();
            var sql = "DELETE FROM Person WHERE Id = @Id";

            await connection.ExecuteAsync(sql, new { Id });
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT Id, FullName, BirthDate FROM Person";

            return await connection.QueryAsync<Person>(sql);
        }

        public async Task<Person> GetById(string Id)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT Id, FullName, BirthDate FROM Person  WHERE Id = @Id";

            return await connection.QuerySingleOrDefaultAsync<Person>(sql, new { Id });
        }

        public async Task Update(Person person)
        {
            using var connection = _context.CreateConnection();
            var sql = "UPDATE Person SET FullName = @FullName, BirthDate = @BirthDate WHERE Id = @Id";
            await connection.ExecuteAsync(sql, person);
        }
    }
}
