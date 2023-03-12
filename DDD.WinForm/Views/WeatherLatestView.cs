using DDD.Domain.Entities;
using DDD.WinForm.ViewModels;
using DDD.WinForm.Views;
using System;
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

        private void ListButton_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }
    }
}
