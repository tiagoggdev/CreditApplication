using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using CreditApplication.Application.Dtos;
using MediatR;

namespace CreditApplication.Application.UseCases.Queries.GetApplicationByClientQuery
{
    public class GetApplicationByClientQuery : IRequest<Result<ICollection<CreditApplyResponseDto>>>
    {
        public int IdClient { get; set; }
    }
}
