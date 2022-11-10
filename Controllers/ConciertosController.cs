using AutoMapper;
using Beca.ConciertoInfo.API;
using Beca.ConciertoInfo.API.Entities;
using Beca.ConciertoInfo.API.Models;
using Beca.ConciertoInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Text.Json;

namespace ConciertoInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Route("api/conciertos")]
    public class ConciertosController : ControllerBase
    {
        private readonly IConciertoInfoRepository _conciertoInfoRepository;
        private readonly IMapper _mapper;
        const int maxConciertosPageSize = 20;

        public ConciertosController(IConciertoInfoRepository conciertoInfoRepository,
            IMapper mapper)
        {
            _conciertoInfoRepository = conciertoInfoRepository ??
                throw new ArgumentNullException(nameof(conciertoInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConciertoWithoutCancionesDto>>> GetConciertos(
            string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxConciertosPageSize)
            {
                pageSize = maxConciertosPageSize;
            }

            var (conciertoEntities, paginationMetadata) = await _conciertoInfoRepository
                .GetConciertosAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<ConciertoWithoutCancionesDto>>(conciertoEntities));
        }

        /// <summary>
        /// Get a concierto by id
        /// </summary>
        /// <param name="id">The id of the concierto to get</param>
        /// <param name="includeCanciones">Whether or not to include canciones</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested concierto</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConcierto(
            int id, bool includeCanciones = false)
        {
            var concierto = await _conciertoInfoRepository.GetConciertoAsync(id, includeCanciones);
            if (concierto == null)
            {
                return NotFound();
            }

            if (includeCanciones)
            {
                return Ok(_mapper.Map<ConciertoDto>(concierto));
            }

            return Ok(_mapper.Map<ConciertoWithoutCancionesDto>(concierto));
        }
    }
}
