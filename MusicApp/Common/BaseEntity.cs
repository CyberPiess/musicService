namespace MusicApp.Common
{
    public class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Name { get; set; }


    }
}
