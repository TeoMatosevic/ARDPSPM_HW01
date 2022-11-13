using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.CultureObjects;
using Span.Culturio.Api.Services.CultureObject;
using System.ComponentModel.DataAnnotations;

namespace Span.Culturio.Api.Controllers {
    [Tags("Culture Objects")]
    [Route("culture-objects")]
    [ApiController]
    public class CultureObjectController : ControllerBase {
        private readonly IValidator<CreateCultureObjectDto> _validator;
        private readonly ICultureObjectService _cultureObjectService;


        public CultureObjectController(IValidator<CreateCultureObjectDto> validator, ICultureObjectService cultureObjectService) {
            _validator = validator;
            _cultureObjectService = cultureObjectService;
        }

        /// <summary>
        /// Create new culture object
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<string>> CreateCultureObject([Required] CreateCultureObjectDto req) {
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(req);
            if (!result.IsValid) {
                return BadRequest("Validation error");
            }

            var cultureObjectDto = await _cultureObjectService.CreateCultureObjectAsync(req);

            return Ok("Successful response");

        }
        /// <summary>
        /// Get culture object by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CultureObjectDto>> Get(int id) {
            var cultureObjectDto = await _cultureObjectService.GetCultureObjectAsync(id);
            if (cultureObjectDto is null) {
                return NotFound("Not found");
            }

            return Ok(cultureObjectDto);
        }
        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CultureObjectDto>>> Get() {
            var cultureObjectsDto = await _cultureObjectService.GetCultureObjectsAsync();
            return Ok(cultureObjectsDto);
        }
    }
}