using CensusDataDigitalization.DTO.DTOs;
using System.Collections.Generic;

namespace CensusDataDigitalization.BAL.Interfaces
{
    /// <summary>
    /// Interface For GraphPlotter BAC
    /// </summary>
    public interface IGraphPlotterBAL
    {
        IList<StateWisePopulationDTO> FetchStateWisePopulationBAL();

        IList<AgeWisePopulationDTO> FetchAgeWisePopulationBAL();
    }
}
