using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using resqdoc2.Enums;

namespace resqdoc2.Models
{
    namespace ResqDoc.Models
    {

        [Table("OcorrenciaTbl")]
        public class Ocorrencia
        {
            [Display(Name = "Código")]
            [Column("Id")]
            public int Id { get; set; }

            [Display(Name = "Título")]
            [Column("Título")]
            public string Titulo { get; set; }

            [Display(Name = "Gravidade")]
            [Column("Gravidade")]
            public GravidadeEnum Gravidade { get; set; }

            [Display(Name = "Data")]
            [Column("Data")]
            public DateTime DateOnly { get; set; }

            [Display(Name = "Cobrade")]
            [Column("Cobrade")]
            public int Cobrade { get; set; }
        }
    }

}
