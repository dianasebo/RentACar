using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models {
    [Table("users")]
    public class User {
        [Required] [Column("id")] public int UserId { get; set; }
        [Required] [Column("lastname")] public string Lastname { get; set; }
        [Required] [Column("firstname")] public string Firstname { get; set; }
        [Column("city")] public string City { get; set; }
        [Column("address")] public string Address { get; set; }
    }
}
