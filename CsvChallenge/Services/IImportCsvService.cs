namespace CsvChallenge.Services
{
    public interface IImportCsvService
    {
        Task ImportCSV(IFormFileCollection file);
    }
}
