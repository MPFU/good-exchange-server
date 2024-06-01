namespace goods_server.Contracts
{
    public class CategoryDTO
    {
        public string Name { get; set; }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class GetCategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
