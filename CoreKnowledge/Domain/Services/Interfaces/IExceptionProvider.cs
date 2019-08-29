using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKnowledge.Domain.Services.Interfaces
{
    public interface IExceptionProvider
    {
        void Write(System.Exception exception);
    }
}
