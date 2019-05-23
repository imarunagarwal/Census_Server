using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DTO.DTOs
{
    /// <summary>
    /// DTO for House Listing 
    /// </summary>
    public class HouseListingDTO
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
