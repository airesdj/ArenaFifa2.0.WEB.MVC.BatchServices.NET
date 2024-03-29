﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ArenaFifa20.BatchServices.NET.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "PSN ID")]
        public string psnID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string password { get; set; }

        public string actionUser { get; set; }
    }

    public class returnJSON_UserLoginModel
    {
        public int id { get; set; }
        public string psnID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string password20 { get; set; }
        public bool userActive { get; set; }
        public bool userModerator { get; set; }
        public string email { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime lastAccess { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime birthday { get; set; }

        public string state { get; set; }
        public string howfindus { get; set; }
        public string whatkindofmedia { get; set; }
        public string team { get; set; }
        public byte receiveWarningEachRound { get; set; }
        public byte receiveTeamTable { get; set; }
        public byte wishParticipate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime register { get; set; }

        public string linkLiveMatch { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        public DateTime lastUpdate { get; set; }

        public string psnIDLastUpdate { get; set; }
        public string passwordManager { get; set; }
        public string passwordManager20 { get; set; }
        public string workEmail { get; set; }
        public string codeArea { get; set; }
        public string mobileNumber { get; set; }
        public string returnMessage { get; set; }
        public string currentTeam { get; set; }
        public int totalTitlesWon { get; set; }
        public int totalVices { get; set; }
        public string pathAvatar { get; set; }
    }
}