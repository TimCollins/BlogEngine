using System;

namespace BlogEngine.Models.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}