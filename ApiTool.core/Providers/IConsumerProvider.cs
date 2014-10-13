namespace apitool.core.Providers
{
    public interface IConsumerProvider
    {
        string Nonce { get; }
        string TimeStamp { get; }
        string Key { get; }
        string Secret { get; }
    }
}