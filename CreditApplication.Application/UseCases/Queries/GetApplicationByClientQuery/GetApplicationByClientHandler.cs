using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using CreditApplication.Application.Dtos;
using CreditApplication.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CreditApplication.Application.UseCases.Queries.GetApplicationByClientQuery
{
    public class GetApplicationByClientHandler : IRequestHandler<GetApplicationByClientQuery, Result<ICollection<CreditApplyResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetApplicationByClientHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ICollection<CreditApplyResponseDto>>> Handle(GetApplicationByClientQuery request, CancellationToken cancellationToken)
        {
            var creditAppliesByClient = await _context.CreditApplications
                .Where(cp => cp.IdClient == request.IdClient)
                .Select(cp => new CreditApplyResponseDto(cp.State, cp.CreateDate)) 
                .ToListAsync();

            if (creditAppliesByClient.Count == 0)
            {
                return Result<ICollection<CreditApplyResponseDto>>.Fail("Customer doesn't have any credit application");
            }

            return Result<ICollection<CreditApplyResponseDto>>.Ok(creditAppliesByClient);
        }
    }
}
