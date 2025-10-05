using Entities.Common.Endpoint;
using Repositories.Repository;
using Repositories.Wrapper;

namespace QueryService.Features.Pages.v1.Hr.Training
{
    public class TrainingQuery(IQueryRepository queryRepository) : Repository(queryRepository, endpoint), ITrainingQuery
    {
        private static readonly string endpoint = ApiEndpoint.Hr.Training;
    }
}
