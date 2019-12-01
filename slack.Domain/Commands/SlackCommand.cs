using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace slack.Domain.Commands
{
    public class SlackCommand : IRequest<ExternalServices.Models.SlackResultado>
    {
        public string Mensagem { get; set; }
    }
}
