using System.Text;

namespace Octopus.Crypto
{
    public abstract class CryptoHelperBase
    {
        protected virtual string SaltAdd(string targetString)
        {
            StringBuilder builder = new StringBuilder(targetString);
            builder.Replace("=", "EvSxrTzQ");
            builder.Replace("+", "PDkcVjeDL");
            builder.Replace("/", "SkenFkkd");
            return builder.ToString();
        }

        protected virtual string SaltRemove(string targetString)
        {
            StringBuilder builder = new StringBuilder(targetString);
            builder.Replace("EvSxrTzQ", "=");
            builder.Replace("PDkcVjeDL", "+");
            builder.Replace("SkenFkkd", "/");
            return builder.ToString();
        }
    }
}
