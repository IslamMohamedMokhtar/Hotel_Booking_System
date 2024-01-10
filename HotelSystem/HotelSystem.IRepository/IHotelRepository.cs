namespace HotelSystem.IRepository;

public interface IHotelRepository
{
    public Task<List<Hotel>> Getbyprice(int minPrice, int maxPrice);
    public Task<List<Hotel>?> GetAll();
    public Task<Hotel> GetById(int id);
    public Task<Hotel> Delete(int id);
    public Task<string> modify(Hotel hotel);


}
