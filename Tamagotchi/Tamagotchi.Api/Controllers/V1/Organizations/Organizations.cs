﻿using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tamagotchi.Api.Controllers.Base;
using MediatR;
using Tamagotchi.Application.Organizations.Queries.GetAll.DTOs;
using Tamagotchi.Application.Organizations.Base.DTOs;
using Tamagotchi.Data.DataTableProcessing;
using Tamagotchi.Application.Organizations.Commands.Create.DTOs;
using Tamagotchi.Application.Organizations.Commands.Update.DTOs;
using Tamagotchi.Application.Organizations.Commands.Delete.DTOs;

namespace Tamagotchi.Api.Controllers.V1.Organizations;

[ApiVersion("1.0")]
[SwaggerTag("Application Api")]
public class Organizations : BaseApiController<Organizations>
{
    private readonly IMapper _mapper;
    public Organizations(
        IMapper mapper,
        IMediator mediator,
        ILogger<Organizations> logger)
        : base(mediator, logger)
    {
        _mapper = mapper;
    }

    [SwaggerOperation(Summary = "Get Organizations By Different Parameters", Description = "Several settings exist: count per page, etc...")]
    [AllowAnonymous]
    [HttpGet(nameof(GetOrganizations))]
    public async Task<IActionResult> GetOrganizations()
    {
        return await CommonQueryMethod<DtResult<GetOrganization>>(new GetOrganizationsQuery { DtParameters = GetStandardParameters() });
    }

    [SwaggerOperation(Summary = "Create Organization", Description = "OrganizationId and Name are required")]
    [AllowAnonymous]
    [HttpPost(nameof(CreateOrganization))]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationCommand query)
    {
        return await CommonQueryMethod<GetOrganization>(query);
    }

    [SwaggerOperation(Summary = "Update Organization", Description = "OrganizationId and Name are required")]
    [AllowAnonymous]
    [HttpPost(nameof(UpdateOrganization))]
    public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand query)
    {
        return await CommonQueryMethod<GetOrganization>(query);
    }

    [SwaggerOperation(Summary = "Delete Organization", Description = "Id is required")]
    [AllowAnonymous]
    [HttpPost(nameof(DeleteOrganization))]
    public async Task<IActionResult> DeleteOrganization([FromBody] DeleteOrganizationCommand query)
    {
        return await CommonQueryMethod<GetOrganization>(query);
    }
}