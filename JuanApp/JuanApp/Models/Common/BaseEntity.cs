namespace JuanApp.Models.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
