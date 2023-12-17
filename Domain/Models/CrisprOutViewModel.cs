using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CrisprOutViewModel
    {
        public string? Name { get; set; }
        public string Details { get; set; }
        public string? Sequence { get; set; }
        public string? Location { get; set; }
        public string? GRNA { get; set; }
    }
}