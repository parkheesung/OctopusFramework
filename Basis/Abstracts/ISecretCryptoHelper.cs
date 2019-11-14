using System;
using System.Collections.Generic;
using System.Text;

namespace Octopus.Basis
{
    public interface ISecretCryptoHelper : ITwoWayCryptoHelper
    {
        void SetSecret(string SecretString);
    }
}
