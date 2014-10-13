namespace apitool.core.Providers
{
    public interface IConfigurationProvider
    {
        string PartnerId { get; }
        string RestaurantId { get; }
        string PartySize { get; }
        string SearchTerm { get; }
    }
}