using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Framework.Models
{
    public class Ledighet
    {
        [Key]
        public int LedighetsId { get; set; }
        
        [Column(TypeName ="date")]
        public DateTime StartDatum { get; set; }

        [Column(TypeName = "date")]
        public DateTime SlutDatum { get; set; }
        public DateTime AppliedAtTime { get; set; }=DateTime.Now;
        public string LedighetsTyp { get; set; }

        [ForeignKey("PersonalId")]
        public int PersonalId { get; set; }
    }
}
