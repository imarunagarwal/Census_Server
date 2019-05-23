using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DAL.DAC;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System.Collections.Generic;

namespace CensusDataDigitalization.BAL
{
    /// <summary>
    /// Graph plotter business logics
    /// </summary>
    public class GraphPlotterBAL : IGraphPlotterBAL
    {

        IGraphPlotterDAL graphPlotterDAL;

        public GraphPlotterBAL(IGraphPlotterDAL _graphPlotterDAL)
        {
            this.graphPlotterDAL = _graphPlotterDAL;
        }

        /// <summary>
        /// Fetch State Wise Data for plotting Graph
        /// </summary>
        /// <returns></returns>
        public IList<StateWisePopulationDTO> FetchStateWisePopulationBAL()
        {
            return graphPlotterDAL.FetchStateWisePopulationDAL();
        }

        /// <summary>
        /// Fetch Age Wise Data for plotting Graph
        /// </summary>
        /// <returns></returns>
        public IList<AgeWisePopulationDTO> FetchAgeWisePopulationBAL()
        {
            return graphPlotterDAL.FetchAgeWisePopulationDAL();
        }
    }
}
