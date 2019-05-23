using System;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DTO.DTOs
{
    /// <summary>
    /// DTO for USER
    /// </summary>
    public class UserDTO
    {
        public int UserID { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public int Age { get; set; }

        public string AadharNo { get; set; }

        public ApprovalStatus IsApproved { get; set; }

        public Boolean IsApprover { get; set; }
    }
}
