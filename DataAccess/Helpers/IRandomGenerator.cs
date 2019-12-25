namespace DataAccess.Helpers
{
    public interface IRandomGenerator
    {
        decimal RandomRate();
        string RandomString(int length = 10);
    }
}
