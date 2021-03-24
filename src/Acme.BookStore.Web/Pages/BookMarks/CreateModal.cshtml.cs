using Acme.BookStore.BookMarks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Acme.BookStore.Web.Pages.BookMarks
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        //public CreateUpdateBookMarkDto BookMark { get; set; }
        public CreateBookMarkViewModel BookMark { get; set; }

        private readonly IBookMarkAppService _bookMarkAppService;

        //public List<SelectItems> Books { get; set; }
        public List<SelectListItem> Books { get; set; }

        public CreateModalModel(IBookMarkAppService bookMarkAppService)
        {
            _bookMarkAppService = bookMarkAppService;
        }

        public async Task OnGetAsync()
        {
            BookMark = new CreateBookMarkViewModel();

            var bookLookup = await _bookMarkAppService.GetBookLookupAsync();
            Books = bookLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }   

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookMarkAppService.CreateAsync(
                ObjectMapper.Map<CreateBookMarkViewModel, CreateUpdateBookMarkDto>(BookMark)
                );
            return NoContent();
        }

        public class CreateBookMarkViewModel
        {
            [SelectItems(nameof(Books))]
            [DisplayName("Book")]
            public Guid BookId { get; set; }
            //public string BookName { get; set; }
            [Required]
            public int MarkPage { get; set; }
            public string MarkAnnotation { get; set; }//书签注释
            [Required]
            [DataType(DataType.DateTime)]
            public DateTime LastUpdateTime { get; set; } = DateTime.Now;//上次更新时间
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using Acme.BookStore.BookMarks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

//namespace Acme.BookStore.Web.Pages.BookMarks
//{
//    public class CreateModalModel : BookStorePageModel
//    {
//        [BindProperty]
//        public CreateBookMarkViewModel BookMark { get; set; }
//        private readonly IBookMarkAppService _bookMaekAppService;
//        public CreateModalModel(IBookMarkAppService bookMarkAppService)
//        {
//            this._bookMaekAppService = bookMarkAppService;
//        }
//        public void OnGet()
//        {
//            BookMark = new CreateBookMarkViewModel();

//        }
//        public async Task<IActionResult> OnPostAsync()
//        {
//            var dto = ObjectMapper.Map<CreateBookMarkViewModel, CreateUpdateBookMarkDto>(BookMark);
//            await _bookMaekAppService.CreateAsync(dto);
//            return NoContent();
//        }

//        public class CreateBookMarkViewModel
//        {
//            [Required]
//            public Guid BookId { get; set; }
//            [Required]
//            public string BookName { get; set; }
//            [Required]
//            public int MarkPage { get; set; }
//            [Required]
//            [TextArea]
//            public string MarkAnnotation { get; set; }//书签注释
//            [Required]
//            [DataType(DataType.DateTime)]
//            public DateTime LastUpdateTime { get; set; }//上次更新时间

//            [Required]
//            [DataType(DataType.DateTime)]
//            public DateTime CreationTime { get; set; }//上次更新时间
//        }
//    }
//}
