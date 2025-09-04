using MediatR;
using RiderContext.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRiderContext.Application.Commands
{
    public record CreateRiderCommand(string Name, string email, int BirthYear)
       : IRequest<RiderDTO>;
}
