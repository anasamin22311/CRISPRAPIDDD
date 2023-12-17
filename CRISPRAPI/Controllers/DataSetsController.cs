using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;

namespace CRISPR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DataSetsController : ControllerBase
    {
        private readonly IDataSetService _dataSetService;

        public DataSetsController(IDataSetService dataSetService)
        {
            _dataSetService = dataSetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataSet>>> GetAllDataSets()
        {
            var dataSets = await _dataSetService.GetAllDataSetsAsync();
            return Ok(dataSets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataSet>> GetDataSet(int id)
        {
            var dataSet = await _dataSetService.GetDataSetAsync(id);

            if (dataSet == null)
            {
                return NotFound();
            }

            return Ok(dataSet);
        }

        [HttpPost]
        public async Task<ActionResult<DataSet>> CreateDataSet(DataSet dataSet)
        {
            await _dataSetService.AddDataSetAsync(dataSet);

            return CreatedAtAction(nameof(GetDataSet), new { id = dataSet.id }, dataSet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataSet(int id, DataSet dataSet)
        {
            if (id != dataSet.id)
            {
                return BadRequest();
            }

            await _dataSetService.UpdateDataSetAsync(dataSet);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataSet(int id)
        {
            await _dataSetService.DeleteDataSetAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadDataSet(int id)
        {
            if (id == null || await _dataSetService.EntitySetIsNullAsync())
            {
                return NotFound();
            }

            var model = await _dataSetService.GetDataSetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            // Generate the PDF file
            model.FileURL = await _dataSetService.GeneratePdfFileAsync(model);

            // Set up the file download
            var memory = new MemoryStream();
            using (var stream = new FileStream(model.FileURL, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            string fileName = $"DataSet_{model.id}.pdf";
            return File(memory, "application/pdf", fileName);
        }
    }
}
