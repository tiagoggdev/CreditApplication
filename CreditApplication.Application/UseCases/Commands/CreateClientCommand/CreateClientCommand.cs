using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Application.Common.Result;
using MediatR;

namespace CreditApplication.Application.UseCases.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Result<bool>>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
