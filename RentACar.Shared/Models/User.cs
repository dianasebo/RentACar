using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public IEnumerable<Message> ReceivedMessages { get; set; }
        [JsonIgnore]
        public IEnumerable<Message> SentMessages { get; set; }

        public override bool Equals(object obj) => obj is User && UserId.Equals(((User) obj).UserId);
        
        public override int GetHashCode() => UserId.GetHashCode();
    }
}
