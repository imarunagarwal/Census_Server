using CensusDataDigitalization.DTO.DTOs;

namespace CensusDataDigitalization.BAL.Interfaces
{
    /// <summary>
    /// Interface For House BAC
    /// </summary>
    public interface IHouseListingBAL
    {
        HouseListingDTO GetHouseListingByIdBAL(int id);

        HouseListingDTO AddHouseListingBAL(HouseListingDTO houseListingDTO);
    }
}
