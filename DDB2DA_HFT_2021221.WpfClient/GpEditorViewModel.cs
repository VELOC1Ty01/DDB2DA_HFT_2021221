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
    class GpEditorViewModel : ObservableRecipient
    {
        public RestCollection<GrandPrix> GrandPrixes { get; set; }

        private GrandPrix selectedGp;

        public GrandPrix SelectedGp
        {
            get { return selectedGp; }
            set
            {
                SetProperty(ref selectedGp, value);
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                NameField = value?.Name;
                DateField = value != null? value.Date.ToString() : null;
                TrackField = value?.Track;

                //ShortNameField = value != null? value.ShortName : String.Empty;


            }
        }

        private string dateField;
        public string DateField
        {
            get { return dateField; }
            set
            {
                SetProperty(ref dateField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string nameField;
        public string NameField
        {
            get { return nameField; }
            set
            {
                SetProperty(ref nameField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private string trackField;
        public string TrackField
        {
            get { return trackField; }
            set
            {
                SetProperty(ref trackField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public GpEditorViewModel()
        {
            GrandPrixes = new RestCollection<GrandPrix>("http://localhost:21304/", "GrandPrix");

            AddCommand = new RelayCommand(
                () => GrandPrixes.Add(new GrandPrix
                {
                    Name = NameField,
                    Date = DateTime.Parse(DateField),
                    Track = TrackField
                }),

                () => NameField != null && NameField.Trim().Length != 0
                );



            UpdateCommand = new RelayCommand(
                () =>
                {
                    SelectedGp.Name = NameField;
                    SelectedGp.Track = TrackField;
                    SelectedGp.Date = DateTime.Parse(DateField);
                    GrandPrixes.Update(SelectedGp);
                },
                () => SelectedGp != null
                    && NameField != null
                    && TrackField != null
                );

            RemoveCommand = new RelayCommand(
                () => GrandPrixes.Delete(SelectedGp.Id),
                () => SelectedGp != null);
        }
    }
}
