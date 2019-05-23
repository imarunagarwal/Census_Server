using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DAL.DAC;

namespace CensusDataDigitalization.BAL
{
    /// <summary>
    /// Population BAC
    /// </summary>
    public class PopulationRegistrationBAL : IPopulationRegistrationBAL
    {
        private IPopulationRegistrationDAC populationDAC;

        public PopulationRegistrationBAL(IPopulationRegistrationDAC _populationRegistrationDAC)
        {
            this.populationDAC = _populationRegistrationDAC;
        }

        /// <summary>
        /// Passes the data from Controller to DAC For the population.
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        public PopulationRegistrationDTO AddPopulationBAL(PopulationRegistrationDTO population)
        {
            PopulationRegistrationDTO populationCreated = populationDAC.AddPopulationDAL(population);
            return populationCreated;
        }

        /// <summary>
        /// Passes the data from DAC to Controller for a person with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PopulationRegistrationDTO GetPopulationRegistrationByIdBAL(int id)
        {
            PopulationRegistrationDTO populationDTO = populationDAC.GetPopulationRegistrationByIdDAL(id);

            return populationDTO;
        }
    }
}
