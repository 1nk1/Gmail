namespace Gmail.Contracts.Driver
{
    public interface IDriverProvider<out TDriver>
    {
        TDriver GetDriver();
    }
}