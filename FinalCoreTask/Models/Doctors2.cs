using System;
using System.Collections.Generic;

namespace FinalCoreTask.Models;

public partial class Doctors2
{
    public int Id { get; set; }

    public string? DoctorName { get; set; }

    public int? ClinicId { get; set; }

    public virtual Clinic? Clinic { get; set; }
}
