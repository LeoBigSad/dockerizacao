namespace Tarefa5.Domain.Entity
{
    public abstract class Base
    {
        public Guid Id { get;  set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? RemovedDate { get; private set; }
        public bool Removed { get; private set; }

        protected Base(Guid id = default)
        {
            if (id != default)
            {
                Id = id;
            }
            CreatedDate = DateTime.UtcNow;
            Removed = false;
        }

        public virtual void Update()
        {
            UpdatedDate = DateTime.UtcNow;
        }

        public virtual void Remove()
        {
            RemovedDate = DateTime.UtcNow;
            Removed = true;
        }
    }

}
