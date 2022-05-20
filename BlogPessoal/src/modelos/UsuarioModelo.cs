using BlogPessoal.src.utilidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogPessoal.src.modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_usuario no banco.</para>
    /// <para>Criado por: Dannyela Souza </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 15/05/2022</para>
    /// </summary>

    [Table("tb_usuarios")]
    public class UsuarioModelo
    {
        //definindo coluna id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] //precisa colocar nome
        [StringLength(50)] 
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required,StringLength(30)]
        public string Senha { get; set; }


        public string Foto { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        [JsonIgnore, InverseProperty("Criador")]
        public List<PostagemModelo> MinhasPostagens { get; set; }

    }
}
