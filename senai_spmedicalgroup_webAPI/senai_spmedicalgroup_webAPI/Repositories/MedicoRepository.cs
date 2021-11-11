using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        readonly SPMEDICALGROUPContext context = new();
        public void AtualizarURL(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = context.Medicos.Find(idMedico);

            if (medicoAtualizado.NomeMedico != null || medicoAtualizado.SobrenomeMedico != null || medicoAtualizado.Crm != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                medicoBuscado.SobrenomeMedico = medicoBuscado.SobrenomeMedico;
                medicoBuscado.Crm = medicoBuscado.Crm;

                context.Medicos.Update(medicoBuscado);

                context.SaveChanges();
            }
        }

        public Medico BuscarPorID(int idMedico)
        {
            return context.Medicos
                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    Crm = m.Crm,
                    NomeMedico = m.NomeMedico,
                    SobrenomeMedico = m.SobrenomeMedico,
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        Especialidade1 = m.IdEspecialidadeNavigation.Especialidade1
                    },
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = m.IdClinicaNavigation.NomeClinica,
                        Cnpj = m.IdClinicaNavigation.Cnpj,
                        RazaoSocial = m.IdClinicaNavigation.RazaoSocial,
                        EnderecoClinica = m.IdClinicaNavigation.EnderecoClinica
                    },
                })
                .FirstOrDefault(s => s.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            context.Medicos.Add(novoMedico);

            context.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return context.Medicos
                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    Crm = m.Crm,
                    NomeMedico = m.NomeMedico,
                    SobrenomeMedico = m.SobrenomeMedico,
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        Especialidade1 = m.IdEspecialidadeNavigation.Especialidade1
                    },
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = m.IdClinicaNavigation.NomeClinica,
                        Cnpj = m.IdClinicaNavigation.Cnpj,
                        RazaoSocial = m.IdClinicaNavigation.RazaoSocial,
                        EnderecoClinica = m.IdClinicaNavigation.EnderecoClinica
                    },
                })
                .OrderBy(m => m.IdMedico)
                .ToList();

        }

        public void Remover(int idMedico)
        {
            context.Medicos.Remove(BuscarPorID(idMedico));

            context.SaveChanges();
        }
    }
}
