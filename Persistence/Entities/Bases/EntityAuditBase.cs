using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities.Bases
{
    public class EntityAuditBase
    {
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;

        public Guid? CreateBy { get; set; } // người đầu tiên thì null

        public DateTimeOffset? UpdateDate { get; set;} = DateTimeOffset.Now;

        public Guid? UpdateBy { get; set; }

        // đoạn này biết được ai thay đổi, ai khởi tạo
    }
}
