namespace HotelSystem.Model.Model;
public class Room:BaseModel
{

    [Required]
    public required string Specification { get; set; }

    [Required]
    public required int Price { get; set; } = 0;
    public required int HotelId { get; set; }
    [JsonIgnore]
    public virtual Hotel? Hotel { get;}
}
