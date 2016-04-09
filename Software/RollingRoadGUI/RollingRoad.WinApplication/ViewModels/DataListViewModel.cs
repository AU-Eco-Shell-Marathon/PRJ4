﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using RollingRoad.Data;

namespace RollingRoad.WinApplication.ViewModels
{
    public class DataListViewModel : BindableBase
    {
        public DataList List { get; }

        public DataListViewModel(DataList list)
        {
            List = list;
            //List.Data = new ObservableCollection<double>(List.Data);
        }

        public DataType Type => List.Type;

        public void Add(double value)
        {
            List.Add(value);
            OnPropertyChanged(nameof(NewestValue));
        }
        
        public double NewestValue => List.Last();

        public int Count => List.Count;
        public bool Selected { get; set; } = true;
        public IReadOnlyCollection<double> Data => List;
    }
}
