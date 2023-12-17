using Domain.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRISPR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService )
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetAllModels()
        {
            var models = await _modelService.GetAllModelsAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            var model = await _modelService.GetModelAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Model>> CreateModel(Model model)
        {
            await _modelService.AddModelAsync(model);

            return CreatedAtAction(nameof(GetModel), new { id = model.id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, Model model)
        {
            if (id != model.id)
            {
                return BadRequest();
            }

            await _modelService.UpdateModelAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _modelService.DeleteModelAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadModel(int id)
        {
            if (id == null || await _modelService.EntitySetIsNullAsync())
            {
                return NotFound();
            }

            var model = await _modelService.GetModelAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            // Generate the PDF file
            model.FileURL = await _modelService.GeneratePdfFileAsync(model);

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