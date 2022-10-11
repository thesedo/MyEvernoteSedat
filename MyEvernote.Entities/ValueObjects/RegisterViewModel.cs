using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Ad"),
            Required(ErrorMessage = "{0} alanı boş geçilmez.")]
        public string Name { get; set; }
        [DisplayName("Soyad"),
            Required(ErrorMessage = "{0} alanı boş geçilmez.")]
        public string Surname { get; set; }
        [DisplayName("Kullanıcı Adı"), 
            Required(ErrorMessage = "{0} alanı boş geçilmez."), 
            StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Username { get; set; }
        [DisplayName("E-Posta"), 
            Required(ErrorMessage = "{0} alanı boş geçilmez."), 
            StringLength(70, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır."),
            EmailAddress(ErrorMessage ="{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        [DisplayName("Şifre"), 
            Required(ErrorMessage = "{0} alanı boş geçilmez."), 
            DataType(DataType.Password), 
            StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar"), 
            Required(ErrorMessage = "{0} alanı boş geçilmez."), 
            DataType(DataType.Password), 
            StringLength(25, ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır."),
            Compare("Password",ErrorMessage ="{1} ile {0} eşleşmedi.Lütfen tekrar deneyin.")]
        public string RePassword { get; set; }

    }
}