using System;
using System.Collections.Generic;

namespace ShopSizzle.Models;

public partial class AdminLogin
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
