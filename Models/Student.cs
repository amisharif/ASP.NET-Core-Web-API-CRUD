using System;
using System.Collections.Generic;

namespace ASP.NET_Core_WebAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Dept { get; set; }

    public string? Gender { get; set; }
}
