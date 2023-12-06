using System;
using System.Collections.Generic;

namespace LibProject.Models;

public partial class Account
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Gmail { get; set; } = null!;

    public string Password { get; set; } = null!;
}
