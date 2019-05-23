using AutoMapper;
using CensusDataDigitalization.DAL.DBContext;
using CensusDataDigitalization.DAL.Entities;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System;

namespace CensusDataDigitalization.DAL.DAC
{
    public class HouseListingDAC : IHouseListingDAC
    {
        private IMapper mapHouseListingDTO2Entity;
        private IMapper mapHouseListingEntity2DTO;

        public HouseListingDAC()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HouseListingDTO, HouseListingEntity>();
            }
            );
            mapHouseListingDTO2Entity = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HouseListingEntity, HouseListingDTO>();
            }
            );
            mapHouseListingEntity2DTO = mapperConfiguration1.CreateMapper();
        }

        /// <summary>
        /// Gets the Result of House Listing From DataBase using Id of House
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HouseListingDTO GetHouseListingByIdDAL(int id)
        {

            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                HouseListingEntity houseListingEntity = db.HouseListingEntity.Find(id);
                HouseListingDTO houseListingDTO = mapHouseListingEntity2DTO.Map<HouseListingDTO>(houseListingEntity);
                return houseListingDTO;
            }
        }

        /// <summary>
        /// Add the House Record to DataBase
        /// </summary>
        /// <param name="houseListingDTO"></param>
        /// <returns></returns>
        public HouseListingDTO AddHouseListingDAL(HouseListingDTO houseListingDTO)
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    HouseListingEntity houseListingEntity = mapHouseListingDTO2Entity.Map<HouseListingEntity>(houseListingDTO);
                    HouseListingEntity createdHouseListingEntity = db.HouseListingEntity.Add(houseListingEntity);
                    db.SaveChanges();
                    HouseListingDTO createdHouseListingDTO = mapHouseListingEntity2DTO.Map<HouseListingDTO>(createdHouseListingEntity);
                    return createdHouseListingDTO;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }
    }
}
