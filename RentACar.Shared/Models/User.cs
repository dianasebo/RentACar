using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models
{
    [Table("users")]
    public class User
    {
        [Required] [Column("id")] public int UserId { get; set; }
        [Required] [Column("email")] public string Email { get; set; }
        [Required] [Column("lastname")] public string Lastname { get; set; }
        [Required] [Column("firstname")] public string Firstname { get; set; }
        [Required] [Column("admin")] public bool IsAdmin { get; set; } = false;
        [Column("city")] public string City { get; set; }
        [Column("address")] public string Address { get; set; }
        public ICollection<Car> Cars { get; set; }
        public IEnumerable<Message> ReceivedMessages { get; set; }
        public IEnumerable<Message> SentMessages { get; set; }
    }
}
