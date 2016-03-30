﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using RollingRoad.Data;

namespace RollingRoad.WinApplication
{
    public class DataSetsViewModel
    {
        public ObservableCollection<DataSetViewModel> DataSets { get; set; } = new ObservableCollection<DataSetViewModel>();
        public ObservableCollection<DataSetViewModel> SelectedDataSets { get; set; } = new ObservableCollection<DataSetViewModel>();

        public DataSetsViewModel()
        {
            OpenSelectWindow = new DelegateCommand(OpenSelect);
            SelectedChanged = new DelegateCommand(OnSelectedChanged);
        }

        public ICommand OpenSelectWindow { get; }
        public ICommand SelectedChanged { get; }

        private void OnSelectedChanged()
        {
            SelectedDataSets.Clear();

            foreach (DataSetViewModel dataSetViewModel in DataSets)
            {
                if (dataSetViewModel.IsSelected)
                {
                    SelectedDataSets.Add(dataSetViewModel);
                }
            }
        }

        private void OpenSelect()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv"
            };
            
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                try
                {
                    MemoryDataset dataset = CsvDataFile.LoadFromFile(filename);

                    DataSets.Add(new DataSetViewModel(dataset));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error opening file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        public override string ToString()
        {
            return "View & compare";
        }
    }
}