namespace E2E.Core.Interfaces.Models
{
    public interface ITestEntity
    {
        int Id { get; set; }

        string Name { get; set; }

        dynamic Entity { get; set; }
    }
}
