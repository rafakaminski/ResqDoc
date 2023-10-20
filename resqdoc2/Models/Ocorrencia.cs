using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using resqdoc2.Enums;

namespace resqdoc2.Models
{
    namespace ResqDoc.Models
    {

        [Table("OcorrenciaTabela")]
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
            public DateOnly Data { get; set; } 

            [NotMapped]
            public string DataFormatada => Data.ToString("dd/MM/yyyy"); //formatação da data para impressão

            [Display(Name = "Cobrade")]
            [Column("CobradeId")] // Renomeie para CobradeId para representar a chave estrangeira
            public int CobradeId { get; set; }

            [Display(Name = "Cobrade")]
            public Cobrade Cobrade { get; set; }
        }
    }

}
