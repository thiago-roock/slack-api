using Refit;
using slack.Domain.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace slack.Domain.ExternalServices
{
  
    public interface ISlackExternalService
    {
        [Post("/services/TKTDS2JCD/BQX8U4TAM/SBdmlzcvF88z6X9HpldsVsuG")]
        Task<ApiResponse<SlackResultado>> ChatPostMessage(CreateMsg message);
    }
}
