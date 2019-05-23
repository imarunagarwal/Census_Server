using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CensusDataDigitalization.DAL.Entities;

namespace CensusDataDigitalization.DAL.DBContext
{
    public class CensusDataDigitalizationContext : DbContext
    {
        /// <summary>
        /// Constructs the Model Of DataBase
        /// </summary>
        public CensusDataDigitalizationContext() :base("CensusDataDigitalizationContext")
        {

        }

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<PopulationRegistrationEntity> PopulationRegistrationEntity { get; set; }
        public DbSet<HouseListingEntity> HouseListingEntity { get; set; }

        /// <summary>
        /// Does the Things defined in it upon Creation Of Model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
