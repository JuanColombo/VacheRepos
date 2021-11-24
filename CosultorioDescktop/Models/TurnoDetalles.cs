using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsultorioDesktop.Models
{
    public class TurnoDetalles
    {
        public int Id { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }
    }
}
