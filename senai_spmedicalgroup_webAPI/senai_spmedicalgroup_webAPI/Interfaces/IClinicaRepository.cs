using senai_spmedicalgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> ListarTodos();

        Clinica BuscarPorID(int idClinica);
    }
}
