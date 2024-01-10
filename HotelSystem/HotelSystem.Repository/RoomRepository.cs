namespace HotelSystem.Repository;

public class RoomRepository(HotelDbContext context): IRoomRepository
{
    private readonly HotelDbContext _context = context;
    
    public async Task<List<Room>?> GetAll()
    {
        if (await _context.Hotels.AnyAsync() == false)
            return null;
        var result = await _context.Rooms.ToListAsync();
        return result;
    }
    public async Task<Room> GetById(int id)
    {
        var result = await _context.Rooms.FindAsync(id);
        return result;
    }
    public async Task<Room> Delete(int id)
    {
        var result = await _context.Rooms.FindAsync(id);
        if (result == null)
            return null;
        _context.Rooms.Remove(result);
        await _context.SaveChangesAsync();
        return result;
    }
    public async Task<string> modify(Room room)
    {
        if (room.Id == 0)
        {
            if (!await _context.Hotels.AnyAsync(e => e.Id == room.HotelId))
                return "Not Found";
            await _context.Rooms.AddAsync(room);
        }
        else
        {
            if (!await _context.Rooms.AnyAsync(e => e.Id == room.Id))
                return "not found";
            _context.Rooms.Update(room);
        }
       
        try
        {
            await _context.SaveChangesAsync();
            return "success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
