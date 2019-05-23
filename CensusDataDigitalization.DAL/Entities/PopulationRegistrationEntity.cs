using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DAL.Entities
{
    /// <summary>
    /// Population Registration Entity
    /// </summary>
    public class PopulationRegistrationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NPRID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FullName { get; set; }

        [Required]
        public int CensusHouseNoID { get; set; }

        [Required]
        public RelationToHead RelationshipToHead { get; set; }

        [Required]
        public Gender_ Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public MaritalStatus_ MaritalStatus { get; set; }

        public int? AgeAtMarriage { get; set; }

        [Required]
        public Occupation_ Occupation { get; set; }

        [Required]
        public string NatureOfOccupationIndustry { get; set; }
    }
}
