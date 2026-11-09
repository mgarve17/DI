using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónIncidenciasTécnicas
{
    public class Incidencia
    {
        public string titulo { get; set; } = "";
        public string categoria { get; set; } = "";
        public String prioridad { get; set; } = "";
        public int TiempoEstimado { get; set; } = 0;
        public string estado { get; set; } = "PENDIENTE";
    }
}
