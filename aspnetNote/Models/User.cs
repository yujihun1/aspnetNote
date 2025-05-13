using System.ComponentModel.DataAnnotations;

namespace aspnetNote.Models
{
    public class User
    { 
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key] // pk 설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름      
        /// </summary>
        [Required] // not null 설정
        public String  UserName { get; set; }

        [Required]
        public String UserId { get; set; }

        [Required]
        public String UserPassword { get; set; }

    }
}
