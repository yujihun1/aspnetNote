using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aspnetNote.Models
{
    public class Note
    {
        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage ="제목을 입력하세요.")]
        public required string NoteTitle { get; set; }

        [Required(ErrorMessage = "내용을 입력하세요.")]
        public required string  NoteContents { get; set; }

        
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual required User? User { get; set; }
    }
}
