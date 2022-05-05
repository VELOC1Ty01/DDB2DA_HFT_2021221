using DDB2DA_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDB2DA_HFT_2021221.WpfClient
{
    class DriverEditorViewModel : ObservableRecipient
    {
        public RestCollection<Driver> Drivers { get; set; }

        private Driver selectedDriver;

        public Driver SelectedDriver 
        { 
            get { return selectedDriver; }
            set {
                SetProperty(ref selectedDriver, value);
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                ShortNameField = value?.ShortName; 
                FirstNameField = value?.FirstName;
                LastNameField = value?.LastName;
                //TeamIdField = value.TeamId;
                NationField = value?.Nationality;
                //DriverIdField = value.Id;

                //ShortNameField = value != null? value.ShortName : String.Empty;

                TeamIdField = value != null ? value.TeamId : 0;

                DriverIdField = value != null ? value.Id : 0;
            }    
        }

        private int driverIdField;
        public int DriverIdField
        {
            get { return driverIdField; }
            set
            {
                SetProperty(ref driverIdField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string firstNameField;
        public string FirstNameField
        {
            get { return firstNameField; }
            set
            {
                SetProperty(ref firstNameField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string lastNameField;
        public string LastNameField
        {
            get { return lastNameField; }
            set
            {
                SetProperty (ref lastNameField, value);
                (AddCommand as RelayCommand ).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string shortNameField;
        public string ShortNameField
        {
            get { return shortNameField; }
            set
            {
                SetProperty(ref shortNameField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string nationField;
        public string NationField
        {
            get { return nationField; }
            set
            {
                SetProperty(ref nationField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private int teamIdField;
        public int TeamIdField
        {
            get { return teamIdField; }
            set
            {
                SetProperty(ref teamIdField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public DriverEditorViewModel()
        {
            Drivers = new RestCollection<Driver>("http://localhost:21304/", "Driver", "hub");

            AddCommand = new RelayCommand(
                () => Drivers.Add(new Driver { FirstName = FirstNameField, LastName = LastNameField, ShortName = ShortNameField,
                    Nationality = NationField, TeamId = TeamIdField }),

                () => FirstNameField != null && FirstNameField.Trim().Length != 0
                        && LastNameField != null && LastNameField.Trim().Length != 0 
                        && ShortNameField != null && ShortNameField.Length == 3
                        && NationField != null && NationField.Length == 3);

            UpdateCommand = new RelayCommand(
                () =>
                {
                    SelectedDriver.Id = DriverIdField;
                    SelectedDriver.ShortName = ShortNameField;
                    SelectedDriver.LastName = LastNameField;
                    SelectedDriver.FirstName = FirstNameField;
                    SelectedDriver.TeamId = TeamIdField;
                    SelectedDriver.Nationality = NationField;
                    Drivers.Update(SelectedDriver);
                },
                () => SelectedDriver != null
                    && FirstNameField != null
                    && LastNameField != null
                    && ShortNameField != null
                    && NationField != null);

            RemoveCommand = new RelayCommand(
                () => Drivers.Delete(SelectedDriver.Id),
                () => SelectedDriver != null);
        }

    }


}
