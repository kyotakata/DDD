using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.WPF.ViewModels
{
	public class WeatherSaveViewModel : BindableBase, IDialogAware
	{
        public WeatherSaveViewModel()
        {

        }

        public string Title => "登録画面";

        /// <summary>
        /// 画面閉じられたときのイベントハンドラ
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 画面閉じることができるか
        /// </summary>
        /// <returns>trueだと閉じることができる</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
