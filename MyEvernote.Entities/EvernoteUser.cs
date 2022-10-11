using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("EvernoteUsers")]
    public class EvernoteUser: MyEntityBase
    {
        [DisplayName("Ad"),
            StringLength(25,ErrorMessage ="{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("Soyad"),
            StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Surname { get; set; }
        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage ="Lütfen {0}nızı giriniz."), StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Username { get; set; }
        [DisplayName("e-Posta"),
            Required(ErrorMessage = "Lütfen {0}nızı giriniz."), StringLength(70, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Email { get; set; }
        [DisplayName("Parola"),
            Required(ErrorMessage = "Lütfen {0}nızı giriniz."), StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Password { get; set; }
        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }
        [DisplayName("Aktifmi")]
        public bool IsActive { get; set; }

        [DisplayName("Adminmi")]
        public bool IsAdmin { get; set; }
        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }
       
        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
