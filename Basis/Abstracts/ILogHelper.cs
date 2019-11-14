using System;

namespace Octopus.Basis
{
    public interface ILogHelper
    {
        void Debug(string msg);
        void Debug<T>(T target);

        void Error(string msg);
        void Error(Exception ex);

        void Query(string query);

        void Info(string msg);
        void Info<T>(T target);
    }
}
