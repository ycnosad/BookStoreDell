using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.BookMarks
{
    public interface IBookMarkAppService:
        ICrudAppService<
            BookMarkDTO,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBookMarkDto>
    {
    }
}
