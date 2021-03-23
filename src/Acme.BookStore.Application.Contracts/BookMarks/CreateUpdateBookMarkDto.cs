using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.BookMarks
{
    public class CreateUpdateBookMarkDto
    {
        public Guid BookId { get; set; }
        
        [Required]
        [StringLength(128)]
        public string BookName { get; set; }
        [Required]
        public int MarkPage { get; set; }

        public string MarkAnnotation { get; set; }//书签注释
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUpdateTime { get; set; }//上次更新时间

    }
}
