namespace HotelSystem.IRepository
{
    public interface IRoomRepository
    {
        public Task<List<Room>?> GetAll();
        public Task<Room> GetById(int id);
        public Task<Room> Delete(int id);
        public Task<string> modify(Room room);
    }
}
