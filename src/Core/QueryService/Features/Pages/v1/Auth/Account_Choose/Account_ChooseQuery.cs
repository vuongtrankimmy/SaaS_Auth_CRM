using Entities.Common.Endpoint;
using QueryService.Features.Pages.Auth.Account_Choose;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Auth.Account_Choose
{
    public class Account_ChooseQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), IAccount_ChooseQuery
    {
        private static readonly string endpoint = ApiEndpoint.Auth.AccountChoose;
    }
}
