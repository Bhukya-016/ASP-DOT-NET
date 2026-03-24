using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(
            IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();

            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionsDto);
        }

        // GET: api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST: api/regions
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO → Domain
            var regionDomainModel =
                mapper.Map<Region>(addRegionRequestDto);

            // Create Region
            regionDomainModel =
                await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain → DTO
            var regionDto =
                mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(
                nameof(GetById),
                new { id = regionDto.Id },
                regionDto);
        }

        // PUT: api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO → Domain
            var regionDomainModel =
                mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel =
                await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        // DELETE: api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel =
                await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}