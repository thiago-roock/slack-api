using System.Threading.Tasks;
using BuildingBlock.Token.Sts.ExternalServices.Models;
using Refit;

namespace BuildingBlock.Token.Sts.ExternalServices
{
    public interface IAuthenticationService
    {
        [Get("https://slack.com/api/oauth.access?client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&code={ACESS_API}")]
        Task<Models.Token> GetToken(string CLIENT_ID, string CLIENT_SECRET, string code);
    }
}