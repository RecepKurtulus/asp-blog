using System.ComponentModel.DataAnnotations;
using BuffBlog.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BuffBlog.Models
{
    public class RegisterViewModel
    {
        public int? UserId { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2} karakter uzunluğunda olmalıdır.",MinimumLength =1)]
        [Display(Name ="Username")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name ="UserMail")]
        public string? UserMail { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2} karakter uzunluğunda olmalıdır.",MinimumLength =6)]

        [Display(Name ="UserHash")]
        public string? UserHash { get; set; }
        [Required]
        [Compare(nameof(UserHash),ErrorMessage ="Parola eşleşmiyor 🧐")]
        [Display(Name ="Parola Tekrar")]
        public string? ConfirmPassword { get; set; }

        public string? UserSalt { get; set; }
        [Required]
        [Display(Name ="UserPp")]
        public string? UserPp { get; set; }

        public string? UserBio { get; set; }
    }
}
