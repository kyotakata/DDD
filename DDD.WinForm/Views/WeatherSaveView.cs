using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
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
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel = new WeatherSaveViewModel();

        public WeatherSaveView()
        {
            InitializeComponent();

            AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //AreasComboBox./*SelectedValue*/
            this.AreaIdComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            //AreasComboBox.DataSourceに取り出したAreasをバインド
            this.AreaIdComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);// 内部的な値
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);// 表示される値
            this.DateTimeTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateValue));
            ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //ConditionComboBox./*SelectedValue*/
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            //ConditionComboBox.DataSourceに取り出したAreasをバインド
            this.ConditionComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);// 内部的な値
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);// 表示される値
            this.TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
            this.UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            SaveButton.Click += (_,__) =>
            {
                try
                {
                    _viewModel.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

        }
    }
}
