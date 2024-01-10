namespace HotelSystem.Repository;

public class HotelRepository(HotelDbContext context) : IHotelRepository
{
    private readonly HotelDbContext _context = context;
    public async Task<List<Hotel>?> Getbyprice(int minPrice, int maxPrice)
    {
        if (await _context.Hotels.AnyAsync() == false)
            return null;
        var result = await _context.Hotels
            .Include(hotel => hotel.Rooms)
            .Where(hotel => hotel.Rooms
            .Any(room => room.Price >= minPrice && room.Price <= maxPrice))
            .ToListAsync();
        return result;
    }
    public async Task<List<Hotel>?> GetAll()
    {
            if (await _context.Hotels.AnyAsync() == false)
                return null;
            var result = await _context.Hotels.ToListAsync();
            return result;
    }
    public async Task<Hotel> GetById(int id)
    {
        var result = await _context.Hotels.FindAsync(id);
        return result;
    }
    public async Task<Hotel> Delete(int id)
    {
        var result = await _context.Hotels.FindAsync(id);
        if (result == null)
            return null;
        _context.Hotels.Remove(result);
        await _context.SaveChangesAsync();
        return result;
    }
    public async Task<string> modify(Hotel hotel)
    {
        if (hotel.Id == 0)
        {
            await _context.Hotels.AddAsync(hotel);
        }
        else
        {
            if (!await _context.Hotels.AnyAsync(e => e.Id == hotel.Id))
                return "not found";
            _context.Hotels.Update(hotel);
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
