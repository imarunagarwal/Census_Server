using CensusDataDigitalization.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusDataDigitalization.DAL.Interfaces
{
    /// <summary>
    /// Interface For Graph plotter DAC Card
    /// </summary>
    public interface IGraphPlotterDAL
    {
        IList<StateWisePopulationDTO> FetchStateWisePopulationDAL();

        IList<AgeWisePopulationDTO> FetchAgeWisePopulationDAL();
    }
}
