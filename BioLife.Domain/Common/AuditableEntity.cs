
namespace BioLife.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public string? CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
