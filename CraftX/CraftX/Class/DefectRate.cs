using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CraftX.Class
{
    public class DefectRate
    {
        [Key]
        public string ID { get; set; }
        public string ProductName { get; set; }
        public int DefectCount { get; set; }
        public int TotalCount { get; set; }
        public Decimal Rate { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}
