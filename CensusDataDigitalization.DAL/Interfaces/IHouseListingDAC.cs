using CensusDataDigitalization.DTO.DTOs;

namespace CensusDataDigitalization.DAL.Interfaces
{
    /// <summary>
    /// Interface For House Listing DAC Card
    /// </summary>
    public interface IHouseListingDAC
    {
        HouseListingDTO GetHouseListingByIdDAL(int id);

        HouseListingDTO AddHouseListingDAL(HouseListingDTO houseListingDTO);
    }
}
