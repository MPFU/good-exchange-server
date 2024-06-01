// CreateCityDTO.cs
namespace goods_server.Contracts
{
    public class CreateCityDTO
    {
        public string Name { get; set; }
    }
}

// UpdateCityDTO.cs
namespace goods_server.Contracts
{
    public class UpdateCityDTO
    {
        public string Name { get; set; }
    }
}

// GetCityDTO.cs
namespace goods_server.Contracts
{
    public class GetCityDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
