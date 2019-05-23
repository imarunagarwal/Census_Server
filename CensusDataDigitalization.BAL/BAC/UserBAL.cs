using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DAL.DAC;
using CensusDataDigitalization.DAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using System.Collections.Generic;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.BAL
{
    /// <summary>
    /// User BAC
    /// </summary>
    public class UserBAL : IUserBAL
    {
        IUserDAC userDAC;

        public UserBAL(IUserDAC _userDAC)
        {
            this.userDAC = _userDAC;
        }


        /// <summary>
        /// Passes Data from controller to DAC to validate User email & aadhar upon SignUp
        /// </summary>
        /// <param name="email"></param>
        /// <param name="aadhar"></param>
        /// <returns></returns>
        public UserDTO ValidateUserSignUpBAL(string email, string aadhar)
        {
            UserDTO user = userDAC.ValidateUserSignUpDAL(email, aadhar);
            return user;
        }

        /// <summary>
        /// Passes Data from controller to DAC to validate User email & Password upon Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public UserDTO ValidateUserLoginBAL(string email, string pwd)
        {
            UserDTO user = userDAC.ValidateUserLoginDAL(email, pwd);
            return user;
        }

        /// <summary>
        /// Passes Data from controller to DAC to Get Users depending Upon Request Type 
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public IList<UserDTO> GetUsersBAL(int requestType)
        {
            IList<UserDTO> users = new List<UserDTO>();

            if (requestType == 0)
            {
                users = userDAC.GetPendingUsersDAL();
            }

            if (requestType == 1)
            {
                users = userDAC.GetDeclinedUsersDAL();
            }

            if (requestType == 2)
            {
                users = userDAC.GetApprovedUsersDAL();
            }
            return users;
        }

        /// <summary>
        /// Passes Data from controller to DAC to Get Users depending Upon User ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetUserByIdBAL(int id)
        {
            UserDTO user = userDAC.GetUserByIdDAL(id);
            return user;
        }

        /// <summary>
        /// Passes Data from controller to DAC to Post Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDTO AddUserBAL(UserDTO user)
        {
            UserDTO userCreated = userDAC.AddUserDAL(user);
            return userCreated;
        }

        /// <summary>
        /// Passes Data from controller to DAC to Update Status of User's Approval Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        public UserDTO UpdateUserBAL(int id, ApprovalStatus stat)
        {
            UserDTO user = userDAC.UpdateUserDAL(id, stat);
            return user;
        }
    }
}
