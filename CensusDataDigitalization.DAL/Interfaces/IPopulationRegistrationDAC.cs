using CensusDataDigitalization.DTO.DTOs;

namespace CensusDataDigitalization.DAL.Interfaces
{
    public interface IPopulationRegistrationDAC
    {
        PopulationRegistrationDTO AddPopulationDAL(PopulationRegistrationDTO populationRegistrationDTO);

        PopulationRegistrationDTO GetPopulationRegistrationByIdDAL(int id);
    }
}
