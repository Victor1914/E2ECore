namespace E2E.Core.Models.Entities
{
    using Interfaces.Models;

    public class TestEntity : ITestEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public dynamic Entity { get; set; }
    }
}
