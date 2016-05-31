namespace Test.Models
{
    // This is the DTO only to used as an intermediate class to show data
    public class ModelDataStructure
    {

        public string Name { get; }
        public double PhoneNumber { get; }
        public double AccountNumber { get; }

        public ModelDataStructure(string name,double phonenumber,double accountnumber)
        {
            Name = name;
            PhoneNumber = phonenumber;
            AccountNumber = accountnumber;

        }
    }

}