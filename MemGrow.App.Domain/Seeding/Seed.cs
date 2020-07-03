namespace MemGrow.App.Domain.Seeding
{
    public class Seed
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int SeedCategoryId { get; set; }

        public virtual SeedCategory SeedCategory { get; set; }
    }
}
