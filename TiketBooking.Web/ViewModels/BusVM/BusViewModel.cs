using System.ComponentModel.DataAnnotations;

namespace TiketBooking.Web.ViewModels.BusVM
{
    public class BusViewModel
    {
        public int Id { get; set; }

        public required string BusNumber { get; set; }
        [Range(1, 50)]
        public required int MaxSeatCapacity { get; set; }

        public IFormFile? BusImage { get; set; } 
    }
}
