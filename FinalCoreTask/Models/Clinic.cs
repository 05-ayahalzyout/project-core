using System;
using System.Collections.Generic;

namespace FinalCoreTask.Models;

public partial class Clinic
{
    public int Id { get; set; }

    public string? ClinicName { get; set; }

    public string? ClinicImage { get; set; }

    public virtual ICollection<Doctors2> Doctors2s { get; } = new List<Doctors2>();
}
