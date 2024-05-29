using System.ComponentModel.DataAnnotations;

namespace Unik.Domain.Shared
{
    /// <summary>
    /// Entity base class. Har DateOfCreation, CreatedBy, LastModifiedDate og RowVersion
    /// </summary>
    public class BaseEntity
    {
        public DateTime DateOfCreation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; } = [];
    }
}
