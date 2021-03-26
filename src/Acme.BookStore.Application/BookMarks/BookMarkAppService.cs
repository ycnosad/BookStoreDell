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

        //这里就是复制下来的内容111111111111111111111111111111111111111111111
        public override async Task<PagedResultDto<BookMarkDTO>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Book.Name);
            }

            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from book in queryable
                        join author in _authorRepository on book.AuthorId equals author.Id
                        orderby input.Sorting //TODO: Can not sort like that!
                        select new { book, author };

            //Paging
            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<BookDto>(
                totalCount,
                bookDtos
            );
        }
    }
}   
