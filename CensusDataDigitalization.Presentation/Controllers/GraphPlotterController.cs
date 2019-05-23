using AutoMapper;
using CensusDataDigitalization.BAL;
using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.Presentation.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CensusDataDigitalization.Presentation.Controllers
{
    public class GraphPlotterController : ApiController
    {

        IGraphPlotterBAL graphPlotterBAL;

        private IMapper mapStateWisePopulationDTO2ViewModel;

        private IMapper mapAgeWisePopulationDTO2ViewModel;


        public GraphPlotterController(IGraphPlotterBAL _graphPlotterBAL)
        {
            this.graphPlotterBAL = _graphPlotterBAL;

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StateWisePopulationDTO, StateWisePopulationViewModel>();
            }
            );
            mapStateWisePopulationDTO2ViewModel = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration3 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgeWisePopulationDTO, AgeWisePopulationViewModel>();
            }
            );
            mapAgeWisePopulationDTO2ViewModel = mapperConfiguration3.CreateMapper();

        }

        /// <summary>
        /// Get data for graphs from DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetUserEntity(int id)
        {
            IHttpActionResult result;
            if (id == 1)
            {
                IList<StateWisePopulationViewModel> stateWisePopulationViewModel = new List<StateWisePopulationViewModel>();
                IList<StateWisePopulationDTO> stateWisePopulationDTO = new List<StateWisePopulationDTO>();
                stateWisePopulationDTO = graphPlotterBAL.FetchStateWisePopulationBAL();
                stateWisePopulationViewModel = mapStateWisePopulationDTO2ViewModel.Map<IList<StateWisePopulationViewModel>>(stateWisePopulationDTO);
                result = Ok(stateWisePopulationViewModel);
            }
            else
            {
                IList<AgeWisePopulationViewModel> ageWisePopulationViewModel = new List<AgeWisePopulationViewModel>();
                IList<AgeWisePopulationDTO> ageWisePopulationDTO = new List<AgeWisePopulationDTO>();

                ageWisePopulationDTO = graphPlotterBAL.FetchAgeWisePopulationBAL();
                ageWisePopulationViewModel = mapAgeWisePopulationDTO2ViewModel.Map<IList<AgeWisePopulationViewModel>>(ageWisePopulationDTO);
                result = Ok(ageWisePopulationViewModel);
            }

            return result;
        }

    }
}