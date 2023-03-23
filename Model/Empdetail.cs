using System;
using System.Collections.Generic;

namespace Model;

public partial class Empdetail
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public bool? PriEmp { get; set; }

    public bool? Isactive { get; set; }

    public int? Cid { get; set; }

    public virtual Company? CidNavigation { get; set; }
}
