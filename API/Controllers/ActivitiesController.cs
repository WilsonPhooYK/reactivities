using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// OLD WAY
// public class ActivitiesController : BaseApiController
// {
//   private readonly AppDbContext context;
//   public ActivitiesController(AppDbContext context)
//   {
//     this.context = context;
//   }
// }

public class ActivitiesController() : BaseApiController
{
  [HttpGet]
  public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
  {
    // Use mediator to hide the implementation details of how the activities are retrieved, and just send a query to get the list of activities
    return await Mediator.Send(new GetActivityList.Query(), ct);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Activity>> GetActivity(string id)
  {
    return await Mediator.Send(new GetActivityDetails.Query{ Id = id });
  }

  [HttpPost]
  public async Task<ActionResult<string>> CreateActivity(Activity activity)
  {
    return await Mediator.Send(new CreateActivity.Command { Activity = activity });
  }

  [HttpPut]
  public async Task<ActionResult> EditActivity(Activity activity)
  {
    await Mediator.Send(new EditActivity.Command { Activity = activity });

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteActivity(string id)
  {
    await Mediator.Send(new DeleteActivity.Command { Id = id });

    return Ok();
  }
}