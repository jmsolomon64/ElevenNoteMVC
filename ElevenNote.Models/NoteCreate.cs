using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")] //sets error message if min is not met
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")] //sets error message if max is surpassed
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
