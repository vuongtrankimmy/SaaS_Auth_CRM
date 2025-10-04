using Entities.Common.Endpoint;
using Entities.Features.Pages.Auth.Account_Choose;
using QueryService.Features.Pages.Auth.Account_Choose;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Auth.Account_Choose
{
    public class Account_ChooseQuery(IQueryRepository repository) :BaseRepository<Account_ChooseModel>(repository, ApiEndpoint.Auth.AccountChoose), IAccount_ChooseQuery
    {
    }
}
