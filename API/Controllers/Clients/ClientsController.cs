using API.Dtos;
using AutoMapper;
using Core.Clients.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Clients;

public class ClientsController(IGenericRepository<Client> repo, IMapper mapper) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetClients([FromQuery] ClientSpecParams specParams)
    {
        var spec = new ClientSpecification(specParams);

        return await CreatePagedResult<Client, ClientDto>(repo, spec, specParams.PageIndex, specParams.PageSize, mapper);
    }
}
