using API.RequestHelpers;
using AutoMapper;
using Core.Interfaces;
using Core.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T, TDto>(IGenericRepository<T> repo, ISpecification<T> spec,
        int pageIndex, int pageSize, IMapper mapper) where T : BaseEntity
    {
        var items = await repo.ListAsync(spec);
        var count = await repo.CountAsync(spec);

        var dtoItems = mapper.Map<IReadOnlyList<T>, IReadOnlyList<TDto>>(items);
        var pagination = new Pagination<TDto>(pageIndex, pageSize, count, dtoItems);

        return Ok(pagination);
    }
}