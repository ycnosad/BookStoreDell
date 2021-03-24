using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public Guid AuthorId { get; set; }

        internal Book(
            Guid id,
            [NotNull] string name,
            [NotNull] BookType type,
            [NotNull] DateTime publishDate,
            [NotNull] float price,
            [NotNull] Guid authorId
            ):base(id)
        {
            Name = name;
            Type = type;
            PublishDate = publishDate;
            Price = price;
            AuthorId = authorId;
        }
    }
}
