using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.BookMarks
{
    public class BookMarkDTO: AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public int MarkPage { get; set; }
        public string MarkAnnotation { get; set; }//书签注释
        public DateTime LastUpdateTime { get; set; }//上次更新时间
        //创建时间好像不需要在这里出现
    }
}
