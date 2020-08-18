namespace Lab6
{
    public class ClientBuilder : IBuilder
    {
        string FirstName, LastName, Addy;
        int? Passport;
        public void AddName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAddress(string addy)
        {
            Addy = addy;
        }

        public void AddPassportNumber(int? passport)
        {
            Passport = passport;
        }

        public void Reset()
        {
            FirstName = "";
            LastName = "";
            Addy = "";
            Passport = null;
        }

        public Client GetResult()
        {
            return new Client(FirstName, LastName, Addy, Passport);
        }
    }
}