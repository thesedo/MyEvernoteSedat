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
    [Table("Notes")]
    public class Note : MyEntityBase
    {
        [DisplayName("Başlık"), Required(ErrorMessage = "Lütfen gönderinize bir {0} ekleyiniz."), StringLength(60,ErrorMessage = "{0} alanı {1} karakterden uzun olmamalıdır.")]
        public string Title { get; set; }
        [DisplayName("Metin"), Required(ErrorMessage = "Lütfen gönderinizi giriniz."), StringLength(1500, ErrorMessage = "Gönderiniz {1} karakterden uzun olmamalıdır.")]
        public string Text { get; set; }
        public string NoteImageFilename { get; set; }
        [DisplayName("Taslak")]
        public bool IsDraft { get; set; }
        [DisplayName("Beğeni Sayısı")]
        public int LikeCount { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }

        public virtual EvernoteUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }

        public Note()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();

        }

    }
}
