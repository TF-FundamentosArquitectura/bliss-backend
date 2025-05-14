using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST;

/**
 * Controller for categories
 * <param name="categoryCommandService">
 * The <see cref="ICategoryCommandService"/> service to handle category commands
 * </param>
 * <param name="categoryQueryService">
 * The <see cref="ICategoryQueryService"/> service to handle category queries
 * </param>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoriesController(
    ICategoryCommandService categoryCommandService,
    ICategoryQueryService categoryQueryService
    ) : ControllerBase
{
    /**
     * Create a new category
     * <param name="resource">
     * The <see cref="CreateCategoryResource"/> resource to create the category from
     * </param>
     * <returns>
     * The <see cref="CategoryResource"/> resource created
     * </returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new category",
        Description = "Create a new category in the system",
        OperationId = "CreateCategory")]
    [SwaggerResponse(StatusCodes.Status201Created, "The category was created", typeof(CategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.Id }, categoryResource);
    }
    
    /**
     * Get category by id
     * <param name="categoryId">
     * The id of the category to get
     * </param>
     * <returns>
     * The <see cref="CategoryResource"/> resource with the given id
     * </returns>
     */
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Get category by id",
        Description = "Get a category by its id",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The category was found", typeof(CategoryResource))]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category is null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    /**
     * Get all categories
     * <returns>
     * The <see cref="CategoryResource"/> resources for all categories
     * </returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories in the system",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The categories were found", typeof(IEnumerable<CategoryResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var categoryResources = categories.Select(
            CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }
}