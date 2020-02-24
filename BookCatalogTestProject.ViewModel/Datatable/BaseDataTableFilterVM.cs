using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogTestProject.ViewModel.Datatable
{
    public class BaseDataTableFilterVM
    {
        public BaseDataTableFilterVM()
        {
            Order = new List<DataTableOrderVM>();
            Columns = new List<DataTableColumnVM>();
        }
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<DataTableOrderVM> Order { get; set; }
        public List<DataTableColumnVM> Columns { get; set; }
        public DataTableSearchVM Search { get; set; }
    }
}
