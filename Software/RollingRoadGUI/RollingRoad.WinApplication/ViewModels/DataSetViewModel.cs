﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using RollingRoad.Data;

namespace RollingRoad.WinApplication.ViewModels
{
    public class DataSetViewModel : BindableBase
    {
        private IDataset DataSet { get; set; }

        public DataSetViewModel(IDataset dataset)
        {
            DataSet = dataset;
            DataSet.Collection = new ObservableCollection<DataList>(DataSet.Collection);
            Collection = new ObservableCollection<DataListViewModel>(DataSet.Collection.Select(x => new DataListViewModel(x)));
        }

        public string Name => DataSet.Name;
        public string Description => DataSet.Description;

        public bool IsSelected { get; set; }

        public IList<DataListViewModel> Collection { get; set; }
    }
}
