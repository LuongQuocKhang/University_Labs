using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common;

namespace University.Domain.Entities
{
    [Table("SecuredUser")]
    public class SecuredUser : EntityBase
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Credit { get; set; }
        public string IsDeleted { get; set; }
    }
}
