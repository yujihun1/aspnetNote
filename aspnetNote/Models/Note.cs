using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetNote.Models
{
    public class Note
    {
        [Key]
        public int NnoteNo { get; set; }

        [Required]
        public String NoteTitle { get; set; }

        [Required]
        public String  NoteContents { get; set; }

        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User user { get; set; }
    }
}
