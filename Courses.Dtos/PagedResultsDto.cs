using System.Collections.Generic;

namespace Courses.Dtos
{
    public class PagedResultsDto<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}