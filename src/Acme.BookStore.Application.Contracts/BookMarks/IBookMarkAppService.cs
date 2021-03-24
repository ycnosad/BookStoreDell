using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        //Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
        Task<ListResultDto<BookLookupDto>> GetBookLookupAsync();
    }
}
