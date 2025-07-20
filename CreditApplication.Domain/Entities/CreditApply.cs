using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Domain.Enums;

namespace CreditApplication.Domain.Entities
{
    public class CreditApply
    {
        public int Id { get; set; }
        public StatusEnum State {  get; set; }
        public DateTime CreateDate { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; } = null!;

    }
}
