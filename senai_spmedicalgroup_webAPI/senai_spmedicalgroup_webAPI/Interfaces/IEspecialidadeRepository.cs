using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> ListarTodos(int idEspecialidade);

        Especialidade BuscarPorID(int idEspecialidade);

        void Cadastrar(Especialidade novaEspecialidade);

        void AtualizarURL(int idEspecialidade, Especialidade especialidadeAtualizada);

        void Remover(int idEspecialidade);
    }
}
