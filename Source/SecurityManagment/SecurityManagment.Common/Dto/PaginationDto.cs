using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI.WebControls;

    public class PaginationDto
    {
        public PaginationDto(int startRowIndex, int maximumRows, string sortProperty = null)
        {
            this.Skip = startRowIndex;
            this.PageSize = maximumRows;

        }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int Skip { get; set; }

        public string SortDirection { get; set; }

        public string SortDirectionAbbreviation { get; set; }

        public string SortExpression { get; set; }
    }
}
