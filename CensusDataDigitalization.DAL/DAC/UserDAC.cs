using AutoMapper;
using CensusDataDigitalization.DAL.DBContext;
using CensusDataDigitalization.DAL.Entities;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DAL.DAC
{
    public class UserDAC : IUserDAC
    {
        private IMapper mapUserDTO2Entity;
        private IMapper mapUserEntity2DTO;

        public UserDAC()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserEntity>();
            }
            );
            mapUserDTO2Entity = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>();
            }
            );
            mapUserEntity2DTO = mapperConfiguration1.CreateMapper();
        }


        /// <summary>
        /// Get a list of all Users Whose Requests are Pending.
        /// </summary>
        /// <returns></returns>
        public IList<UserDTO> GetPendingUsersDAL()
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    IList<UserEntity> pendingUsers = db.UserEntity.Where(d => d.IsApproved == ApprovalStatus.Pending).ToList();
                    IList<UserDTO> users = mapUserEntity2DTO.Map<IList<UserDTO>>(pendingUsers);
                    return users;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }

        }

        /// <summary>
        /// Get a list of all Users Whose Requests are Declined.
        /// </summary>
        /// <returns></returns>
        public IList<UserDTO> GetDeclinedUsersDAL()
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    IList<UserEntity> declinedUsers = db.UserEntity.Where(d => d.IsApproved == ApprovalStatus.Declined).ToList();
                    IList<UserDTO> users = mapUserEntity2DTO.Map<IList<UserDTO>>(declinedUsers);
                    return users;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Get a list of all Users Whose Requests are Approved.
        /// </summary>
        /// <returns></returns>
        public IList<UserDTO> GetApprovedUsersDAL()
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    IList<UserEntity> approvedUsers = db.UserEntity.Where(d => d.IsApproved == ApprovalStatus.Approved).ToList();
                    IList<UserDTO> users = mapUserEntity2DTO.Map<IList<UserDTO>>(approvedUsers);
                    return users;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Get a list of all Users Whose Id is given.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetUserByIdDAL(int id)
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                UserEntity user = db.UserEntity.Find(id);
                UserDTO userDTO = mapUserEntity2DTO.Map<UserDTO>(user);
                return userDTO;
            }
        }

        /// <summary>
        /// Validates the User's Email & Aadhar Upon SignUp
        /// </summary>
        /// <param name="email"></param>
        /// <param name="aadhar"></param>
        /// <returns></returns>
        public UserDTO ValidateUserSignUpDAL(string email, string aadhar)
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {

                UserEntity user = new UserEntity();

                if (db.UserEntity.Where(e => e.EmailID == email).FirstOrDefault() != null)
                {
                    user.EmailID = email;
                }
                if (db.UserEntity.Where(e => e.AadharNo == aadhar).FirstOrDefault() != null)
                {
                    user.AadharNo = aadhar;
                }

                UserDTO userDTO = mapUserEntity2DTO.Map<UserDTO>(user);
                return userDTO;
            }
        }

        /// <summary>
        /// Validates the User's Email & Password Upon Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserDTO ValidateUserLoginDAL(string email, string pwd)
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                UserEntity user = db.UserEntity.Where(e => e.EmailID == email && e.Password == pwd).FirstOrDefault();
                UserDTO userDTO = mapUserEntity2DTO.Map<UserDTO>(user);
                return userDTO;
            }
        }

        /// <summary>
        /// Add a new User to DataBase
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO AddUserDAL(UserDTO userDTO)
        {
            try
            {
                using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
                {
                    UserEntity userEntity;
                    userEntity = mapUserDTO2Entity.Map<UserEntity>(userDTO);
                    UserEntity createdUserEntity = db.UserEntity.Add(userEntity);
                    db.SaveChanges();
                    UserDTO createdUserDTO = mapUserEntity2DTO.Map<UserDTO>(createdUserEntity);
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
        /// Update User's Request Status in Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        public UserDTO UpdateUserDAL(int id, ApprovalStatus stat)
        {
            using (CensusDataDigitalizationContext db = new CensusDataDigitalizationContext())
            {
                try
                {
                    UserEntity user = db.UserEntity.Find(id);
                    user.IsApproved = stat;
                    //db.UserEntity.Add(user);
                    db.SaveChanges();
                    UserDTO userDTO = mapUserEntity2DTO.Map<UserDTO>(user);

                    return userDTO;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

    }
}
