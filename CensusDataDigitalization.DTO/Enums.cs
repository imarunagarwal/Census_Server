namespace CensusDataDigitalization.DTO
{
    public class Enums
    {
        public enum ApprovalStatus
        {
            Pending,
            Declined,
            Approved
        }

        public enum HouseRentalStatus
        {
            Rented,
            Owned
        }

        public enum RelationToHead
        {
            Self,
            Spouse,
            Son,
            Daughter,
            Sibling,
            GrandSon,
            GrandDaughter
        }

        public enum Gender_
        {
            Male,
            Female
        }

        public enum MaritalStatus_
        {
            Married,
            Single
        }

        public enum Occupation_
        {
            Employed,
            SelfEmployed,
            Student
        }
    }
}
