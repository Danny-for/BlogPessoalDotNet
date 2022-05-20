﻿using System.ComponentModel.DataAnnotations;
using BlogPessoal.src.utilidades;
namespace BlogPessoal.src.dtos
{

    /// <summary>
    /// <para>Resumo: Classe espelho para criar uma Autenticação</para>
    /// <para>Criado por: Dannyela Souza </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/04/2022</para>
    /// </summary>
    public class AutenticarDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public AutenticarDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar um Autenticação</para>
    /// <para>Criado por: Dannyela Souza </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/04/2022</para>
    /// </summary>

    public class AutorizacaoDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Token { get; set; }
        public AutorizacaoDTO(int id, string email, TipoUsuario tipo, string
        token)
        {
            Id = id;
            Email = email;
            Tipo = tipo;
            Token = token;
        }
    }
}
