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
    public class MyEntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Giriş Zamanı"),Required, DisplayFormat(DataFormatString = "{0:dd/MM/yy hh:mm}")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Güncelleme Zamanı"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yy hh:mm}")]
        public DateTime ModifiedOn { get; set; }
        [DisplayName("Güncelleyen"), Required,StringLength(30)]
        public string ModifiedUsername { get; set; }
    }
}
