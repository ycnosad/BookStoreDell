using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.BookMarks
{
    public class BookMark:AuditedAggregateRoot<Guid>
    {
        public int MyProperty { get; set; }
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public int MarkPage { get; set; }
        public string MarkAnnotation { get; set; }//书签注释
        public DateTime LastUpdateTime { get; set; }//上次更新时间
        public BookMark()
        {

        }
    }
}
    