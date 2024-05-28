namespace goods_server.Contracts
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Descript { get; set; }
        public int? Rated { get; set; }
    }
}
