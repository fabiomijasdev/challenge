using CsvChallenge.Models;
using CsvChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsvChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IImportCsvService _importCsvService;
        public PersonController(IPersonService personService, IImportCsvService importCsvService)
        {
            _personService = personService;
            _importCsvService = importCsvService;
        }

        [HttpPost("import-csv")]
        public async Task<IActionResult> ImportCsv([FromForm] IFormFileCollection file)
        {
            await _importCsvService.ImportCSV(file);

            return Ok("Csv successfully imported");
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _personService.GetById(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            await _personService.Create(person);

            return Ok("Successfully created");
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            await _personService.Update(person.Id, person);

            return Ok("Successfully Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _personService.Delete(id);

            return Ok("Successfully Deleted");
        }
    }
}