using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónIncidenciasTécnicas
{
    internal class Incidencia
    {
        private string titulo { get; set; } = "";
        private string categoria { get; set; } = "";
        private String prioridad { get; set; } = "";
        private int TiempoEstimado { get; set; } = 0;
        private string estado { get; set; } = "PENDIENTE";
    }
}
