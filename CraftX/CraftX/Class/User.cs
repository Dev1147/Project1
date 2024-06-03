using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraftX.Class
{
    public class User
    {
        [Key]
        [MinLength(6, ErrorMessage = "사용자 아이디는 6자 이상 입력하세요.")]
        [Display(Name = "사용자 아이디")]
        [Required(ErrorMessage = "아이디 필드는 필수입니다.")]
        public string USERID { get; set; }

        [MinLength(4, ErrorMessage = "사용자 닉네임 4자 이상 입력하세요.")]
        [Display(Name = "사용자 닉네임")]
        [Required(ErrorMessage = "닉네임 필드는 필수입니다.")]
        public string NICKNAME { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "이메일 필드는 필수입니다.")]
        public string EMAIL { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "비밀번호 필드는 필수입니다.")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; } // 보안을 위해 해시된 비밀번호로 저장해야 함


        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "비밀번호 확인 필드는 필수입니다.")]
        [Compare("PASSWORD", ErrorMessage = "비밀번호가 일치하지 않습니다.")] // 에러 메시지 수정
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public DateTime JOINDATE { get; set; } = DateTime.Now; // 현재 날짜로 초기화

        public UserRole USERAUTH { get; set; } = 0; // 기본값으로 일반 사용자 할당

        [NotMapped]
        public string? PROFILEPICTUREPATH { get; set; } // 파일 경로 저장

        [NotMapped]
        public int RowNumber { get; set; }
    }

    public enum UserRole
    {
        일반 = 0,
        관리자 = 1
    }

}
