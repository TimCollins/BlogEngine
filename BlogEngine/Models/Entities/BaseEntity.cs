using System;
using System.ComponentModel;

namespace BlogEngine.Models.Entities
{
    public abstract class BaseEntity
    {
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        
        [DisplayName("Modified On")]
        public DateTime ModifiedOn { get; set; }

        [DisplayName("Created By")]
        public long CreatedBy { get; set; }
        
        [DisplayName("Modified By")]
        public long ModifiedBy { get; set; }
    }
}