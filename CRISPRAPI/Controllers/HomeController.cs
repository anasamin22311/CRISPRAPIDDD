using System.Text;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRISPR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DNASequenceController : ControllerBase
    {
        private readonly ILogger<DNASequenceController> _logger;

        public DNASequenceController(ILogger<DNASequenceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to the DNA Sequence API");
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadSequence([FromForm] DNASequence model)
        {
            List<Domain.Models.Results> results = new List<Domain.Models.Results>();

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);

                if (model.File == null && string.IsNullOrEmpty(model.Sequence))
                {
                    return BadRequest("Please either paste a DNA sequence or upload a file, but not both.");
                }

                if (model.File != null)
                {
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    using (Stream stream = model.File.OpenReadStream())
                    {
                        StreamContent streamContent = new StreamContent(stream);
                        content.Add(streamContent, "file", model.File.FileName);

                        HttpResponseMessage response = await client.PostAsync("http://localhost:5000/fasta", content);
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResults = await response.Content.ReadAsStringAsync();
                            results = JsonConvert.DeserializeObject<List<Domain.Models.Results>>(jsonResults);
                        }
                        else
                        {
                            return StatusCode(500, "Something went wrong. Please try again.");
                        }
                    }
                }
                else
                {
                    var query = new { name = "Query", sequence = model.Sequence };
                    string json = JsonConvert.SerializeObject(query);
                    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/dna", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResults = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<List<Domain.Models.Results>>(jsonResults);
                    }
                    else
                    {
                        return StatusCode(500, "Something went wrong. Please try again.");
                    }
                }
            }

            return Ok(results);
        }
    }
}
