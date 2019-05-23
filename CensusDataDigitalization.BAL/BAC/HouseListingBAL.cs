using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DAL.DAC;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;

namespace CensusDataDigitalization.BAL
{
    public class HouseListingBAL : IHouseListingBAL
    {
        private IHouseListingDAC houseListingDAC;

        public HouseListingBAL(IHouseListingDAC _houseListingDAC)
        {
            this.houseListingDAC = _houseListingDAC;
        }

        /// <summary>
        /// Gets the Details of House By unique ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HouseListingDTO GetHouseListingByIdBAL(int id)
        {
            HouseListingDTO houseListingDTO = houseListingDAC.GetHouseListingByIdDAL(id);

            return houseListingDTO;
        }

        /// <summary>
        /// Posts the House Data to DAC from Controller
        /// </summary>
        /// <param name="houseListingDTO"></param>
        /// <returns></returns>
        public HouseListingDTO AddHouseListingBAL(HouseListingDTO houseListingDTO)
        {
            HouseListingDTO houseListingCreated = houseListingDAC.AddHouseListingDAL(houseListingDTO);
            return houseListingCreated;
        }

    }
}
