using HorseRiderContext.Application.Commands;
using HorseRiderContext.Application.Interfaces;
using HorseRiderContext.Domain.Entities;
using MediatR;
using RiderContext.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRiderContext.Application.Handlers
{
    public class CreateRiderCommandHandler : IRequestHandler<CreateRiderCommand, RiderDTO>
    {
        private readonly IRiderRepository _horseRepository;

        public CreateRiderCommandHandler(IRiderRepository riderRepository)
        {
            _horseRepository = riderRepository;
        }

        public async Task<RiderDTO> Handle(CreateRiderCommand command, CancellationToken cancellationToken)
        {
            // Opretter ny rytter (Domain Entity)
            Rider riderEntity = new Rider(command.Name, command.email, command.BirthYear);

            // Gemmer via repository
            await _horseRepository.AddAsync(riderEntity);
            await _horseRepository.SaveChangesAsync();

            // Mapper til Application DTO (BookDto) – stadig uafhængig af Contracts
            var riderDto = new RiderDTO
            {
                RiderName = riderEntity.RiderName,
                Id = riderEntity.Id,
                Email = riderEntity.Email,
                BirthYear = riderEntity.BirthYear
            };

            return riderDto;
        }
    }
}


