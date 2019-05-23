using CensusDataDigitalization.DTO.DTOs;

namespace CensusDataDigitalization.BAL.Interfaces
{
    /// <summary>
    /// Interface For population Register BAC
    /// </summary>
    public interface IPopulationRegistrationBAL
    {
        PopulationRegistrationDTO AddPopulationBAL(PopulationRegistrationDTO population);

        PopulationRegistrationDTO GetPopulationRegistrationByIdBAL(int id);
    }
}
