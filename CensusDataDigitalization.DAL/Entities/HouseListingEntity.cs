using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DAL.Entities
{
    /// <summary>
    /// House Record Entity
    /// </summary>
    public class HouseListingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CensusHouseNoID { get; set; }

        [Required]
        public string BuildingNo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string HeadFullName { get; set; }

        [Required]
        public HouseRentalStatus HouseStatus { get; set; }

        [Required]
        public int NoOfRooms { get; set; }

        public virtual ICollection<PopulationRegistrationEntity> NationalPopulationEntities { get; set; }
    }
}
