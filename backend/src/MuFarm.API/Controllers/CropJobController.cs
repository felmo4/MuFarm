using Microsoft.AspNetCore.Mvc;
using MuFarm.Application.DTOs.CropJob;
using MuFarm.Application.Interfaces.Services;

namespace MuFarm.API.Controllers
{
    [ApiController]
    [Route("api/cropjobs")]
    public class CropJobController : Controller
    {
        private readonly ICropJobService _cropJobService;

        public CropJobController(ICropJobService cropJobService)
        {
            this._cropJobService = cropJobService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCropJobRequest request)
        {
            var cropJobId = await _cropJobService.PlantCropAsync(request.CropId);
            return Created();
            //return CreatedAtAction(nameof(GetById), new { id = cropJobId }, null);
        }

    }
}
