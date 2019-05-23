using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CensusDataDigitalization.BAL;
using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.Presentation.Models;

namespace CensusDataDigitalization.Presentation.Controllers
{
    public class HouseListingController : ApiController
    {
        private IMapper mapHouseListingDTO2ViewModel;
        private IMapper mapHouseListingViewModel2DTO;

        private IHouseListingBAL houseListingBAL;

        public HouseListingController(IHouseListingBAL _houseListingBAL)
        {
            this.houseListingBAL = _houseListingBAL;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HouseListingDTO, HouseListingViewModel>();
            }
            );
            mapHouseListingDTO2ViewModel = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HouseListingViewModel, HouseListingDTO>();
            }
            );
            mapHouseListingViewModel2DTO = mapperConfiguration1.CreateMapper();
        }


        // GET: api/NationalPopulation/5
        /// <summary>
        /// Get Details of a house using The House ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(HouseListingViewModel))]
        public IHttpActionResult GetHouseListing(int id)
        {
            IHttpActionResult result;
            HouseListingDTO houseListingDTO = houseListingBAL.GetHouseListingByIdBAL(id);

            HouseListingViewModel houseListingViewModel = mapHouseListingDTO2ViewModel.Map<HouseListingViewModel>(houseListingDTO);

            if (houseListingViewModel == null)
            {
                result = Ok();
            }
            else
            {
                result = Ok(houseListingViewModel);
            }

            return result;
        }


        //// POST: api/NationalPopulation
        /// <summary>
        /// Post House Details to DataBase
        /// </summary>
        /// <param name="houseListingViewModel"></param>
        /// <returns></returns>
        [ResponseType(typeof(HouseListingViewModel))]
        public IHttpActionResult PostHouseDetails(HouseListingViewModel houseListingViewModel)
        {
            IHttpActionResult result;

            HouseListingDTO houseListingDTO = mapHouseListingViewModel2DTO.Map<HouseListingDTO>(houseListingViewModel);

            HouseListingDTO houseListingAdded = houseListingBAL.AddHouseListingBAL(houseListingDTO);

            houseListingViewModel = mapHouseListingDTO2ViewModel.Map<HouseListingViewModel>(houseListingAdded);
            if (houseListingViewModel != null)
            {
                result = Ok(houseListingViewModel);
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }
    }
}