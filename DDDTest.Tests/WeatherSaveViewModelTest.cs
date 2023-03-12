﻿using ChainingAssertion;
using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var weatherMock = new Mock<IＷeatherRepository>();
            var areasMock = new Mock<IAreasRepository>();
            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));
            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object, areasMock.Object);
            viewModelMock.Setup(x => x.GetDateTime()).Returns(Convert.ToDateTime("2018/01/01 12:34:56"));
            var viewModel = viewModelMock.Object;
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");

            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            var ex = Assert.ThrowsException<InputException>(() => viewModel.Save());
            ex.Message.Is("エリアを選択してください");

            viewModel.SelectedAreaId = 2;
            ex = Assert.ThrowsException<InputException>(() => viewModel.Save());
            ex.Message.Is("温度の入力に誤りがあります");

            viewModel.TemperatureText = "12.345";

            weatherMock.Setup(x => x.Save(It.IsAny<WeatherEntity>())).    // おそらくここでSave関数のSetupを行う。.Returnsが指定されていないのはSave関数の戻り値の型がvoidであるため
                Callback<WeatherEntity>(saveValue =>    // 以下の行で型パラメータにWeatherEntityを指定して、saveValueをWeatherEntityにしてWeatherEntityの中のプロパティの値があっているか確かめる
                {
                    saveValue.AreaId.Value.Is(2);
                    saveValue.DataDate.Is(
                        Convert.ToDateTime("2018/01/01 12:34:56"));
                    saveValue.Condition.Value.Is(1);
                    saveValue.Temperature.Value.Is(12.345f);
                });

            viewModel.Save();
            weatherMock.VerifyAll();
        }
    }
}
