using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNote.Api.Data
{
    public class NoteBook
    {
        public int Id { get; set; }

        [Required,MaxLength(10)]
        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
