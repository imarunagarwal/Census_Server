using CensusDataDigitalization.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace CensusDataDigitalization.DAL.DBContext
{
    /// <summary>
    /// DataBase Initializer.
    /// </summary>
    class CensusDataDigitalizationInitializer : DropCreateDatabaseIfModelChanges<CensusDataDigitalizationContext>
    {
        protected override void Seed(CensusDataDigitalizationContext context)
        {
            var users = new List<UserEntity>
            {
                new UserEntity{
                    EmailID = "arun@nagarro.com",
                    Password = "Arun@123",
                    ImageUrl = "img-1.jpg",
                    FirstName = "Arun",
                    LastName = "Agarwal",
                    Address = "GP-28",
                    State ="haryana",
                    Age =21,
                    AadharNo = "123456123456",
                    IsApproved = DTO.Enums.ApprovalStatus.Pending,
                    IsApprover = false

                },
                new UserEntity{
                    EmailID = "arun1@nagarro.com",
                    Password = "Arun@123",
                    ImageUrl = "img-2.jpg",
                    FirstName = "Arun",
                    LastName = "Agarwal",
                    Address = "GP-28",
                    State ="haryana",
                    Age =21,
                    AadharNo = "123456789012",
                    IsApproved = DTO.Enums.ApprovalStatus.Pending,
                    IsApprover = true,
                }

            };
            users.ForEach(e => context.UserEntity.Add(e));
            context.SaveChanges();
        }
    }
}
