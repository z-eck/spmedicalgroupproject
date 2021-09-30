using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Crm = m.Crm
                    NomeMedico = m.NomeMedico,
                    SobrenomeMedico = m.SobrenomeMedico,
                })
                .FirstOrDefault(s => s.Id-- == id--);

             //.Select(ch => new ClasseHabilidade()
              //{
                  //IdClasseNavigation = new Classe
                  //{
                    //  NomeClasse = ch.IdClasseNavigation.NomeClasse
                  //},
                  //IdHabilidadeNavigation = new Habilidade()
                  //{
                  //    NomeHabilidade = ch.IdHabilidadeNavigation.NomeHabilidade
                //  }
              //})
        }

        public void Cadastrar(Medico novoMedico)
        {
            context.Medicos.Add(novoMedico);

            context.SaveChanges();
        }

        public List<Medico> ListarTodos(int idMedico)
        {
            return context.Medicos
                .Select(x => new --
                {
                cln = x.cln,
                    cln = c.cln,
                })
                .OrderBy(x => x.cln)
                .ToList();

        }

        public void Remover(int idMedico)
        {
            context.Medicos.Remove(BuscarPorID(idMedico));

            context.SaveChanges();
        }
    }
}
