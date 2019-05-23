using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CensusDataDigitalization.BAL;
using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.Presentation.Models;

namespace CensusDataDigitalization.Presentation.Controllers
{
    public class PopulationRegistrationController : ApiController
    {
        private IMapper mapPopulationRegistrationDTO2ViewModel;
        private IMapper mapPopulationRegistrationViewModel2DTO;

        private IPopulationRegistrationBAL populationRegistrationBAL;

        public PopulationRegistrationController(IPopulationRegistrationBAL _populationRegistrationBAL)
        {
            this.populationRegistrationBAL = _populationRegistrationBAL;

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PopulationRegistrationDTO, PopulationRegistrationViewModel>();
            }
            );
            mapPopulationRegistrationDTO2ViewModel = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PopulationRegistrationViewModel, PopulationRegistrationDTO>();
            }
            );
            mapPopulationRegistrationViewModel2DTO = mapperConfiguration1.CreateMapper();
        }


        // GET: api/NationalPopulation/5
        /// <summary>
        /// Get Details of a person using unique id from DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(PopulationRegistrationViewModel))]
        public IHttpActionResult GetPopulationRegistrationById(int id)
        {
            IHttpActionResult result;
            PopulationRegistrationViewModel populationViewModel;

            PopulationRegistrationDTO populationDTO = populationRegistrationBAL.GetPopulationRegistrationByIdBAL(id);

            populationViewModel = mapPopulationRegistrationDTO2ViewModel.Map<PopulationRegistrationViewModel>(populationDTO);

            if (populationViewModel == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(populationViewModel);
            }
            return result;
        }

        /// <summary>
        /// Post details of a person to database
        /// </summary>
        /// <param name="populationViewModel"></param>
        /// <returns></returns>
        //// POST: api/NationalPopulation
        [ResponseType(typeof(PopulationRegistrationViewModel))]
        public IHttpActionResult PostNationalPopulationEntity(PopulationRegistrationViewModel populationViewModel)
        {
            IHttpActionResult result;
            PopulationRegistrationDTO populationDTO = mapPopulationRegistrationViewModel2DTO.Map<PopulationRegistrationDTO>(populationViewModel);

            PopulationRegistrationDTO populationAdded = populationRegistrationBAL.AddPopulationBAL(populationDTO);
            populationViewModel = mapPopulationRegistrationDTO2ViewModel.Map<PopulationRegistrationViewModel>(populationAdded);

            if (populationViewModel != null)
            {
                result = Ok(populationViewModel);
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }
    }
}