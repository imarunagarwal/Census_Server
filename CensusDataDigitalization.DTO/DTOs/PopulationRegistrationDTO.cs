using System;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DTO.DTOs
{
    /// <summary>
    /// DTO for Population Register
    /// </summary>
    public class PopulationRegistrationDTO
    {
        public int NPRID { get; set; }

        public string FullName { get; set; }

        public int CensusHouseNoID { get; set; }

        public RelationToHead RelationshipToHead { get; set; }

        public Gender_ Gender { get; set; }

        public DateTime? DOB { get; set; }

        public MaritalStatus_ MaritalStatus { get; set; }

        public int AgeAtMarriage { get; set; }

        public Occupation_ Occupation { get; set; }

        public string NatureOfOccupationIndustry { get; set; }
    }
}
