using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(
            IMapper mapper,
            IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // CREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel =
                mapper.Map<Models.Domain.Walk>(addWalkRequestDto);

            walkDomainModel =
                await walkRepository.CreateAsync(walkDomainModel);

            var walkDto =
                mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();

            var walksDto =
                mapper.Map<List<WalkDto>>(walksDomainModel);

            return Ok(walksDto);
        }

        // GET Walk by Id
        // GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel =
                await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk By Id
        // PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel =
                mapper.Map<Models.Domain.Walk>(updateWalkRequestDto);

            // Update walk in database
            walkDomainModel =
                await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Delete a Walk By Id
        // DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel =
                await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }

    }

}