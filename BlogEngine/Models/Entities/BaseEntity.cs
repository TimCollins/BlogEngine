using System;

namespace BlogEngine.Models.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}