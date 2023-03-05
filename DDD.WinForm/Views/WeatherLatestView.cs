using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using DDD.WinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();
        public WeatherLatestView()
        {
            InitializeComponent();
            AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //AreasComboBox./*SelectedValue*/
            this.AreasComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            //AreasComboBox.DataSourceに取り出したAreasをバインド
            this.AreasComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);// 内部的な値
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);// 表示される値

            this.DataDateLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));

        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            // データバインドしていなかったら、Search関数にAreaIdを引数として渡してあげないといけない
            // データバインドしているので、テキストボックスの値が変化すると_viewModel.AreaIdTextに値が入る
            _viewModel.Search();

        }

    }
}
