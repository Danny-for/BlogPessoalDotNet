﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.repositorios.implementacoes
{

    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ITema</para>
    /// <para>Criado por: Dannyela Souza</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    public class TemaRepositorio : ITema
    {
        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos


        #region Construtores

        public TemaRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores


        #region Métodos


        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos temas</para>
        /// </summary>
        /// <param>Pegar todos temas</param>
        /// <return>Lista TemaModelo</return>
        public async Task<List<TemaModelo>> PegarTodosTemasAsync()
        {
            return await _contexto.Temas.ToListAsync();
        }


        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um Temas pelo Id</para>
        /// </summary>
        /// <param temas ="id">Id do Tema</param>
        /// <return>TemaModelo</return>
        public async Task<TemaModelo> PegarTemaPeloIdAsync(int id)
        {
            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TemaModelo>> PegarTemasPelaDescricaoAsync(string descricao)
        {
            return await _contexto.Temas
                            .Where(u => u.Descricao.Contains(descricao))
                            .ToListAsync();
        }


        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo Tema</para>
        /// </summary>
        /// <param name = "tema" >NovoTemaDTO</param>

        public async Task NovoTemaAsync(NovoTemaDTO tema)
        {
            await _contexto.Temas.AddAsync(new TemaModelo
            {
                Descricao = tema.Descricao
            });

            await _contexto.SaveChangesAsync();
        }


        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar um usuario</para>
        /// </summary>
        /// <param name="tema">AtualizarUsuarioDTO</param>
        public async Task AtualizarTemaAsync(AtualizarTemaDTO tema)
        {
            var temaExistente = await PegarTemaPeloIdAsync(tema.Id);
            temaExistente.Descricao = tema.Descricao;
            _contexto.Temas.Update(temaExistente);
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um Tema pelo id</para>
        /// </summary>
        /// <param name = "id" >Id Tema</param>

        public async Task DeletarTemaAsync(int id)
        {
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        #endregion Métodos
    }
}
