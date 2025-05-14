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
        [Required(ErrorMessage ="사용자 이름을 입력하세요.")] // not null 설정
        public required string  UserName { get; set; }

        [Required(ErrorMessage = "사용자 이름을 입력하세요.")]
        public required string UserId { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호을 입력하세요.")] // not null 설정
        public required string UserPassword { get; set; }

    }
}
