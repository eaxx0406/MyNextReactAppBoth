using HorseRiderContext.Domain.Entities;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRiderContext.Application.Interfaces
{
    public interface IRiderRepository : IRepository<Rider>
    {
    }
}
