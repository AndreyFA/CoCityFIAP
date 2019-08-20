using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCity.WebAPI.Models
{
    [Table("RECLAMACAO")]
    public class ReclamacaoModel
    {
        [Key]
        [Column("REC_ID", TypeName = "NUMBER(10,0)")]
        public int Id { get; set; }

        [Column("REC_DATA_CADASTRO", TypeName = "TIMESTAMP(6)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Column("REC_DESCRICAO", TypeName = "VARCHAR2(2000 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(2000)]
        public string Descricao { get; set; }

        [Column("REC_TITULO", TypeName = "VARCHAR2(100 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Column("REC_TIPO_RECLAMACAO", TypeName = "VARCHAR2(100 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Tipo { get; set; }

        [Column("USU_ID", TypeName = "NUMBER(10,0)")]
        public int? UsuarioId { get; set; }

        [Column("END_ID", TypeName = "NUMBER(10,0)")]
        [JsonIgnore]
        public int? EnderecoId { get; set; }
    }
}
