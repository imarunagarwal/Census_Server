using AutoMapper;
using CensusDataDigitalization.DAL.DBContext;
using CensusDataDigitalization.DAL.Entities;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System;

namespace CensusDataDigitalization.DAL.DAC
{
    public class PopulationRegistrationDAC : IPopulationRegistrationDAC
    {
        private IMapper mapPopulationRegistrationDTO2Entity;
        private IMapper mapPopulationRegistrationEntity2DTO;

        public PopulationRegistrationDAC()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PopulationRegistrationDTO, PopulationRegistrationEntity>();
            }
            );
            mapPopulationRegistrationDTO2Entity = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PopulationRegistrationEntity, PopulationRegistrationDTO>();
            }
            );
            mapPopulationRegistrationEntity2DTO = mapperConfiguration1.CreateMapper();
        }

        /// <summary>
        /// Add Population Details to DataBase.
        /// </summary>
        /// <param name="populationRegistrationDTO"></param>
        /// <returns></returns>
        public PopulationRegistrationDTO AddPopulationDAL(PopulationRegistrationDTO populationRegistrationDTO)
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    PopulationRegistrationEntity populationEntity;
                    populationEntity = mapPopulationRegistrationDTO2Entity.Map<PopulationRegistrationEntity>(populationRegistrationDTO);
                    PopulationRegistrationEntity createdPopulationRegistrationEntity = db.PopulationRegistrationEntity.Add(populationEntity);
                    db.SaveChanges();
                    PopulationRegistrationDTO createdUserDTO = mapPopulationRegistrationEntity2DTO.Map<PopulationRegistrationDTO>(createdPopulationRegistrationEntity);
                    return createdUserDTO;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Get populationDetails from database using ID of person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PopulationRegistrationDTO GetPopulationRegistrationByIdDAL(int id)
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                PopulationRegistrationEntity populationRegistrationEntity = db.PopulationRegistrationEntity.Find(id);
                PopulationRegistrationDTO populationRegistrationDTO = mapPopulationRegistrationEntity2DTO.Map<PopulationRegistrationDTO>(populationRegistrationEntity);
                return populationRegistrationDTO;
            }
        }
    }
}
