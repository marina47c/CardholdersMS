using AutoMapper;
using CardholderManagementSystem.Data;
using CardholderManagementSystem.DTOs;
using CardholderManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardholderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CardholdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CardholdersController> _logger;

        public CardholdersController(AppDbContext context, IMapper mapper, ILogger<CardholdersController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cardholder>>> GetCardholders(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20, 
            CancellationToken ct = default)
        {
            const int maxPageSize = 100;
            page = page < 1 ? 1 : page;
            pageSize = pageSize is < 1 ? 20 : Math.Min(pageSize, maxPageSize);

            _logger.LogInformation("Fetching cardholders page {Page} with size {PageSize}", page, pageSize);

            try
            {
                var query = _context.Cardholders.AsNoTracking().OrderBy(c => c.Id);

                var totalCount = await query.CountAsync(ct);
                var entities = await query
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync(ct);

                var dtos = _mapper.Map<List<CardholderDto>>(entities);

                var response = new PagedResponse<CardholderDto>
                {
                    Items = dtos,
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };

                _logger.LogInformation("Returning {Count} cardholders (Total {Total}) for page {Page}", dtos.Count, totalCount, page);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching cardholders from the database");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Cardholder>> GetCardholder(uint id)
        {
            _logger.LogInformation("Fetching cardholder with id: {id}", id);

            try
            {
                var entity = await _context.Cardholders.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (entity == null) return NotFound();

                return Ok(_mapper.Map<CardholderDto>(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching cardholder from the database");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CardholderDto>> CreateCardholder([FromBody] CreateCardholderDto dto)
        {
            _logger.LogInformation("Add new cardholder");

            try
            {
                var entity = _mapper.Map<Cardholder>(dto);

                _context.Cardholders.Add(entity);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<CardholderDto>(entity);

                return CreatedAtAction(nameof(GetCardholder), new { id = entity.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding cardholder");
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCardholder(uint id, [FromBody] UpdateCardholderDto dto)
        {
            _logger.LogInformation("Updating cardholder with id: {id}", id);

            try
            {
                var entity = await _context.Cardholders.FirstOrDefaultAsync(c => c.Id == id);
                if (entity == null) return NotFound();

                _mapper.Map(dto, entity);

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating cardholder");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardholder(uint id)
        {
            _logger.LogInformation("Deleting cardholder with id: {id}", id);

            try
            {
                var entity = await _context.Cardholders.FindAsync(id);
                if (entity == null) return NotFound();

                _context.Cardholders.Remove(entity);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting cardholder");
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}

