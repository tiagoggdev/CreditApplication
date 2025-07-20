using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Domain.Enums;

namespace CreditApplication.Application.Dtos
{
    public record CreditApplyResponseDto(StatusEnum State, DateTime CreateDate);
}
