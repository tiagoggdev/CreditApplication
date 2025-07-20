using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using CreditApplication.Domain.Enums;
using MediatR;

namespace CreditApplication.Application.UseCases.Commands.CreateApplicationCommand
{
    public class CreateApplicationCommand : IRequest<Result<bool>>
    {
        public StatusEnum Status { get; set; }
        public int IdClient { get; set; }
    }
}
