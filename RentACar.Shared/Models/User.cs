using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models {
    [Table("users")]
    public class User {
        [Required] [Column("id")] public int UserId { get; set; }
        [Required] [Column("lastname")] public string Lastname { get; set; }
        [Required] [Column("firstname")] public string Firstname { get; set; }
        [Required] [Column("email")] public string Email { get; set; }
        [Required] [Column("password")] public string Password { get; set; }
        [Required] [Column("city")] public string City { get; set; }
        [Required] [Column("address")] public string Address { get; set; }
    }
}
