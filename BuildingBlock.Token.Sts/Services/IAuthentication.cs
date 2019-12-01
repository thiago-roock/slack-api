using System.Threading.Tasks;

namespace BuildingBlock.Token.Sts.Services
{
    public interface IAuthentication
    {
        Task<ExternalServices.Models.Token> GetToken();
    }
}