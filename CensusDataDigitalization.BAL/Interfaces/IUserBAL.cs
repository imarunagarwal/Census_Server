using CensusDataDigitalization.DTO.DTOs;
using System.Collections.Generic;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.BAL.Interfaces
{
    /// <summary>
    /// Interface for User BAC 
    /// </summary>
    public interface IUserBAL
    {
        UserDTO ValidateUserSignUpBAL(string email, string aadhar);

        UserDTO ValidateUserLoginBAL(string email, string pwd);

        IList<UserDTO> GetUsersBAL(int type);

        UserDTO GetUserByIdBAL(int id);

        UserDTO AddUserBAL(UserDTO user);

        UserDTO UpdateUserBAL(int id, ApprovalStatus stat);


    }
}
