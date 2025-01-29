using Core.Interfaces;
using Core.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Branches;

public class BranchesController(IGenericRepository<Branch> repo) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Branch>>> GetBranches()
    {
        return Ok(await repo.ListAllAsync());
    }

}
