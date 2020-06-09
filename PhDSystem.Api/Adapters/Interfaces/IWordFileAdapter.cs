using System;
using System.IO;

namespace PhDSystem.Api.Adapters.Interfaces
{
    public interface IWordFileAdapter: IDisposable
    {
        Stream AsStream();
    }
}
