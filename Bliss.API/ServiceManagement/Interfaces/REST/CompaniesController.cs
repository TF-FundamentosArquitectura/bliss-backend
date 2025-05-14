using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST;

/**
 * Controller for the companies
 * <param name="companyCommandService">
 * The <see cref="ICompanyCommandService"/> service to handle company commands
 * </param>
 * <param name="companyQueryService">
 * The <see cref="ICompanyQueryService"/> service to handle company queries
 * </param>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Companies")]
public class CompaniesController(
    ICompanyCommandService companyCommandService,
    ICompanyQueryService companyQueryService
    ) : ControllerBase
{
    /**
     * Create a new company
     * <param name="resource">
     * The <see cref="CreateCompanyResource"/> resource to create the company from
     * </param>
     * <returns>
     * The <see cref="CompanyResource"/> resource created
     * </returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new company",
        Description = "Create a new company in the system",
        OperationId = "CreateCompany")]
    [SwaggerResponse(StatusCodes.Status201Created, "The company was created", typeof(CompanyResource))]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyResource resource)
    {
        var createCompanyCommand = CreateCompanyCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var company = await companyCommandService.Handle(createCompanyCommand);
        if (company is null) return BadRequest();
        var companyResource = CompanyResourceFromEntityAssembler.ToResourceFromEntity(company);
        return CreatedAtAction(nameof(GetCompanyById), new { companyId = company.Id }, companyResource);
    }
    
    /**
     * Get company by id
     * <param name="companyId">
     * The id of the company to get
     * </param>
     * <returns>
     * The <see cref="CompanyResource"/> resource with the given id
     * </returns>
     */
    [HttpGet("{companyId:int}")]
    [SwaggerOperation(
        Summary = "Get company by id",
        Description = "Get a company by its id",
        OperationId = "GetCompanyById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The company was found", typeof(CompanyResource))]
    public async Task<IActionResult> GetCompanyById(int companyId)
    {
        var getCompanyByIdQuery = new GetCompanyByIdQuery(companyId);
        var company = await companyQueryService.Handle(getCompanyByIdQuery);
        if (company is null) return NotFound();
        var companyResource = CompanyResourceFromEntityAssembler.ToResourceFromEntity(company);
        return Ok(companyResource);
    }
    
    /**
     * Get all companies
     * <returns>
     * The <see cref="CompanyResource"/> resources for all companies
     * </returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all companies",
        Description = "Get all companies in the system",
        OperationId = "GetAllCompanies")]
    [SwaggerResponse(StatusCodes.Status200OK, "The companies were found", typeof(IEnumerable<CompanyResource>))]
    public async Task<IActionResult> GetAllCompanies()
    {
        var getAllCompaniesQuery = new GetAllCompaniesQuery();
        var companies = await companyQueryService.Handle(getAllCompaniesQuery);
        var companyResources = companies.Select(
            CompanyResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(companyResources);
    }
}