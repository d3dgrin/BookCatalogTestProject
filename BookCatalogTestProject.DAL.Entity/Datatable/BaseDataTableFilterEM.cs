using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.DAL.Entity.Datatable
{
    public class BaseDataTableFilterEM
    {
        public BaseDataTableFilterEM()
        {

        }

        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<DataTableOrderEM> Order { get; set; }
        public List<DataTableColumnEM> Columns { get; set; }
        public string OrderColumnName { get; set; } // first column of collection
        public bool IsAscOrder { get; set; } // direction of the first column
        public string SearchExpression { get; set; }
    }
}
