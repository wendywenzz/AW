using Core.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    [GeneratedController("api/book", false)]
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }
    }
}
