using MediatR;
using RiderContext.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiderContext.Application.Queries
{
    public record GetRidersQuery() : IRequest<List<RiderDTO>>;
}


