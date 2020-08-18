namespace Lab6
{
    public class Client
    {
        public string FirstName;
        public string LastName;
        public string Addy = null;
        public int? Passport = null;

        public Client(string f, string l, string a, int? p)
        {
            FirstName = f;
            LastName = l;
            Addy = a;
            Passport = p;
        }

        public override string ToString()
        {
            return $"Client: {FirstName} {LastName}\nAddress: {Addy}\nPassportNumber: {Passport}";
        }
    }
}