using DDD.Domain.Repositories;
using DDD.WinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _viewModel = new WeatherListViewModel();

        public WeatherListView()
        {
            InitializeComponent();

            WeathersDataGrid.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Weathers));
        }
    }
}
