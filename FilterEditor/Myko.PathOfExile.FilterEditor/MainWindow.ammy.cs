using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myko.PathOfExile.ItemFilters;

namespace Myko.PathOfExile.FilterEditor
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ItemFilter("default.filter");
        }
    }
}
