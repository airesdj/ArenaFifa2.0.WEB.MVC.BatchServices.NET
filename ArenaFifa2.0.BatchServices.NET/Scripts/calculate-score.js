var objCalculate;

var calculateScore = function(options){

var vars = {

iGoalsHome: 0,
iGoalsAway: 0,
sObjectGoalsHome: "",
sObjectGoalsAway: "",
sObjectListScorersHome: "",
sObjectListScorersAway: "",
sNameIDPlayerListHome: "#playerListHome",
sNameIDPlayerListAway: "#playerListAway",
sPlayerNameScorer: "",
iPlayerIDScorer: -1,
iPlayerHome: 1,
sHtmlFromHome: "",
sHtmlFromAway: "",
bLaunchedScore: false,
scorersIDHome: [],
totalGoalsHome: [],
scorersIDAway: [],
totalGoalsAway: []

}

var root = this;

this.construct = function(options){

$.extend(vars , options);

}

this.getScoreHome = function(){
    if (!vars.bLaunchedScore)
        return null;
    else
        return vars.iGoalsHome;
}

this.getScoreAway = function(){
    if (!vars.bLaunchedScore)
        return null;
    else
        return vars.iGoalsAway;
}

this.getAllDetailsScoreHome = function(){
    var returnDetails = "";
    for (var i = 0; i < vars.scorersIDHome.length; i++) {
        returnDetails += vars.scorersIDHome[i] + "|" + vars.totalGoalsHome[i] + ";";
    }
    return returnDetails.substring(0, returnDetails.length-1);
}

this.getAllDetailsScoreAway = function(){
    var returnDetails = "";
    for (var i = 0; i < vars.scorersIDAway.length; i++) {
        returnDetails += vars.scorersIDAway[i] + "|" + vars.totalGoalsAway[i] + ";";
    }
    return returnDetails.substring(0, returnDetails.length-1);
}

this.setScoreHome = function(namePlayer, idPlayer){

    vars.sPlayerNameScorer = namePlayer;
    vars.iPlayerIDScorer = idPlayer;
	vars.iPlayerHome = 1;

}

this.setScoreAway = function(namePlayer, idPlayer){

	vars.sPlayerNameScorer = namePlayer;
    vars.iPlayerIDScorer = idPlayer;
	vars.iPlayerHome = 0;

}


this.cleanScores = function(){

	$(vars.sObjectGoalsHome).text("?");
	$(vars.sObjectGoalsAway).text("?");

}

this.initializeScore = function(){

	vars.iGoalsHome = 0;
	vars.iGoalsAway = 0;
	vars.sPlayerNameScorer = "";
    vars.iPlayerIDScorer = -1;
	vars.iPlayerHome = 1;
	
	this.cleanScores();
	
}

this.updateScore = function(){

	$(vars.sObjectGoalsHome).text(vars.iGoalsHome);
	$(vars.sObjectGoalsAway).text(vars.iGoalsAway);

}

this.increaseScore = function(){
	
	if (vars.iPlayerHome == 1) {
		
		vars.iGoalsHome = vars.iGoalsHome + 1;
		
	}
	else {
		
		vars.iGoalsAway = vars.iGoalsAway + 1;
		
    }
	this.validateScorerInformed();
	this.updateScore();
    vars.bLaunchedScore = true; 
}

this.validateScorerInformed = function(){
	
	var iTotalSoccerBalls = 0;
	var $objectScorers;
	var sHtmlSoccerBalls = "";
	var setInfoPlayer = false;
	var indentifyOwnGoal = "";
	
	if (vars.sPlayerNameScorer.indexOf("Gol Contra")>0) {indentifyOwnGoal = "own-goal";}
	
	if (vars.iPlayerHome==1) {
        $objectScorers = $(vars.sObjectListScorersHome).children("p.time-jogador");
	}
	else {
		$objectScorers = $(vars.sObjectListScorersAway).children("p.time-jogador");
    }

    this.setArrayOneScore();

	if ($objectScorers.length==0) {
		if (vars.iPlayerHome == 1) {
			
			vars.sHtmlFromHome = vars.sHtmlFromHome + 
								 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
			$(vars.sObjectListScorersHome).html(vars.sHtmlFromHome);
			
		}
		else {
			
			vars.sHtmlFromAway = vars.sHtmlFromAway + 
								 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
			
			$(vars.sObjectListScorersAway).html(vars.sHtmlFromAway);
			
		}
	}
	else {
		for (var i = 0;i<$objectScorers.length;i++) {
			if ($objectScorers.eq(i).attr("target")==vars.sPlayerNameScorer) {
                iTotalSoccerBalls = $objectScorers.eq(i).children("#soccer-ball").children("i.gentelella-fa-soccer-ball-o").length;
				if (iTotalSoccerBalls>0) {
					setInfoPlayer = true;
					iTotalSoccerBalls += 1;
					for (var j = 0;j<iTotalSoccerBalls;j++) {
                        sHtmlSoccerBalls = sHtmlSoccerBalls + "<i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;";
					}
                    $objectScorers.eq(i).children("#soccer-ball").html(sHtmlSoccerBalls);
				}
			}
		}

        if (setInfoPlayer == false) {
			if (vars.iPlayerHome == 1) {
				
                vars.sHtmlFromHome = $(vars.sObjectListScorersHome).html() + 
									 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
				
				$(vars.sObjectListScorersHome).html(vars.sHtmlFromHome);
				
			}
			else {
				
                vars.sHtmlFromAway = $(vars.sObjectListScorersAway).html() + 
									 "<p class='time-jogador ' target='"+vars.sPlayerNameScorer+"'>"+vars.sPlayerNameScorer+"&nbsp; <span id='soccer-ball'><i class='gentelella-fa gentelella-fa-soccer-ball-o "+indentifyOwnGoal+"'></i>&nbsp;</span><span></p>";
				
				$(vars.sObjectListScorersAway).html(vars.sHtmlFromAway);
				
			}
		}
	}
}

this.decreaseScore = function(){

	
	if (vars.iPlayerHome == 1) {
		
		vars.iGoalsHome = vars.iGoalsHome - 1;
        if (vars.iGoalsHome < 0) { vars.iGoalsHome = 0; vars.bLaunchedScore = false; }
		
		$(vars.sObjectListScorersHome).find("[target='"+vars.sPlayerNameScorer+"'").remove();
	}
	else {

		vars.iGoalsAway = vars.iGoalsAway - 1;
        if (vars.iGoalsAway < 0) { vars.iGoalsAway = 0; vars.bLaunchedScore = false; }
		
		$(vars.sObjectListScorersAway).find("[target='"+vars.sPlayerNameScorer+"'").remove();
	
	}
	
	this.updateScore();

}

this.putScore0x0 = function(){

	this.cleanAllScorers();

	vars.iGoalsHome = 0;
	vars.iGoalsAway = 0;
	
    this.updateScore();

    vars.bLaunchedScore = true;

}

this.cleanAllScorers = function(){

	this.initializeScore();

	$(vars.sObjectListScorersHome).html("");
    $(vars.sObjectListScorersAway).html("");

    vars.bLaunchedScore = false;
	
	vars.sHtmlFromHome = "";
    vars.sHtmlFromAway = "";

    vars.sPlayerNameScorer = "";
    vars.iPlayerIDScorer = -1;
    vars.iPlayerHome = 1;

    vars.scorersIDHome = [];
    vars.totalGoalsHome = [];
    vars.scorersIDAway = [];
    vars.totalGoalsAway = [];

}


this.setArrayOneScore = function(){
    var iFound = -1;
    if (vars.iPlayerHome == 1) {
        iFound = jQuery.inArray(vars.iPlayerIDScorer, vars.scorersIDHome);
        if (iFound == -1) {
            vars.scorersIDHome.push(null);
            vars.totalGoalsHome.push(null);
            vars.scorersIDHome[vars.scorersIDHome.length - 1] = vars.iPlayerIDScorer;
            vars.totalGoalsHome[vars.totalGoalsHome.length - 1] = 1;
        }
        else {
            vars.totalGoalsHome[iFound] = parseInt(vars.totalGoalsHome[iFound]) + 1;
        }
    }
    else {
        iFound = jQuery.inArray(vars.iPlayerIDScorer, vars.scorersIDAway);
        if (iFound == -1) {
            vars.scorersIDAway.push(null);
            vars.totalGoalsAway.push(null);
            vars.scorersIDAway[vars.scorersIDAway.length - 1] = vars.iPlayerIDScorer;
            vars.totalGoalsAway[vars.totalGoalsAway.length - 1] = 1;
        }
        else {
            vars.totalGoalsAway[iFound] = parseInt(vars.totalGoalsAway[iFound]) + 1;
        }
    }

}

this.beforeSubmit = function(){

}

 
this.construct(options);

}