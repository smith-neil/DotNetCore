using System;

namespace DotNetCore.Core.Utilities
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception exception);
    }
}
