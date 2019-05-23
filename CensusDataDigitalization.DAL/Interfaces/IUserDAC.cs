using CensusDataDigitalization.DTO.DTOs;
using System.Collections.Generic;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DAL.Interfaces
{
    /// <summary>
    /// Interface For User DAC card
    /// </summary>
    public interface IUserDAC
    {
        IList<UserDTO> GetPendingUsersDAL();

        IList<UserDTO> GetDeclinedUsersDAL();

        IList<UserDTO> GetApprovedUsersDAL();

        UserDTO GetUserByIdDAL(int id);

        UserDTO ValidateUserSignUpDAL(string email, string aadhar);

        UserDTO ValidateUserLoginDAL(string email, string pwd);

        UserDTO AddUserDAL(UserDTO userDTO);

        UserDTO UpdateUserDAL(int id, ApprovalStatus stat);


    }
}
