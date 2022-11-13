using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.Package;
using Span.Culturio.Api.Services.Package;

namespace Span.Culturio.Api.Controllers {
    [Tags("Packages")]
    [Route("packages")]
    [ApiController]
    public class PackageController : ControllerBase {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService) {
            _packageService = packageService;
        }
        /// <summary>
        /// Create package
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePackageAsync([FromBody] CreatePackageDto createPackageDto) {
            var package = await _packageService.CreatePackageAsync(createPackageDto);
            return Ok(package);
        }
        /// <summary>
        /// Get paclages
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPackagesAsync() {
            var packages = await _packageService.GetPackagesAsync();
            return Ok(packages);
        }
    }
}
