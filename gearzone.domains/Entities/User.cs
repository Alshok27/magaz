<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;

namespace gearzone.domains.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public UserRole Role { get; set; } = UserRole.User;
}
=======
﻿namespace gearzone.domains.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
>>>>>>> 8db369f88395dac94fe0ae6c4a5a67b25aebcbc6
