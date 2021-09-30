using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Agendamentos = new HashSet<Agendamento>();
            Usuarios = new HashSet<Usuario>();
        }

        public short IdMedico { get; set; }
        public short? IdEspecialidade { get; set; }
        public byte? IdClinica { get; set; }
        public string NomeMedico { get; set; }
        public string SobrenomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
