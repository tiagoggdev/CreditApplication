using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using CreditApplication.Domain.Entities;
using CreditApplication.Infrastructure.Data;
using MediatR;

namespace CreditApplication.Application.UseCases.Commands.CreateApplicationCommand
{
    public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, Result<bool>>
    {
        private readonly AppDbContext _context;

        public CreateApplicationHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var appl = new CreditApply
            {
                State = request.Status,
                CreateDate = DateTime.Now,
                IdClient = request.IdClient
            };

            _context.CreditApplications.Add(appl);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<bool>.Ok(true);
        }
    }
}
