using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadData.Models
{
    public class Text :DbContext
    {
        [Key]
        public int  TextId { get; set; }
        public string Content { get; set; }
    }
}
