namespace HotelSystem.Model.Model;

public class Hotel : BaseModel
{
    [Required]
    public required string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Room>? Rooms { get; }
}
