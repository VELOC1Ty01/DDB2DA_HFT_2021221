using DDB2DA_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDB2DA_HFT_2021221.WpfClient
{
   
    class QueryViewModel : ObservableRecipient
    {

        public QueryCollection<Team> GetAllOutTeamsQuery { get; set; }
        public QueryCollection<Team> GetTeamsWhoSkippedGPQuery { get; set; }
        public QueryCollection<Team> GetPointsFromDriversQuery { get; set; }
        public QueryCollection<Driver> GetDriversFromTeamQuery { get; set; }
        public QueryCollection<GrandPrix> GetGrandPrixesQuery { get; set; }

        //public RestCollection<Team> GetAllOutTeamsCollection { get; set; }
        //public RestCollection<Team> GetTeamsWhoSkippedGPCollection { get; set; }
        //public RestCollection<Team> GetPointsFromDriversCollection { get; set; }
        //public RestCollection<Driver> GetDriversFromTeamCollection { get; set; }
        //public RestCollection<GrandPrix> GetGrandPrixesCollection { get; set; }


        public ICommand GetAllOutTeamsCommand { get; set; }
        public ICommand GetTeamsWhoSkippedGPCommand { get; set; }
        public ICommand GetPointsFromDriversCommand { get; set; }
        public ICommand GetDriversFromTeamCommand { get; set; }
        public ICommand GetGrandPrixesCommand { get; set; }

        private List<string> queryInfo;
        public List<string> QueryInfo {
            get { return queryInfo; }
            set {
                SetProperty(ref queryInfo, value);
                (GetAllOutTeamsCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetTeamsWhoSkippedGPCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetPointsFromDriversCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetDriversFromTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetGrandPrixesCommand as RelayCommand).NotifyCanExecuteChanged();
            } }

        public QueryViewModel()
        {

            GetAllOutTeamsQuery = new QueryCollection<Team>("Getalloutteams");
            GetTeamsWhoSkippedGPQuery = new QueryCollection<Team>("Getteamswhoskippedgp");
            GetPointsFromDriversQuery = new QueryCollection<Team>("Getpointsfromdrivers");
            GetDriversFromTeamQuery = new QueryCollection<Driver>("Getdriversfromteam");
            GetGrandPrixesQuery = new QueryCollection<GrandPrix>("Getdriverraces");
            //GetAllOutTeamsCollection = new RestCollection<Team>("http://localhost:21304/", "Query/Getalloutteams");
            //GetTeamsWhoSkippedGPCollection = new RestCollection<Team>("http://localhost:21304/", "Query/Getteamswhoskippedgp");
            //GetPointsFromDriversCollection = new RestCollection<Team>("http://localhost:21304/", "Query/Getpointsfromdrivers");
            //GetDriversFromTeamCollection = new RestCollection<Driver>("http://localhost:21304/", "Query/Getdriversfromteam");
            //GetGrandPrixesCollection = new RestCollection<GrandPrix>("http://localhost:21304/", "Query/Getdriverraces");
            

            GetAllOutTeamsCommand = new RelayCommand(
                () =>
                {
                    QueryInfo = new List<string>();

                    foreach (var item in GetAllOutTeamsQuery.result)
                    {
                        QueryInfo.Add(item.ToString());
                    }
                });
            GetTeamsWhoSkippedGPCommand = new RelayCommand(() =>
            {
                QueryInfo = new List<string>();

                foreach (var item in GetTeamsWhoSkippedGPQuery.result)
                {
                    QueryInfo.Add(item.ToString());
                }
            });

            GetPointsFromDriversCommand = new RelayCommand(() =>
            {
                QueryInfo = new List<string>();

                foreach (var item in GetPointsFromDriversQuery.result)
                {
                    QueryInfo.Add(item.ToString());
                }
            });

            GetDriversFromTeamCommand = new RelayCommand(() =>
            {
                QueryInfo = new List<string>();

                foreach (var item in GetDriversFromTeamQuery.result)
                {
                    QueryInfo.Add(item.ToString());
                }
            });

            GetGrandPrixesCommand = new RelayCommand(() =>
            {
                QueryInfo = new List<string>();

                foreach (var item in GetGrandPrixesQuery.result)
                {
                    QueryInfo.Add(item.ToString());
                }
            });
        }
    }
}
