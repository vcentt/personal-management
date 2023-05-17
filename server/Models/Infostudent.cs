using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Infostudent
{
    public int Studentid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public short? Numgroup { get; set; }

    public string? Bootcamp { get; set; }

    public bool? Isgraduated { get; set; }

    public string? Photo { get; set; }

    public string? Tps { get; set; }

    public string? English { get; set; }
}
