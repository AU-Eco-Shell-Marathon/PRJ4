﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using RollingRoad.Control;

namespace RollingRoad.WinApplication.ViewModels
{
    public class CalibrateControlViewModel : BindableBase
    {
        public DelegateCommand CalibrateCommand { get; }

        public CalibrateControlViewModel(ICalibrateControl ctrl)
        {
            CalibrateCommand = new DelegateCommand(ctrl.Calibrate);
        }
    }
}
