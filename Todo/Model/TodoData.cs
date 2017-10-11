using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Todo.Model
{
    public class TodoData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Item { get; set; }

        public bool Done { get; set; }

    }
}
