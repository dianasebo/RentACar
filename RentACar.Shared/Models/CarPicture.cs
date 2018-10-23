using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Shared.Models
{
    [Table("carpictures")]
    public class CarPicture
    {
        [Required] [Column("id")] public int CarPictureId { get; set; }
        [Required] [Column("car_id")] public int CarId { get; set; }
        [Required] [Column("picture")] public byte[] Picture { get; set; }

        public Car Car { get; set; }
    }
}