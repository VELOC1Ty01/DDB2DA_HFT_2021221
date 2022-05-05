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
    class TeamEditorViewModel : ObservableRecipient
    {
        public RestCollection<Team> Teams { get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                SetProperty(ref selectedTeam, value);
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                NameField = value?.Name;
                PointsField = value != null ? value.Points : 0;
                TeamIdField = value != null ? value.Id : 0;
                TeamGPsField = value?.TeamGPs;

                //ShortNameField = value != null? value.ShortName : String.Empty;


            }
        }

        private int teamIdField;
        public int TeamIdField { 
            get { return teamIdField; } 
            set { 
                SetProperty(ref teamIdField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            } }

        private double pointsField;
        public double PointsField
        {
            get { return pointsField; }
            set
            {
                SetProperty(ref pointsField, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private ICollection<TeamGP> teamGPsField;
        public ICollection<TeamGP> TeamGPsField
        {
            get { return teamGPsField; }
            set
            {
                SetProperty(ref teamGPsField, value);
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

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public TeamEditorViewModel()
        {
            Teams = new RestCollection<Team>("http://localhost:21304/", "Team");

            AddCommand = new RelayCommand(
                () => Teams.Add(new Team
                {
                    Name = NameField,
                    Points = pointsField,
                }),

                () => NameField != null && NameField.Trim().Length != 0
                );
                        
                        

            UpdateCommand = new RelayCommand(
                () =>
                {
                    SelectedTeam.Id = TeamIdField;
                    SelectedTeam.Name = NameField;
                    SelectedTeam.Points = PointsField;
                    SelectedTeam.TeamGPs = SelectedTeam.TeamGPs;
                    SelectedTeam.Drivers = SelectedTeam.Drivers;
                    Teams.Update(SelectedTeam);
                },
                () => SelectedTeam != null
                );

            RemoveCommand = new RelayCommand(
                () => Teams.Delete(SelectedTeam.Id),
                () => SelectedTeam != null);
        }
    }
}
