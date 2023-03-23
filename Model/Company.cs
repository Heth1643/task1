using System;
using System.Collections.Generic;

namespace Model;

public partial class Company
{
    public int CompId { get; set; }

    public string? CompName { get; set; }

    public string? ComRef { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Empdetail> Empdetails { get; } = new List<Empdetail>();
}
