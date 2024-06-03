using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraftX.Class
{
    public class InternalMemos
    {
        [Key]
        public string MemoID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Writer { get; set; }

        [NotMapped]
        public int RowNumber { get; set; }
    }
}
