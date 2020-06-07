using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Models
{
    public class DisplayServiceModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [StringLength(120, ErrorMessage = "Last Description is too long.")]
        public string Description { get; set; }

        [Required]
        public decimal Fee { get; set; }
    }
}
