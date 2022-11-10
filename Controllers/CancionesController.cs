using AutoMapper;
using Beca.ConciertoInfo.API.Models;
using Beca.ConciertoInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Beca.ConciertoInfo.API.Controllers
{
    [Route("api/conciertos/{conciertoId}/canciones")]
    [Authorize(Policy = "MustBeFromEvolve")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly ILogger<CancionesController> _logger;
        private readonly IConciertoInfoRepository _conciertoInfoRepository;
        private readonly IMapper _mapper;

        public CancionesController(ILogger<CancionesController> logger,
            IConciertoInfoRepository conciertoInfoRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _conciertoInfoRepository = conciertoInfoRepository ??
                throw new ArgumentNullException(nameof(conciertoInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancionDto>>> GetCanciones(
            int conciertoId)
        {

            //var cityName = User.Claims.FirstOrDefault(c => c.Type == "city")?.Value;

            //if (!await _cityInfoRepository.CityNameMatchesCityId(cityName, cityId))
            //{
            //    return Forbid();
            //}

            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                _logger.LogInformation(
                    $"El concierto con la id {conciertoId} no ha sido encontrado.");
                return NotFound();
            }

            var cancionesForConcierto = await _conciertoInfoRepository
                .GetCancionesForConciertoAsync(conciertoId);

            return Ok(_mapper.Map<IEnumerable<CancionDto>>(cancionesForConcierto));
        }

        [HttpGet("{cancionid}", Name = "GetCancion")]
        public async Task<ActionResult<CancionDto>> GetCancion(
            int conciertoId, int cancionId)
        {
            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                return NotFound();
            }

            var pointOfInterest = await _conciertoInfoRepository
                .GetCancionesForConciertoAsync(conciertoId, cancionId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CancionDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<CancionDto>> CreateCancion(
           int conciertoId,
           CancionForCreationDto cancion)
        {
            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                return NotFound();
            }

            var finalCancion = _mapper.Map<Entities.Cancion>(cancion);

            await _conciertoInfoRepository.AddCancionesForConciertoAsync(
                conciertoId, finalCancion);

            await _conciertoInfoRepository.SaveChangesAsync();

            var createdCancionToReturn =
                _mapper.Map<Models.CancionDto>(finalCancion);

            return CreatedAtRoute("GetCancion",
                 new
                 {
                     conciertoId = conciertoId,
                     cancionId = createdCancionToReturn.Id
                 },
                 createdCancionToReturn);
        }

        [HttpPut("{cancionid}")]
        public async Task<ActionResult> UpdateCancion(int conciertoId, int cancionId,
            CancionForUpdateDto cancion)
        {
            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                return NotFound();
            }

            var cancionEntity = await _conciertoInfoRepository
                .GetCancionesForConciertoAsync(conciertoId, cancionId);
            if (cancionEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(cancion, cancionEntity);

            await _conciertoInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{cancionid}")]
        public async Task<ActionResult> PartiallyUpdateCancion(
            int conciertoId, int cancionId,
            JsonPatchDocument<CancionForUpdateDto> patchDocument)
        {
            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                return NotFound();
            }

            var cancionEntity = await _conciertoInfoRepository
                .GetCancionesForConciertoAsync(conciertoId, cancionId);
            if (cancionEntity == null)
            {
                return NotFound();
            }

            var cancionToPatch = _mapper.Map<CancionForUpdateDto>(
                cancionEntity);

            patchDocument.ApplyTo(cancionToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(cancionToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(cancionToPatch, cancionEntity);
            await _conciertoInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{cancionId}")]
        public async Task<ActionResult> DeleteCancion(
            int conciertoId, int cancionId)
        {
            if (!await _conciertoInfoRepository.ConciertoExistsAsync(conciertoId))
            {
                return NotFound();
            }

            var cancionEntity = await _conciertoInfoRepository
                .GetCancionesForConciertoAsync(conciertoId, cancionId);
            if (cancionEntity == null)
            {
                return NotFound();
            }

            _conciertoInfoRepository.DeleteCanciones(cancionEntity);
            await _conciertoInfoRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}