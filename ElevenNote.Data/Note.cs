using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        //Annotations used to check ModelState for controller and service layers
        [Key]
        public int NoteId { get; set; } //key will generate a unique Id

        [Required] //guid stands for global unique identifier 
        public Guid OwnerId { get; set; } //sql doesn't recognize Guid data type and will convert it to string in data table

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; } //DateTimeOffset will adjust to local timezones 

        public DateTimeOffset UpdatedUtc { get; set; } //? means that property can be null
    }
}
