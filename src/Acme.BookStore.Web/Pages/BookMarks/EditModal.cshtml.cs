using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.BookMarks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.BookMarks
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditBookMarkViewModel BookMark { get; set; }
        private readonly IBookMarkAppService _bookMarkAppService;
        public EditModalModel(IBookMarkAppService bookMarkAppService)
        {
            _bookMarkAppService = bookMarkAppService;
        }
        public async Task OnGet(Guid id)
        {
            var bookMarkDto = await _bookMarkAppService.GetAsync(id);
            BookMark = ObjectMapper.Map<BookMarkDTO, EditBookMarkViewModel>(bookMarkDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookMarkAppService.UpdateAsync(
                    BookMark.Id,
                    ObjectMapper.Map<EditBookMarkViewModel, CreateUpdateBookMarkDto>(BookMark)

                );
            return NoContent();
        }

        public class EditBookMarkViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            public string BookName { get; set; }
            [Required]
            public int MarkPage { get; set; }
            [Required]
            [TextArea]
            public string MarkAnnotation { get; set; }//书签注释
            [Required]
            [DataType(DataType.DateTime)]
            public DateTime LastUpdateTime { get; set; }//上次更新时间
        }
    }
}
