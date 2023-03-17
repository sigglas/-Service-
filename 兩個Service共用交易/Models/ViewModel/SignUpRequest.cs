using System.ComponentModel.DataAnnotations;

namespace 兩個Service共用交易.Models.ViewModel
{
    public class SignUpRequest
    {
        [Required]
        public string 帳號名稱 { get; set; } = null!;
        [Required]
        public string 密碼 { get; set; } = null!;
        [Required]
        public string 姓名 { get; set; } = null!;
        [Required]
        public string 推薦人 { get; set; } = null!;
    }
}
