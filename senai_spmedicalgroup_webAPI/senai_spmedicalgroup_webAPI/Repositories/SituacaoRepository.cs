using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        readonly SPMEDICALGROUPContext context = new();
        public Situacao BuscarPorID(int idSituacao)
        {
            return context.Situacaos
                .Select(s => new Situacao
                {
                    IdSituacao = s.IdSituacao,
                    Descricao = s.Descricao,
                })
                .FirstOrDefault(s => s.IdSituacao == idSituacao);
        }

        public List<Situacao> ListarTodos(int idSituacao)
        {
            return context.Situacaos
                .Select(s => new Situacao
                {
                    IdSituacao = s.IdSituacao,
                    Descricao = s.Descricao,
                })
                .ToList();
        }
    }
}
