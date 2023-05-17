using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Personalstudent
{
    public int Studentid { get; set; }

    public string? Adress { get; set; }

    public string? Phonenumber { get; set; }

    public byte[]? Contract { get; set; }

    public int? Id { get; set; }

    public virtual Infostudent Student { get; set; } = null!;
}
