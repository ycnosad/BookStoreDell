using Acme.BookStore.Books;
using Acme.BookStore.Authors; // ADDED NAMESPACE IMPORT
using AutoMapper;
using Acme.BookStore.BookMarks;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<BookDto, CreateUpdateBookDto>();
            CreateMap<BookMarkDTO, CreateUpdateBookMarkDto>();
            // ADD a NEW MAPPING
            
            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,CreateAuthorDto>();
            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,UpdateAuthorDto>();

            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            
            CreateMap<Pages.BookMarks.CreateModalModel.CreateBookMarkViewModel, CreateUpdateBookMarkDto>();
            CreateMap<BookMarkDTO, Pages.BookMarks.EditModalModel.EditBookMarkViewModel>();
        }
    }
}
