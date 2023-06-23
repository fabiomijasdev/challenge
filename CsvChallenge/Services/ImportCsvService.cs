using CsvChallenge.Models;
using CsvChallenge.Repository;

namespace CsvChallenge.Services
{
    public class ImportCsvService : IImportCsvService
    {
        private readonly ICSVService _csvService;
        private readonly IPersonRepositoryEF _personRepositoryEF;
        public ImportCsvService(ICSVService csvService, IPersonRepositoryEF personRepositoryEF)
        {
            _csvService = csvService;
            _personRepositoryEF = personRepositoryEF;
        }

        public async Task ImportCSV(IFormFileCollection file)
        {
            try
            {
                var people = _csvService.ReadCSV<Person>(file[0].OpenReadStream());

                foreach (var person in people)
                {
                    var exist =  _personRepositoryEF.GetById(person?.Id);

                    if (exist == null)
                         _personRepositoryEF.Insert(person);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);                
            }            
        }
    }
}
