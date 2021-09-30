using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Agendamento
    {
        public int IdAgendamento { get; set; }
        public short? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime? DatahoraConsulta { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
