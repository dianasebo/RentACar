using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models
{
    [Table("cars")]
    public class Car
    {
        [Required] [Column("id")] public int CarId { get; set; }
        [Required] [Column("user_id")] public int UserID { get; set; }
        [Required] [Column("brand")] public string Brand { get; set; }
        [Required] [Column("model")] public string Model { get; set; }
        [Required] [Column("year")] public int Year { get; set; }
        [Required] [Column("engine")] public EngineType Engine { get; set; }
        [Required] [Column("transmission")] public TransmissionType Transmission { get; set; }
        [Required] [Column("seats")] public int Seats { get; set; }
        [Required] [Column("ac")] public bool Ac { get; set; }
        [Required] [Column("price")] public float Price { get; set; }
        public User User { get; set; }
        public ICollection<CarPicture> Pictures { get; set; }

    }
}
