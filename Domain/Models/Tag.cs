﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DataSetId { get; set; }
        public DataSet? DataSet { get; set; }
    }
}