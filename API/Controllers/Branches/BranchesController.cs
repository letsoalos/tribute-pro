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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Branch>> GetBranch(int id)
    {
        var branch = await repo.GetByIdAsync(id);

        if (branch == null) return NotFound();

        return branch;
    }

}
