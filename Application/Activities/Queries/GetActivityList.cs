using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityList
{
  // Query and request needed
  public class Query : IRequest<List<Activity>> {}

  // Pass in context and the query and response type
  // , ILogger<GetActivityList> logger
  public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
  {
    // Reponse type, request and cancellation token
    public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
    {
      // try
      // {
      //   // Simulate a delay to test loading state in the client
      //   for (int i = 0; i < 10; i++)
      //   {
      //     cancellationToken.ThrowIfCancellationRequested();
      //     await Task.Delay(1000, cancellationToken);
      //     logger.LogInformation($"Task {i} has completed.");
      //   }
      // }
      // catch (TaskCanceledException)
      // {
      //   logger.LogInformation("The operation was canceled.");
      //   // Handle the cancellation if needed
      //   // throw new OperationCanceledException("The operation was canceled.", cancellationToken);
      // }

      return await context.Activities.ToListAsync(cancellationToken);
    }
  }
}
