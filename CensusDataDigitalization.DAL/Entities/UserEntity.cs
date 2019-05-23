using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CensusDataDigitalization.DTO.Enums;

namespace CensusDataDigitalization.DAL.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&]).{8,}")]
        public string Password { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        [RegularExpression(@"^[0-9]*$")]
        public string AadharNo { get; set; }


        [Required]
        public ApprovalStatus IsApproved { get; set; }

        [Required]
        public Boolean IsApprover { get; set; }
    }
}
