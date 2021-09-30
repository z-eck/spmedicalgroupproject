using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedicalgroup_webAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public byte IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
