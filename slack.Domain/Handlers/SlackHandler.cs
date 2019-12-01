using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration;
using slack.Domain.Commands;
using slack.Domain.ExternalServices;
using slack.Domain.ExternalServices.Models;
using System.Threading;
using System.Threading.Tasks;

namespace slack.Domain.Handlers
{
    public class SlackHandler : IRequestHandler<SlackCommand, SlackResultado>
    {
        private readonly ISlackExternalService _slackExternalService;
        public IConfiguration _configuration;

        public SlackHandler(ISlackExternalService reconhecimentoFacialExternalService, IConfiguration configuration)
        {
            _slackExternalService = reconhecimentoFacialExternalService;
            _configuration = configuration;
        }
        public async Task<SlackResultado> Handle(SlackCommand request, CancellationToken cancellationToken)
        {
            var response = await _slackExternalService.ChatPostMessage(new CreateMsg() { Text = request.Mensagem});

            if (response.IsSuccessStatusCode)
                return new SlackResultado();

            return null;
        }

    }
}
