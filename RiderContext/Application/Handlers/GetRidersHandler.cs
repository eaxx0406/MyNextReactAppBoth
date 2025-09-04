using HorseRiderContext.Application.Interfaces;
using MediatR;
using RiderContext.Application.DTOs;
using RiderContext.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRiderContext.Application.Handlers
{
    public class GetRidersHandler : IRequestHandler<GetRidersQuery, List<RiderDTO>>
    {
        private readonly IRiderRepository _riderRepository;

        public GetRidersHandler(IRiderRepository riderRepository)
        {
            this._riderRepository = riderRepository;
        }

        public async Task<List<RiderDTO>> Handle(GetRidersQuery request, CancellationToken cancellationToken)
        {
            var riders = await _riderRepository.GetAllAsync();

            return riders.Select(r => new RiderDTO
            {
                RiderName = r.RiderName,
                Id = r.Id,
                BirthYear = r.BirthYear,
                Email = r.Email

            }).ToList();
        }
    }
}
