namespace Lab6
{
    public interface IBuilder
    {
        void AddName(string firstName, string lastName);
        void AddAddress(string addy);
        void AddPassportNumber(int? passport);
        void Reset();
        Client GetResult();
    }
}