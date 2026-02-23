using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

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

public class ActivitiesController(AppDbContext context) : BaseApiController
{
  [HttpGet]
  public async Task<ActionResult<List<Activity>>> GetActivities()
  {
    return await context.Activities.ToListAsync();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Activity>> GetActivity(string id)
  {
    var activity = await context.Activities.FindAsync(id);

    if (activity == null) return NotFound();

    return activity;
  }
}