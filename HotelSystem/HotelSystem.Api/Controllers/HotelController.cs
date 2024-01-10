namespace HotelSystem.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class HotelController(IHotelRepository hotelRepository) : ControllerBase
{
    private readonly IHotelRepository _repository = hotelRepository;
    // Hotel/getByPrice
    [HttpGet("getByPrice")]
    public async Task<IActionResult> Getbyprice(int minPrice, int maxPrice)
    {
        var result = await _repository.Getbyprice(minPrice, maxPrice);
        if (!result.Any())
            return NotFound();
        return Ok(result);

    }
    // Hotel
    [HttpPost]
    public async Task<IActionResult> Post(Hotel hotel)
    {
        var result = await _repository.modify(hotel);
        if (result != "success")
            return BadRequest(result);
        return Ok();

    }
    // Hotel
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _repository.GetAll();
        if (!result.Any())
            return NoContent();
        return Ok(result);

    }
    // Hotel/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _repository.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);

    }
    // Hotel/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repository.Delete(id);
        if (result == null)
            return NotFound();
        return Ok(result);

    }
    // Hotel
    [HttpPut]
    public async Task<IActionResult> Put(Hotel hotel)
    {
        var result = await _repository.modify(hotel);
        if (result == "not found")
            return NotFound();
        else if(result == "success")
            return Ok(result);
        else
            return BadRequest(result);

    }

}
