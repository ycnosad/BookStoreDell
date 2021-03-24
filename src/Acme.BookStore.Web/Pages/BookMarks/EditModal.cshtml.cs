using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.BookMarks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.BookMarks
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditBookMarkViewModel BookMark { get; set; }

        public List<SelectListItem> Books { get; set; }

        private readonly IBookMarkAppService _bookMarkAppService;
        public EditModalModel(IBookMarkAppService bookMarkAppService)
        {
            _bookMarkAppService = bookMarkAppService;
        }
        public async Task OnGetAsync(Guid id)
        {
            var bookMarkDto = await _bookMarkAppService.GetAsync(id);
            BookMark = ObjectMapper.Map<BookMarkDTO, EditBookMarkViewModel>(bookMarkDto);

            var bookLookup = await _bookMarkAppService.GetBookLookupAsync();
            Books = bookLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //await _bookMarkAppService.UpdateAsync(
            //        BookMark.Id,
            //        ObjectMapper.Map<EditBookMarkViewModel, CreateUpdateBookMarkDto>(BookMark)

            //    );
            //return NoContent();
            await _bookMarkAppService.UpdateAsync(
                BookMark.Id,
                ObjectMapper.Map<EditBookMarkViewModel,CreateUpdateBookMarkDto>(BookMark)
                );
            return NoContent();
        }

        public class EditBookMarkViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Books))]
            [DisplayName("Book")]
            public Guid BookId { get; set; }
            [Required]
            public int MarkPage { get; set; }
            [Required]
            [TextArea]
            public string MarkAnnotation { get; set; }//书签注释
            [Required]
            [DataType(DataType.DateTime)]
            public DateTime LastUpdateTime { get; set; } = DateTime.Now;//上次更新时间
        }
    }
}


//using System;
//using System.Threading.Tasks;
//using Acme.BookStore.BookMarks;
//using Microsoft.AspNetCore.Mvc;

//namespace Acme.BookStore.Web.Pages.BookMarks
//{
//    public class EditModalModel : BookStorePageModel
//    {
//        [HiddenInput]
//        [BindProperty(SupportsGet = true)]
//        public Guid Id { get; set; }

//        [BindProperty]
//        public CreateUpdateBookMarkDto BookMark { get; set; }

//        private readonly IBookMarkAppService _bookMarkAppService;

//        public EditModalModel(IBookMarkAppService bookAppService)
//        {
//            _bookMarkAppService = bookAppService;
//        }

//        public async Task OnGetAsync()
//        {
//            var bookMarkDto = await _bookMarkAppService.GetAsync(Id);
//            BookMark = ObjectMapper.Map<BookMarkDTO, CreateUpdateBookMarkDto>(bookMarkDto);
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            await _bookMarkAppService.UpdateAsync(Id, BookMark);
//            return NoContent();
//        }
//    }
//}