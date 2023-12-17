using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DNASequence
    {
        //[Required(ErrorMessage = "Either paste a DNA sequence or upload a file.")]
        public string? Sequence { get; set; }

        public string? FileName { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}