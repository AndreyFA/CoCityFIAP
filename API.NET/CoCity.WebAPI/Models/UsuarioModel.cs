using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoCity.WebAPI.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {
        [Key]
        [Column("USU_ID", TypeName = "NUMBER(10,0)")]
        public int Id { get; set; } = 0;

        [Column("USU_DATA_CADASTRO", TypeName = "TIMESTAMP(6)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Column("USU_NOME", TypeName = "VARCHAR2(80 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Column("USU_SOBRENOME", TypeName = "VARCHAR2(80 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(80)]
        public string Sobrenome { get; set; }

        [Column("USU_DATA_NASCIMENTO", TypeName = "TIMESTAMP(6)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Column("USU_EMAIL", TypeName = "VARCHAR2(200 CHAR)")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Email { get; set; }

        [Column("USU_SENHA", TypeName = "VARCHAR2(40 CHAR)")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(40)]
        public string Senha { get; set; }

        [Column("USU_CELULAR", TypeName = "VARCHAR2(25 CHAR)")]
        [MaxLength(25)]
        public string NumeroCelular { get; set; }

        [Column("USU_DATA_ULTIMO_ACESSO", TypeName = "TIMESTAMP(6)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataUltimoAcesso { get; set; } = DateTime.Now;

        [Column("END_ID", TypeName = "NUMBER(10,0)")]
        public int? EnderecoId { get; set; }
    }
}
