using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCity.WebAPI.Models
{
    [Table("ENDERECO")]
    public class EnderecoModel
    {
        [Key]
        [Column("END_ID", TypeName = "NUMBER(10,0)")]
        public int Id { get; set; }

        [Column("END_DATA_CADASTRO", TypeName = "TIMESTAMP(6)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Column("END_LOGRADOURO", TypeName = "VARCHAR2(255 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Column("END_BAIRRO", TypeName = "VARCHAR2(255 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string Bairro { get; set; }

        [Column("END_NUMERO", TypeName = "VARCHAR2(25 CHAR)")]
        [MaxLength(25)]
        public string Numero { get; set; }

        [Column("END_CIDADE", TypeName = "VARCHAR2(255 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [Column("END_COMPLEMENTO", TypeName = "VARCHAR2(25 CHAR)")]
        [MaxLength(25)]
        public string Complemento { get; set; }

        [Column("END_ESTADO", TypeName = "VARCHAR2(100 CHAR)")]
        [MaxLength(100)]
        public string Estado { get; set; }

        [Column("END_CEP", TypeName = "VARCHAR2(10 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Column("END_PAIS", TypeName = "VARCHAR2(100 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Pais { get; set; }

        [Column("END_LATITUDE", TypeName = "FLOAT")]
        public decimal? Latitude { get; set; }

        [Column("END_LONGITUDE", TypeName = "FLOAT")]
        public decimal? Longitude { get; set; }

        [Column("END_NIVEL_PRECISAO", TypeName = "NUMBER(10,0)")]
        public int? Precisao { get; set; }
    }
}
