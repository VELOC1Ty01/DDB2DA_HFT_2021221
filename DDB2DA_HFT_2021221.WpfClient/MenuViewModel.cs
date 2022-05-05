using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDB2DA_HFT_2021221.WpfClient
{
    internal class MenuViewModel
    {
        public ICommand DriversCommand { get; set; }
        public ICommand TeamsCommand { get; set; }
        public ICommand GpCommand { get; set; }
        public ICommand QuerryCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        public MenuViewModel()
        {
            DriversCommand = new RelayCommand(() =>
            {
                DriverEditorWindow driverEditor = new DriverEditorWindow();
                driverEditor.ShowDialog();
            });

            TeamsCommand = new RelayCommand(() =>
            {
                TeamEditorWindow teamEditor = new TeamEditorWindow();
                teamEditor.ShowDialog();
            });

            GpCommand = new RelayCommand(() =>
            {
                GpEditorWindow gpEditor = new GpEditorWindow();
                gpEditor.ShowDialog();
            });

            QuerryCommand = new RelayCommand(() =>
            {
                QuerryWindow querryWindow = new QuerryWindow();
                querryWindow.ShowDialog();
            });

            ExitCommand = new RelayCommand(() => Environment.Exit(0));
        }
    }
}
