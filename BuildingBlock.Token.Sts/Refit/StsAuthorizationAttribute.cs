using Refit;

namespace BuildingBlock.Token.Sts.Refit
{
    public class StsAuthorizationAttribute : HeadersAttribute
    {
        public StsAuthorizationAttribute() : base("Authorization: Bearer")
        {
        }
    }
}
