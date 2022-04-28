using BlogPessoal.src.data;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]
        public void Inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;
            
            _contexto = new BlogPessoalContexto(opt);
        }


        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Karol Boaz";
            usuario.Email = "karol@email.com";
            usuario.Senha = "12345";
            usuario.Foto = "LinkFoto";

            _contexto.Usuarios.Add(usuario);

            _contexto.SaveChanges();// Commita criação

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "karol@email.com"));

        }
    }
}
