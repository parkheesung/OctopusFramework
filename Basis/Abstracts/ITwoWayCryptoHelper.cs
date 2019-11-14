namespace Octopus.Basis
{
    public interface ITwoWayCryptoHelper
    {
        string Decrypt(string keyString);
        string Encrypt(string keyString);
    }
}
