var objCalculateHistory;

var calculateHistoryMatches = function(options){

var vars = {

iAmountTotal: 300,
iTotalMatches: 0,
iTotalWinsHomeTeam: 0,
iTotalWinsAwayTeam: 0,
iTotalDraws: 0,
iTotalGoalsHomeTeam: 0,
iTotalGoalsAwayTeam: 0,
sImageForWins: "/images/Confrontos_Vermelho.JPG",
sImageForLosses: "/images/Confrontos_Preto.JPG",
sImageForDraws: "/images/Confrontos_Cinza.JPG",
iTotalGoalsHomeTeam: 0,
iTotalGoalsAwayTeam: 0,
sColorForWins: "red",
sColorForLosses: "#000",
sColorHomeTeam: "",
sColorAwayTeam: "",
sImageHomeTeam: "",
sImageAwayTeam: "",
sClassHomeTeam: "",
sClassAwayTeam: "",
sObjectWinsHistoryMatchesHomeTeam: "#winsHistoryMatchesHomeTeam",
sObjectWinsHistoryMatchesAwayTeam: "#winsHistoryMatchesAwayTeam",
sObjectDrawsHistoryMatches: "#drawsHistoryMatches",
sNameIDLabelWinHomeTeam: "#idLabelWinHomeTeam",
sNameIDLabelWinAwayTeam: "#idLabelWinAwayTeam",
sNameIDGoalsHomeTeamHistory: "#goalsHomeTeamHistory",
sNameIDGoalsAwayTeamHistory: "#goalsAwayTeamHistory",
sNameIDGoalsHomeTeam: "#goalsHomeTeam",
sNameIDGoalsAwayTeam: "#goalsAwayTeam",
sNameIDWinsHomeTeam: "#winsHomeTeam",
sNameIDWinsAwayTeam: "#winsAwayTeam",
sLabelTitleHometeam: "psnIDCasa",
sLabelTitleAwayteam: "psnIDVisitante",
sNameIDShowMatchesHomeTeam: "#gamesResultsCoachesHomeTeam",
sNameIDShowMatchesAwayTeam: "#gamesResultsCoachesAwayTeam",
sNameIDShowMatchesDraw: "#gamesResultsCoachesDraw"

}

var root = this;

this.construct = function(options){

$.extend(vars , options);

}

this.initializeHistory = function(){
	
	vars.iTotalMatches = vars.iTotalWinsHomeTeam + vars.iTotalWinsAwayTeam + vars.iTotalDraws;
	
	var sizeWinsHomeTeam = parseInt((vars.iAmountTotal * vars.iTotalWinsHomeTeam) / vars.iTotalMatches, 10) + "px";
	var sizeWinsAwayTeam = parseInt((vars.iAmountTotal * vars.iTotalWinsAwayTeam) / vars.iTotalMatches, 10) + "px";
	var sizeDraws = parseInt((vars.iAmountTotal * vars.iTotalDraws) / vars.iTotalMatches, 10) + "px";

	
	var totalGoals = vars.iTotalGoalsHomeTeam + vars.iTotalGoalsAwayTeam;
	var sizeGoalsHomeTeam = "";
	var sizeGoalsAwayTeam = "";
	
	if (totalGoals > 0) {
		var sizeGoalsAux = parseInt((vars.iAmountTotal * vars.iTotalGoalsHomeTeam) / totalGoals, 10);
		sizeGoalsHomeTeam = sizeGoalsAux + "px";
		sizeGoalsAwayTeam = parseInt(vars.iAmountTotal - sizeGoalsAux, 10) + "px";
	}
	
	if (vars.iTotalWinsHomeTeam > vars.iTotalWinsAwayTeam) {
		vars.sColorHomeTeam = vars.sColorForWins;
		vars.sImageHomeTeam = vars.sImageForWins;
		vars.sClassHomeTeam = "team-goals-winner";
		vars.sColorAwayTeam = vars.sColorForLosses;
		vars.sImageAwayTeam = vars.sImageForLosses;
		vars.sClassAwayTeam = "team-goals-looser";
	}
	else if (vars.iTotalWinsHomeTeam < vars.iTotalWinsAwayTeam) {
		vars.sColorHomeTeam = vars.sColorForLosses;
		vars.sImageHomeTeam = vars.sImageForLosses;
		vars.sClassHomeTeam = "team-goals-looser";
		vars.sColorAwayTeam = vars.sColorForWins;
		vars.sImageAwayTeam = vars.sImageForWins;
		vars.sClassAwayTeam = "team-goals-winner";
	}
	else if (vars.iTotalWinsHomeTeam == vars.iTotalWinsAwayTeam) {
		vars.sColorHomeTeam = vars.sColorForLosses;
		vars.sImageHomeTeam = vars.sImageForLosses;
		vars.sClassHomeTeam = "team-goals-looser";
		vars.sColorAwayTeam = vars.sColorForLosses;
		vars.sImageAwayTeam = vars.sImageForLosses;
		vars.sClassAwayTeam = "team-goals-looser";
	}
	
	$("[target='showMatches']").hide();
	
	this.showWins();
	this.showHistoryMatches(sizeWinsHomeTeam, sizeWinsAwayTeam, sizeDraws);
	this.showHistoryGoals(totalGoals, sizeGoalsHomeTeam, sizeGoalsAwayTeam);
	
}

this.showWins = function(){

	$(vars.sNameIDLabelWinHomeTeam).attr("style", "font-size:20px;color:"+vars.sColorHomeTeam);
	$(vars.sNameIDLabelWinAwayTeam).attr("style", "font-size:20px;color:"+vars.sColorAwayTeam);
	
	$(vars.sNameIDWinsHomeTeam).addClass(vars.sClassHomeTeam);
	$(vars.sNameIDWinsAwayTeam).addClass(vars.sClassAwayTeam);

	$(vars.sNameIDWinsHomeTeam).text(vars.iTotalWinsHomeTeam);
	$(vars.sNameIDWinsAwayTeam).text(vars.iTotalWinsAwayTeam);
}

this.showHistoryMatches = function(sizeHomeTeam, sizeAwayTeam, sizeDraw){
	
	var percHomeTeam = parseInt((100 * vars.iTotalWinsHomeTeam) / vars.iTotalMatches, 10);
	var percAwayTeam = parseInt((100 * vars.iTotalWinsAwayTeam) / vars.iTotalMatches, 10);
	var percDraw = parseInt((100 * vars.iTotalDraws) / vars.iTotalMatches, 10);
	
	var titleHome = vars.sLabelTitleHometeam + ": " + vars.iTotalWinsHomeTeam + " vitórias (" + percHomeTeam + "% dos jogos)."
	var titleAway = vars.sLabelTitleAwayteam + ": " + vars.iTotalWinsAwayTeam + " vitórias (" + percAwayTeam + "% dos jogos)."
	var titleDraw = + vars.iTotalDraws + " empates (" + percDraw + "% dos jogos)."
	
	if (vars.iTotalWinsHomeTeam>0) {titleHome += " Clique para visualizar os jogos.";}
	if (vars.iTotalWinsAwayTeam>0) {titleAway += " Clique para visualizar os jogos.";}
	if (vars.iTotalDraws>0) {titleDraw += " Clique para visualizar os jogos.";}

	$(vars.sObjectWinsHistoryMatchesHomeTeam).attr("src", vars.sImageHomeTeam).attr("width", sizeHomeTeam).attr("title", titleHome);
	$(vars.sObjectWinsHistoryMatchesAwayTeam).attr("src", vars.sImageAwayTeam).attr("width", sizeAwayTeam).attr("title", titleAway);
	$(vars.sObjectDrawsHistoryMatches).attr("src", vars.sImageForDraws).attr("width", sizeDraw).attr("title", titleDraw);
	
	$(vars.sObjectWinsHistoryMatchesHomeTeam).on("click", function(){
		$(vars.sNameIDShowMatchesAwayTeam).hide();
		$(vars.sNameIDShowMatchesDraw).hide();
		$(vars.sNameIDShowMatchesHomeTeam).show();
	});
	
	$(vars.sObjectWinsHistoryMatchesAwayTeam).on("click", function(){
		$(vars.sNameIDShowMatchesHomeTeam).hide();
		$(vars.sNameIDShowMatchesDraw).hide();
		$(vars.sNameIDShowMatchesAwayTeam).show();
	});
	
	$(vars.sObjectDrawsHistoryMatches).on("click", function(){
		$(vars.sNameIDShowMatchesHomeTeam).hide();
		$(vars.sNameIDShowMatchesAwayTeam).hide();
		$(vars.sNameIDShowMatchesDraw).show();
	});
	
}

this.showHistoryGoals = function(totalGoals, sizeHomeTeam, sizeAwayTeam){
	
	var titleHome = vars.sLabelTitleHometeam + ": " + vars.iTotalGoalsHomeTeam + " gols (" + parseFloat(vars.iTotalGoalsHomeTeam / vars.iTotalMatches).toFixed(2) + " por jogo)."
	var titleAway = vars.sLabelTitleAwayteam + ": " + vars.iTotalGoalsAwayTeam + " gols (" + parseFloat(vars.iTotalGoalsAwayTeam / vars.iTotalMatches).toFixed(2) + " por jogo)."

	$(vars.sNameIDGoalsHomeTeamHistory).attr("src", vars.sImageHomeTeam).attr("width", sizeHomeTeam).attr("title", titleHome);
	$(vars.sNameIDGoalsAwayTeamHistory).attr("src", vars.sImageAwayTeam).attr("width", sizeAwayTeam).attr("title", titleAway);
	
	$(vars.sNameIDGoalsHomeTeam).text(vars.iTotalGoalsHomeTeam);
	$(vars.sNameIDGoalsAwayTeam).text(vars.iTotalGoalsAwayTeam);
	
}


this.beforeSubmit = function(){

}

 
this.construct(options);

}