using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
       readonly SPMEDICALGROUPContext context = new();

        public void AtualizarURL(int idEspecialidade, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = context.Especialidades.Find(idEspecialidade);

            if (especialidadeAtualizada.Especialidade1 != null)
            {
                especialidadeBuscada.Especialidade1 = especialidadeAtualizada.Especialidade1;

                context.Especialidades.Update(especialidadeBuscada);

                context.SaveChanges();
            }
        }

        public Especialidade BuscarPorID(int idEspecialidade)
        {
           return context.Especialidades.FirstOrDefault(es => es.IdEspecialidade == idEspecialidade);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            context.Especialidades.Add(novaEspecialidade);

            context.SaveChanges();
        }

        public List<Especialidade> ListarTodos()
        {
            return context.Especialidades.ToList();
        }

        public void Remover(int idEspecialidade)
        {
            context.Especialidades.Remove(BuscarPorID(idEspecialidade));

            context.SaveChanges();
        }
    }
}
