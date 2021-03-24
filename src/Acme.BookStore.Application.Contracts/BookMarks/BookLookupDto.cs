using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.BookMarks
{
    public class BookLookupDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
