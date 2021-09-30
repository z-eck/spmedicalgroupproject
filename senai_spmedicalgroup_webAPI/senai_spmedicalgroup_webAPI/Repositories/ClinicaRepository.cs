using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        readonly SPMEDICALGROUPContext context = new();
        public Clinica BuscarPorID(int idClinica)
        {
            return context.Clinicas
                .Select(c => new Clinica
                {
                    NomeClinica = c.NomeClinica,
                    Cnpj = c.Cnpj,
                    RazaoSocial = c.RazaoSocial,
                    EnderecoClinica = c.EnderecoClinica,
                })
                .FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public List<Clinica> ListarTodos(int idClinica)
        {
            return context.Clinicas
                .Select(c => new Clinica
                {
                    NomeClinica = c.NomeClinica,
                    Cnpj = c.Cnpj,
                    RazaoSocial = c.RazaoSocial,
                    EnderecoClinica = c.EnderecoClinica,
                })
                .ToList();
        }
    }
}
