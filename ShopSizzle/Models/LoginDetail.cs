using System;
using System.Collections.Generic;

namespace ShopSizzle.Models;

public partial class LoginDetail
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long PhoneNo { get; set; }
}
