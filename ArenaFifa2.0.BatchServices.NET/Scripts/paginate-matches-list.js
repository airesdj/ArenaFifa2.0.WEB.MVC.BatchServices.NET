var objPaginate;

var paginateMatches = function(options){

var vars = {

iCurrentPage: 1,
iAmountTotalOfPages: 0,
sObjectItemList: "",
sObjectRoundDropDown: "",
sObjectMoveNextItem: "",
sObjectMovePreviousItem: "",
sObjectRoundDetails: "",
sTitleMoveNextItem: "Ir para a Próxima Rodada",
sTitleMovePreviousItem: "Ir para a Rodada Anterior",
sTitleMoveNextItemDisabled: "Função desabilitada. Está Rodada já é a última.",
sTitleMovePreviousItemDisabled: "Função desabilitada. Está Rodada já é a primeira.",
iGroupIDSelected: 0,
iTotalItemsList: 0

}

var root = this;

this.construct = function(options){

$.extend(vars , options);

}

this.initializePaginateMatches = function(){

	var objectRoundDropDown = $(vars.sObjectRoundDropDown);
	for (var i = 0; i<vars.iAmountTotalOfPages; i++) {
		objectRoundDropDown.append($("<option>").attr("value", (i+1)).text("Rodada "+(i+1)));
	}
	vars.iTotalItemsList = $(vars.sObjectItemList).length;
	$(vars.sObjectMoveNextItem).on("click", function(){ objPaginate.moveForward(); });
	$(vars.sObjectMovePreviousItem).on("click", function(){ objPaginate.moveBack(); });
	$(vars.sObjectRoundDropDown).on("change", function(){ objPaginate.moveNewCurrentItem(); });
	this.paginateMatchesList(vars.iCurrentPage, vars.iAmountTotalOfPages);

}

this.paginateMatchesList = function(){

	var itemPerPage = (vars.iTotalItemsList / vars.iAmountTotalOfPages);
	var lastItemOfCurrentPage = (vars.iCurrentPage * itemPerPage);
	var firstItemOfCurrentPage = ((lastItemOfCurrentPage - itemPerPage) + 1);
	$(vars.sObjectRoundDropDown).prop("selectedIndex", (vars.iCurrentPage-1));
	$(vars.sObjectItemList).filter(function( index ) {
		if (index>=(firstItemOfCurrentPage-1) && index<=(lastItemOfCurrentPage-1)) {$(this).show();} else {$(this).hide();}
    });
	this.validateControlsCurrentPage();
    if (vars.sObjectRoundDetails != "") {
        if (vars.iGroupIDSelected > 0) 
            $(vars.sObjectRoundDetails).html("Grupo " + vars.iGroupIDSelected + " - Periodo: " + $("#fase0-Round" + vars.iCurrentPage).val());
        else
            $(vars.sObjectRoundDetails).html("Periodo: " + $("#fase0-Round" + vars.iCurrentPage).val());
    }
}

this.validateControlsCurrentPage = function(){

	if (vars.iCurrentPage==1) {
		$(vars.sObjectMovePreviousItem).addClass("disabled").attr("title", vars.sTitleMovePreviousItemDisabled);
		$(vars.sObjectMoveNextItem).removeClass("disabled").attr("title", vars.sTitleMoveNextItem);
	}
	else if (vars.iCurrentPage==vars.iAmountTotalOfPages) {
		$(vars.sObjectMoveNextItem).addClass("disabled").attr("title", vars.sTitleMoveNextItemDisabled);
		$(vars.sObjectMovePreviousItem).removeClass("disabled").attr("title", vars.sTitleMovePreviousItem);
	}
	else {
		$(vars.sObjectMoveNextItem).removeClass("disabled").attr("title", vars.sTitleMoveNextItem);
		$(vars.sObjectMovePreviousItem).removeClass("disabled").attr("title", vars.sTitleMovePreviousItem);
	}

}

this.moveForward = function(){

	if (vars.iCurrentPage<vars.iAmountTotalOfPages) {
		vars.iCurrentPage = vars.iCurrentPage + 1;
		this.paginateMatchesList();
	}

}

this.moveBack = function(){

	if (vars.iCurrentPage>1) {
		vars.iCurrentPage = vars.iCurrentPage - 1;
		this.paginateMatchesList();
	}

}
 
this.moveNewCurrentItem = function(){

	var currentItemSelected = parseInt($(vars.sObjectRoundDropDown).find(":selected").val(), 10);
	
	vars.iCurrentPage = currentItemSelected;
	this.paginateMatchesList();

}
 
this.construct(options);

}