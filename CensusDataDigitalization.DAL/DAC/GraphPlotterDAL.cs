using AutoMapper;
using CensusDataDigitalization.DAL.DBContext;
using CensusDataDigitalization.DAL.Entities;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CensusDataDigitalization.DAL.DAC
{
    public class GraphPlotterDAL : IGraphPlotterDAL
    {
        private IMapper mapStateWisePopulationEntity2DTO;

        private IMapper mapAgeWisePopulationEntity2DTO;

        public GraphPlotterDAL()
        {

            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StateWisePopulationEntity, StateWisePopulationDTO>();
            }
            );
            mapStateWisePopulationEntity2DTO = mapperConfiguration1.CreateMapper();


            MapperConfiguration mapperConfiguration2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgeWisePopulationEntity, AgeWisePopulationDTO>();
            }
            );
            mapAgeWisePopulationEntity2DTO = mapperConfiguration2.CreateMapper();
        }

        /// <summary>
        /// Fetch Data from server to plot graph StateWise people.
        /// </summary>
        /// <returns></returns>
        public IList<StateWisePopulationDTO> FetchStateWisePopulationDAL()
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                List<HouseListingEntity> houseList = db.HouseListingEntity.ToList();

                List<StateWisePopulationEntity> stateWisepopulation = new List<StateWisePopulationEntity>();
                foreach (HouseListingEntity house in houseList)
                {
                    int index = stateWisepopulation.FindIndex(x => x.State.Equals(house.State));
                    if (index == -1)
                    {
                        if (house.NationalPopulationEntities.Count > 0)
                        {
                            stateWisepopulation.Add(new StateWisePopulationEntity()
                            {
                                State = house.State,
                                Count = house.NationalPopulationEntities.Count
                            });
                        }
                    }
                    else
                    {
                        stateWisepopulation[index].Count += house.NationalPopulationEntities.Count;
                    }
                }
                return mapStateWisePopulationEntity2DTO.Map<IList<StateWisePopulationDTO>>(stateWisepopulation);
            }
        }

        /// <summary>
        /// Fetch Data from server to plot graph Age wise
        /// </summary>
        /// <returns></returns>
        public IList<AgeWisePopulationDTO> FetchAgeWisePopulationDAL()
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                List<PopulationRegistrationEntity> peopleList = db.PopulationRegistrationEntity.ToList();
                List<AgeWisePopulationEntity> ageWisePopulation = new List<AgeWisePopulationEntity>();
                int currentYear = DateTime.Now.Year;
                foreach (PopulationRegistrationEntity person in peopleList)
                {
                    int peopleAge = currentYear - person.DOB.Year;
                    int index = ageWisePopulation.FindIndex(x=> x.Age == peopleAge);
                    if (index == -1)
                    {
                            ageWisePopulation.Add(new AgeWisePopulationEntity()
                            {
                                Age = peopleAge,
                                Count = 1
                            });
                    }
                    else
                    {
                        ageWisePopulation[index].Count ++;
                    }
                }
                return mapAgeWisePopulationEntity2DTO.Map<IList<AgeWisePopulationDTO>>(ageWisePopulation);
            }
        }
    }
}

