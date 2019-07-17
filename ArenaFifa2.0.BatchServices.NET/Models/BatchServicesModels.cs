using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArenaFifa20.BatchServices.NET.Models
{
    public class GenerateRenewalViewModel
    {
        public int seasonH2HID { get; set; }
        public string seasonH2HName { get; set; }
        public int seasonFUTID { get; set; }
        public string seasonFUTName { get; set; }
        public int seasonPROID { get; set; }
        public string seasonPROName { get; set; }
        public int totalUsersBcoOnLine { get; set; }
        public int totalUsersBcoStaging { get; set; }
        public int lastSeasonH2HID { get; set; }
        public string lastSeasonH2HName { get; set; }
        public int lastSeasonFUTID { get; set; }
        public string lastSeasonFUTName { get; set; }
        public int lastSeasonPROID { get; set; }
        public string lastSeasonPROName { get; set; }
        public int inRenewalWithWorldCup { get; set; }
        public int inRenewalWithEuro { get; set; }
        public Boolean databaseStagingPrepared { get; set; }
        public Boolean renewalNewSeasonGenerated { get; set; }
        public Boolean emailsSent { get; set; }
        public string dataBaseName { get; set; }
        public int totalUserRenewalForNextSeason { get; set; }
        public int totalEmailSpoolerForRenewal { get; set; }
        public int userActionID { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class GenerateNewSeasonViewModel
    {
        public GenerateNewSeasonDetailsModel newSeasonModel { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class GenerateNewSeasonDetailsModel
    {
        public int seasonID { get; set; }
        public string seasonName { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public DateTime drawDate { get; set; }
        public string modeType { get; set; }
        public string championshipType { get; set; }

        public List<StandardGenerateNewSeasonChampionshipLeagueDetailsModel> listChampionshipLeagueDetails { get; set; }
        public List<StandardGenerateNewSeasonChampionshipCupDetailsModel> listChampionshipCupDetails { get; set; }
        public List<GenerateNewSeasonStandardDetailsModel> listOfTeams { get; set; }
        public List<GenerateNewSeasonStandardDetailsModel> listOfPots { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class StandardGenerateNewSeasonChampionshipLeagueDetailsModel
    {
        public string modeType { get; set; }
        public string championshipType { get; set; }
        public DateTime startDate { get; set; }
        public int totalTeams { get; set; }
        public int totalDaysToPlayStage0 { get; set; }
        public int totalDaysToPlayPlayoff { get; set; }
        public int totalRelegate { get; set; }
        public Boolean hasChampionship { get; set; }
        public int championshipID { get; set; }
        public Boolean championship_ByGroup { get; set; }
        public int totalGroups { get; set; }
        public Boolean championship_byGroupPots { get; set; }
        public Boolean championship_DoubleRound { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class StandardGenerateNewSeasonChampionshipCupDetailsModel
    {
        public string modeType { get; set; }
        public string championshipType { get; set; }
        public DateTime startDate { get; set; }
        public int totalTeams { get; set; }
        public int totalDaysToPlayStage0 { get; set; }
        public int totalDaysToPlayPlayoff { get; set; }
        public Boolean hasChampionship { get; set; }
        public int championshipID { get; set; }
        public Boolean championship_ByGroup { get; set; }
        public int totalGroups { get; set; }
        public Boolean hasJust_SerieA { get; set; }
        public Boolean hasJust_SerieB { get; set; }
        public Boolean hasJust_SerieC { get; set; }
        public Boolean has_SerieA_B { get; set; }
        public Boolean has_SerieA_B_C { get; set; }
        public Boolean has_SerieA_B_C_D { get; set; }
        public Boolean has_NationalTeams { get; set; }
        public int totalTeamsPreCup { get; set; }
        public Boolean championship_byGroupPots { get; set; }
        public Boolean hasChampionshipDestiny { get; set; }
        public Boolean hasChampionshipSource { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class GenerateNewSeasonStandardDetailsModel
    {
        public string modeType { get; set; }
        public string championshipType { get; set; }
        public int typeItem { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string psnID { get; set; }
        public int poteNumber { get; set; }
    }
}