using Entities.Common.Endpoint;
using Entities.Features.Pages.Hr.Training;
using Repositories.Base;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr.Training
{
    public class TrainingQuery(IQueryRepository repository) : BaseRepository<TrainingModel>(repository, ApiEndpoint.Hr.Training), ITrainingQuery
    {
    }
}
