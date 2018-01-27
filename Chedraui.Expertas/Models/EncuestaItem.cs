using System;

namespace Chedraui.Expertas
{
    public class EncuestaItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Premio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Invitadas { get; set; }
        public int Respuestas { get; set; }
    }
}
