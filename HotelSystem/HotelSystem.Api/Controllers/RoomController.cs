namespace HotelSystem.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RoomController(IRoomRepository repository) : ControllerBase
{
    private readonly IRoomRepository _repository = repository;
    // Room
    [HttpPost]
    public async Task<IActionResult> Post(Room room)
    {
        var result = await _repository.modify(room);
        if (result != "success")
            return BadRequest(result);
        return Ok();

    }
    // Room
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _repository.GetAll();
        if (!result.Any())
            return NoContent();
        return Ok(result);

    }
    // Room/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _repository.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);

    }
    // Room/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repository.Delete(id);
        if (result == null)
            return NotFound();
        return Ok(result);

    }
    // Room
    [HttpPut]
    public async Task<IActionResult> Put(Room room)
    {var result = await _repository.modify(room);
        if (result == "not found")
            return NotFound();
        else if (result == "success")
            return Ok(result);
        else
            return BadRequest(result);

    }
}
