using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.Presentation.Models
{
    /// <summary>
    /// ViewModel for House Listing
    /// </summary>
    public class HouseListingViewModel
    {
        public int CensusHouseNoID { get; set; }

        public string BuildingNo { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string HeadFullName { get; set; }

        public HouseRentalStatus HouseStatus { get; set; }

        public int NoOfRooms { get; set; }
    }
}