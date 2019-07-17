using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ArenaFifa20.BatchServices.NET.Models
{
    public class RenewalViewModel
    {
        public List<RenewalChampionshipModel> listOfRenewal { get; set; }
        public int previousSeasonID { get; set; }
        public int seasonID { get; set; }
        public string seasonName { get; set; }
        public string previousSeasonName { get; set; }
        public string renewalMode { get; set; }
        public string championshipIDRenewal { get; set; }
        public string championshipIDBenchRenewal { get; set; }
        public string championshipIDRenewalWorldCupUefaEuro { get; set; }
        public int totalApprovedRenewal { get; set; }
        public int totalUnderAnalysisRenewal { get; set; }
        public int totalLimitBlackList { get; set; }
        public int totalLimitBanWorldCupUefaEuro { get; set; }
        public string dataBaseName { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class RenewalChampionshipModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string teamName { get; set; }
        public string status { get; set; }
        public string statusInitials { get; set; }
        public int seasonCurrentTotal { get; set; }
        public int total { get; set; }
        public int grandTotal { get; set; }
        public int playersTotal { get; set; }
        public int blackListtotal { get; set; }
        public string acceptedRenewal { get; set; }
        public string actionRenewal { get; set; }
    }

    public class RenewalPROCLUBSquadViewModel
    {
        public List<squadListModel> listOfSquad { get; set; }
        public int managerID { get; set; }
        public string mangerName { get; set; }
        public string psnID { get; set; }
        public int seasonID { get; set; }
        public string clubName { get; set; }
        public string pathImageClub { get; set; }
        public string mobileNumber { get; set; }
        public string codeMobileNumber { get; set; }
        public string dataBaseName { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class squadListModel
    {
        public int playerID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string recordDate { get; set; }
        public Boolean isCapitain { get; set; }
    }

    public class AcceptingNewSeasonViewModel
    {
        public string primaryKey { get; set; }
        public int seasonID { get; set; }
        public int userID { get; set; }
        public int championshipID { get; set; }
        public string confirmation { get; set; }
        public string teamName { get; set; }
        public string ordering { get; set; }
        public string dataBaseName { get; set; }

        public List<AcceptingDetails> listOfAccepting { get; set; }

        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class AcceptingDetails
    {
        public string primaryKey { get; set; }
        public int seasonID { get; set; }
        public int userID { get; set; }
        public int championshipID { get; set; }
        public string seasonName { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string championshipName { get; set; }
        public string confirmation { get; set; }
        public string confirmationDescription { get; set; }
        public DateTime Dateconfirmation { get; set; }
        public string DateconfirmationFormatted { get; set; }
        public string teamName { get; set; }
        public string console { get; set; }
        public string statusID { get; set; }
        public string statusDescription { get; set; }
        public int teamPROID { get; set; }
        public string ordering { get; set; }
        public string ddd { get; set; }
        public string mobileNumber { get; set; }
        public Boolean uploadTeamLogo { get; set; }
        public int totalPoints { get; set; }
        public int totalBlackList { get; set; }
        public List<UserDetailsModel> listOfUser { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public string dataBaseName { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class UserDetailsModel
    {
        public int id { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime birthday { get; set; }
        public string birthdayFormatted { get; set; }
        public string state { get; set; }
        public string howfindus { get; set; }
        public string whatkindofmedia { get; set; }
        public string team { get; set; }
        public string yourmode { get; set; }
        public byte receiveWarningEachRound { get; set; }
        public byte receiveTeamTable { get; set; }
        public byte wishParticipate { get; set; }

        public IEnumerable<SelectListItem> listWhatHowFindUs { get; set; }
        public IEnumerable<SelectListItem> listStates { get; set; }
        public IEnumerable<SelectListItem> listTeams { get; set; }

        public bool userActive { get; set; }
        public bool userModerator { get; set; }
        public string dateRegister { get; set; }
        public string dateLastUpdate { get; set; }
        public int idOperator { get; set; }
        public string psnIDOperator { get; set; }
        public string pageName { get; set; }
        public string avatarPath { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

   public class ChampionshipDetailsModel
    {
        public int id { get; set; }
        public int seasonID { get; set; }
        public string name { get; set; }
        public int totalTeam { get; set; }
        public DateTime startDate { get; set; }
        public String startDateFormatted { get; set; }
        public DateTime drawDate { get; set; }
        public String drawDateFormatted { get; set; }
        public Boolean active { get; set; }
        public Boolean forGroup { get; set; }
        public Boolean twoTurns { get; set; }
        public Boolean justOneTurn { get; set; }
        public int totalGroup { get; set; }
        public Boolean playoff { get; set; }
        public Boolean twoLegs { get; set; }
        public int totalQualify { get; set; }
        public int totalRelegation { get; set; }
        public int totalDayStageOne { get; set; }
        public int totalDayStagePlayoff { get; set; }
        public string type { get; set; }
        public string typeName { get; set; }
        public string modeType { get; set; }
        public int totalQualifyNextStage { get; set; }
        public int sourcePlaceFromChampionshipSource { get; set; }
        public int ChampionshipIDDestiny { get; set; }
        public int ChampionshipIDSource { get; set; }
        public string console { get; set; }
        public DateTime lastUpdate { get; set; }
        public string psnIDUpdate { get; set; }
        public int totalTeamQualifyDivAbove { get; set; }
        public string stagePlayoffFormatted { get; set; }
        public int doubleRound { get; set; }
        public int userID1 { get; set; }
        public int userID2 { get; set; }
        public string userName1 { get; set; }
        public string userName2 { get; set; }
        public string psnID1 { get; set; }
        public string psnID2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string pathAvatar1 { get; set; }
        public string pathAvatar2 { get; set; }
        public string teamName1 { get; set; }
        public string teamName2 { get; set; }
        public int started { get; set; }
        public int firstStageID { get; set; }
        public string seasonName { get; set; }
        public string listTeamsAdd { get; set; }
        public string listUsersAdd { get; set; }
        public string listStagesAdd { get; set; }
        public string listUsersStage2Add { get; set; }
        public string listTeamsStage0Add { get; set; }
        public List<ChampionshipTeamDetailsModel> listOfTeam { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUser { get; set; }
        public List<StandardDetailsModel> listOfStage { get; set; }
        public List<StandardDetailsModel_v2> listOfType { get; set; }
        public List<StandardDetailsModel> listOfTeamType { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserStage2 { get; set; }
        public List<StandardDetailsModel> listOfTeamStage0 { get; set; }
        public List<ChampionshipUserDetailsModel> listOfModerator { get; set; }
        public List<ChampionshipDetailsModel> listOfChampionship { get; set; }
        public List<StandardDetailsModel> listOfAllStages { get; set; }
        public List<ChampionshipUserDetailsModel> listOfAllUsers { get; set; }
        public List<StandardDetailsModel> listOfAllTeams { get; set; }

        //manage championship
        public List<ChampionshipUserDetailsModel> listOfUserGetIn { get; set; }
        public List<ChampionshipUserDetailsModel> listOfUserGetOut { get; set; }
        public string labelUserGetIn { get; set; }
        public string labelUserGetOut { get; set; }
        public string labelActionButton { get; set; }
        public string titleView { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }

        //draw
        public int drawDoneMatchTable { get; set; }
        public int totalMatchesPerRound { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public List<StandardDetailsModel> listOfGroup { get; set; }
        public int drawDoneTeamTableGroup { get; set; }
        public List<ChampionshipTeamTableDetailsModel> listOfTeamTable { get; set; }

        public int drawDoneUserTeam { get; set; }
        public List<UserTeamDetailsModel> listOfUserTeam { get; set; }

        public List<ChampionshipMatchTableClashesByTeamModel> listOfClashes { get; set; }

        public string stageID_Round { get; set; }
        public string psnOperation { get; set; }
        public int idUserOperation { get; set; }
        public int groupIDSelected { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamListViewModel
    {
        public List<ChampionshipTeamDetailsModel> listOfTeam { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
    }

    public class ChampionshipUserListViewModel
    {
        public List<ChampionshipUserDetailsModel> listOfUser { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipUserDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string psnID { get; set; }
        public string email { get; set; }
        public string actionUser { get; set; }
    }

    public class StandardDetailsModel_v2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
    }

    public class StandardDetailsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string pathImg { get; set; }
        public int typeItem { get; set; }
        public string psnID { get; set; }
        public int poteNumber { get; set; }
    }

    public class ChampionshipMatchTableViewModel
    {
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipMatchTableDetailsModel
    {
        public int matchID { get; set; }
        public int championshipID { get; set; }
        public string championshipName { get; set; }
        public string seasonName { get; set; }
        public int stageID { get; set; }
        public string stageName { get; set; }
        public int groupID { get; set; }
        public string groupName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int teamHomeID { get; set; }
        public int teamAwayID { get; set; }
        public string totalGoalsHome { get; set; }
        public string totalGoalsAway { get; set; }
        public DateTime launchDate { get; set; }
        public int round { get; set; }
        public string roundDetails { get; set; }
        public int userHomeID { get; set; }
        public string userHomeName { get; set; }
        public string psnIDHome { get; set; }
        public int userAwayID { get; set; }
        public string userAwayName { get; set; }
        public string psnIDAway { get; set; }
        public int playoffGame { get; set; }
        public string teamNameHome { get; set; }
        public string teamURLHome { get; set; }
        public int teamWithImageHome { get; set; }
        public string teamTypeHome { get; set; }
        public string teamNameAway { get; set; }
        public string teamURLAway { get; set; }
        public int teamWithImageAway { get; set; }
        public string teamTypeAway { get; set; }
        public string pathLogoChampionship { get; set; }
        public string pathLogoType { get; set; }
        public string pathLogoTeamHome { get; set; }
        public string pathLogoTeamAway { get; set; }
        public string modeType { get; set; }
        public int userIDAction { get; set; }
        public string psnIDAction { get; set; }
        public string psnIDSearch { get; set; }
        public string messageBlackList { get; set; }
        public string typeBlackList { get; set; }
        public int userID1 { get; set; }
        public int userID2 { get; set; }
        public int blackListIDUser1 { get; set; }
        public string messageBlackListUser1 { get; set; }
        public int blackListIDUser2 { get; set; }
        public string messageBlackListUser2 { get; set; }
        public string userName1 { get; set; }
        public string userName2 { get; set; }
        public string psnID1 { get; set; }
        public string psnID2 { get; set; }
        public int totalRecordsOfHistoric { get; set; }
        public Boolean launchResultReleased { get; set; }
        public List<ChampionshipMatchTableDetailsModel> listOfMatch { get; set; }
        public string sourceForm { get; set; }
        public string actionForm { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipTeamTableDetailsModel
    {
        public int championshipID { get; set; }
        public int teamID { get; set; }
        public int groupID { get; set; }
        public int totalPoint { get; set; }
        public int totalPlayed { get; set; }
        public int totalWon { get; set; }
        public int totalDraw { get; set; }
        public int totalLost { get; set; }
        public int totalGoalsFOR { get; set; }
        public int totalGoalsAGainst { get; set; }
        public int orden { get; set; }
        public string teamName { get; set; }
        public string teamURL { get; set; }
        public string teamType { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public int deletedCurrentSeason { get; set; }
        public int previousPosition { get; set; }
        public string pathTeamLogo { get; set; }
        public string actionUser { get; set; }
    }

    public class UserTeamDetailsModel
    {
        public int championshipID { get; set; }
        public int userID { get; set; }
        public int teamID { get; set; }
        public string userName { get; set; }
        public string psnID { get; set; }
        public string teamName { get; set; }
        public string teamType { get; set; }
    }

    public class ChampionshipMatchTableClashesListViewModel
    {
        public List<ChampionshipMatchTableClashesByTeamModel> listOfClashes { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

    public class ChampionshipMatchTableClashesByTeamModel
    {
        public int userID { get; set; }
        public int championshipID { get; set; }
        public int teamID { get; set; }
        public string teamName { get; set; }
        public int nextMatchTeamID { get; set; }
        public string nextMatchTeamName { get; set; }
        public int nextMatchID { get; set; }
        public string pathTeam { get; set; }
        public string pathNextMatchTeam { get; set; }
        public string pathPreviousMatch1_2 { get; set; }
        public string pathPreviousMatch1_4 { get; set; }
        public string pathPreviousMatch2_2 { get; set; }
        public string pathPreviousMatch2_4 { get; set; }
        public string pathPreviousMatch3_2 { get; set; }
        public string pathPreviousMatch3_4 { get; set; }
        public string descriptionNextMatch { get; set; }
        public string descriptionPreviousMatch1_1 { get; set; }
        public string descriptionPreviousMatch1_2 { get; set; }
        public string descriptionPreviousMatch1_3 { get; set; }
        public string descriptionPreviousMatch1_4 { get; set; }
        public string statusPreviousMatch1 { get; set; }
        public int prevMatchID1 { get; set; }
        public string descriptionPreviousMatch2_1 { get; set; }
        public string descriptionPreviousMatch2_2 { get; set; }
        public string descriptionPreviousMatch2_3 { get; set; }
        public string descriptionPreviousMatch2_4 { get; set; }
        public string statusPreviousMatch2 { get; set; }
        public int prevMatchID2 { get; set; }
        public string descriptionPreviousMatch3_1 { get; set; }
        public string descriptionPreviousMatch3_2 { get; set; }
        public string descriptionPreviousMatch3_3 { get; set; }
        public string descriptionPreviousMatch3_4 { get; set; }
        public string statusPreviousMatch3 { get; set; }
        public int prevMatchID3 { get; set; }
        public string actionUser { get; set; }
        public string returnMessage { get; set; }
    }

}