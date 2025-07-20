using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using CreditApplication.Domain.Entities;
using CreditApplication.Infrastructure.Data;
using MediatR;

namespace CreditApplication.Application.UseCases.Commands.CreateClientCommand
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Result<bool>>
    {
        private readonly AppDbContext _context;

        public CreateClientHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var clientToCreate = new Client
            {
                Name = request.Name,
                Email = request.Email,
                SignUpDate = DateTime.Now
            };

            _context.Clients.Add(clientToCreate);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<bool>.Ok(true);
        }
    }
}
