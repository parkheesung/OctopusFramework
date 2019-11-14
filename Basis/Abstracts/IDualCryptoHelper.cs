using System;
using System.Collections.Generic;
using System.Text;

namespace Octopus.Basis
{
    public interface IDualCryptoHelper
    {
        void SetPublicSecret(string publicString);
        void SetPrivateSecret(string privateString);
    }
}
