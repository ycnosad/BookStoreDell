using Acme.BookStore.Books;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.BookMarks
{
    [Authorize(BookStorePermissions.BookMarks.Default)]
    public class BookMarkAppService :
        CrudAppService<
            BookMark, //The Book entity 
            BookMarkDTO, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookMarkDto>, //Used to create/update a book
        IBookMarkAppService //implement the IBookAppService
    {

        private readonly IBookRepository _bookRepository;
        public BookMarkAppService(IRepository<BookMark,Guid> repository ):base(repository)
        {
            GetPolicyName = BookStorePermissions.BookMarks.Default;
            GetListPolicyName = BookStorePermissions.BookMarks.Default;
            CreatePolicyName = BookStorePermissions.BookMarks.Create;
            UpdatePolicyName = BookStorePermissions.BookMarks.Edit;
            DeletePolicyName = BookStorePermissions.BookMarks.Create;
        }

        public async Task<ListResultDto<BookLookupDto>> GetBookLookupAsync()
        {
            var books = await _bookRepository.GetListAsync();
            return new ListResultDto<BookLookupDto> (ObjectMapper.Map<List<Book>, List<BookLookupDto>>(books));
        }
    }
}   
