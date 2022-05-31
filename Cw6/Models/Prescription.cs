﻿using System;
namespace Cw6.Models
{
	public class Prescription
	{
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;
    }
}

