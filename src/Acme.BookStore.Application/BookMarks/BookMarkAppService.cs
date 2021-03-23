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
    public class BookMarkAppService :
        CrudAppService<
            BookMark, //The Book entity
            BookMarkDTO, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookMarkDto>, //Used to create/update a book
        IBookMarkAppService //implement the IBookAppService
    {
        public BookMarkAppService(IRepository<BookMark,Guid> repository ):base(repository)
        {

        }
    }
}   
