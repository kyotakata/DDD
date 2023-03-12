﻿using ChainingAssertion;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var viewModelMock = new Mock<WeatherSaveViewModel>();
            viewModelMock.Setup(x => x.GetDateTime()).Returns(Convert.ToDateTime("2018/01/01 12:34:56"));
            var viewModel = viewModelMock.Object;
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
        }
    }
}