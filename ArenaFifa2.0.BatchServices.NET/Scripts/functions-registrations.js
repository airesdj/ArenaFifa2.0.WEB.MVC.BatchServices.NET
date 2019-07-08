function includeFileScreenModalCoaches(actionName, actionForm) {
	$("#modalScreeenDeleteTitle").html( "CADASTRO DE TÉCNICOS" );
	$("#modalScreeenDeleteSubTitle").html( "Inativação" );
    $("#modalScreeenDeleteButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });
}

function includeFileScreenResultAction(pTitle) {
	$("#includedContentResultMessage").load("menu-moderator-result-modal.html", function() {
		$("#modalScreeenResultTitle").html( pTitle );
		$("#modalScreeenResultSubTitle").html( "" );
		$("#modalScreeenResultMessage").html ( "" );
	});
}

function includeFileScreenModalDelete(pTitle, actionName, actionForm) {
	$("#modalScreeenDeleteTitle").html( "CADASTRO DE "+pTitle );
	$("#modalScreeenDeleteSubTitle").html( "Exclusão" );
    $("#modalScreeenDeleteButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });

    $("#modalScreeenResultTitle").html("CADASTRO DE " + pTitle);
	$("#modalScreeenResultSubTitle").html( "Exclusão" );
}

function changeQuestionDescriptionInativate(pID) {
    $('#selectedID').val(pID);
    $("#modalScreeenDeleteQuestion").html("Deseja realmente inativar o técnico selecionado (#ID: " + pID + ")?");
}

function changeQuestionDescriptionDelete(pID) {
    $('#selectedID').val(pID);
    $("#modalScreeenDeleteQuestion").html("Deseja realmente excluir o item selecionado (#ID: " + pID + ")?");
}

function includeFileScreenModalGeneral(pTitle, pSubTitle, pQuestionMsg, actionName, actionForm) {
	$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
    $("#modalScreeenMsgSubTitle").html(pSubTitle);
    $("#modalScreeenMsgQuestion").html(pQuestionMsg);
    $("#modalScreeenMsgButton").on("click", function () { submeteModerator(actionName, actionForm, ''); });
}
function changeQuestionDescriptionGeneral(pID) {
    var strQuestion = $("#modalScreeenMsgQuestion").html();
    $('#selectedID').val(pID);
    $("#modalScreeenMsgQuestion").html(strQuestion.replace("<selectid>", pID));
}

function includeFileScreenModalGeneralViewIntelegence(pHtmlFile, pTitle) {
	$("#includedContentViewSendEmail").load(pHtmlFile, function() {
		$("#modalScreeenMsgTitle").html( "CADASTRO DE "+pTitle );
		//$("#modalScreeenMsgButton").on("click", function(){ alert("Running process to send the invite email to the next season..."); });
		$("#includedContentChampionshipShortDetails").load("menu-moderator-championship-short-details.html"); 
	}); 
}
function activateRegistrationForm(pNewPageRedirect, actionForm) {
	window.Parsley.on('field:error', function() {
		var ok = $('.gentelella-parsley-error').length === 0;
		$('.bs-callout-warning').toggleClass('gentelella-hidden', ok);
    })
    if (pNewPageRedirect == "BenchDetails") {

        $("#rdoTipoH2H").change(function () {
            if (this.checked) {
                $("#txtTime").prop('required', false).val('');
            }
        })

        $("#rdoTipoFUT").change(function () {
            if (this.checked) {
                $("#txtTime").attr("required", "true");
            }
        })

        $("#rdoTipoPRO").change(function () {
            if (this.checked) {
                $("#txtTime").attr("required", "true");
            }
        })

        .on('form:success', function () {
            return true; // Don't submit form for this demo
        });
    }
    else if (pNewPageRedirect == "UserDetails") {

        $("#cmbHeardUs").on("change", function () {
            if ($(this).val() == "OUTROS") {
                $("#whatkindofmedia").removeClass("disabled").removeAttr("disabled").focus();
                $("#whatkindofmedia").attr("required", "true");
            }
            else {
                $("#whatkindofmedia").val("");
                $("#whatkindofmedia").addClass("disabled").attr("disabled", "true");
                $("#whatkindofmedia").prop('required', false).val('');
            }
        });

        if ($("#cmbHeardUs").val() == "OUTROS") {
            $("#whatkindofmedia").removeClass("disabled").removeAttr("disabled").focus();
            $("#whatkindofmedia").attr("required", "true");
        }
        else {
            $("#whatkindofmedia").val("");
            $("#whatkindofmedia").addClass("disabled").attr("disabled", "true");
            $("#whatkindofmedia").prop('required', false).val('');
        }

    }
    else if (pNewPageRedirect == "TeamDetails") {
        var COD_TYPE_FUT = "37";
        var COD_TYPE_PRO = "42";


        $("#cmbTipo").on("change", function () {
            if ($(this).val() != COD_TYPE_FUT && $(this).val() != COD_TYPE_PRO) {
                $("#txtUrl").removeClass("disabled").removeAttr("disabled").focus();
                $("#txtUrl").attr("required", "true");
                $("#txtIdSofifa").removeClass("disabled").removeAttr("disabled").focus();
                $("#txtIdSofifa").attr("required", "true");
                $("#cmbTecnico").val("");
                $("#cmbTecnico").addClass("disabled").attr("disabled", "true");
                $("#cmbTecnico").prop('required', false).val('');
                $("#starURL").show();
                $("#starSofifaID").show();
                $("#starCoach").hide();
            }
            else {
                $("#txtUrl").val("");
                $("#txtUrl").addClass("disabled").attr("disabled", "true");
                $("#txtUrl").prop('required', false).val('');
                $("#txtIdSofifa").val("");
                $("#txtIdSofifa").addClass("disabled").attr("disabled", "true");
                $("#txtIdSofifa").prop('required', false).val('');
                $("#cmbTecnico").removeClass("disabled").removeAttr("disabled").focus();
                $("#cmbTecnico").attr("required", "true");
                $("#starURL").hide();
                $("#starSofifaID").hide();
                $("#starCoach").show();
            }
        });

        if ($("#cmbTipo").val() != COD_TYPE_FUT && $("#cmbTipo").val() != COD_TYPE_PRO) {
            $("#txtUrl").removeClass("disabled").removeAttr("disabled").focus();
            $("#txtUrl").attr("required", "true");
            $("#txtIdSofifa").removeClass("disabled").removeAttr("disabled").focus();
            $("#txtIdSofifa").attr("required", "true");
            $("#cmbTecnico").val("");
            $("#cmbTecnico").addClass("disabled").attr("disabled", "true");
            $("#cmbTecnico").prop('required', false).val('');
            $("#starURL").show();
            $("#starSofifaID").show();
            $("#starCoach").hide();
        }
        else {
            $("#txtUrl").val("");
            $("#txtUrl").addClass("disabled").attr("disabled", "true");
            $("#txtUrl").prop('required', false).val('');
            $("#txtIdSofifa").val("");
            $("#txtIdSofifa").addClass("disabled").attr("disabled", "true");
            $("#txtIdSofifa").prop('required', false).val('');
            $("#cmbTecnico").removeClass("disabled").removeAttr("disabled").focus();
            $("#cmbTecnico").attr("required", "true");
            $("#starURL").hide();
            $("#starSofifaID").hide();
            $("#starCoach").show();
        }
    }

    if (actionForm == "VIEW") {
        $("input[type!='button']").attr('disabled', 'true');
        $("select").attr('disabled', 'true');
    }

    if (pNewPageRedirect != "BlogDetails") {
        window.Parsley.addValidator('datevalid', {
            validateString: function (value) {
                value = value.replace("_", "");
                if (value.length < 10) { return false; }
                else { return moment(value, "DD/MM/YYYY").isValid(); }
            },
            messages: {
                en: 'O campo é inválido.',
                fr: ""
            }
        });
    }
}
function submeteModerator(actionName, actionForm, itemSelected) {
    $("#actionForm").val(actionForm);
    if (itemSelected != "") { $("#selectedID").val(itemSelected); }
    if (actionForm == "VOLTAR") {
        $("#comeback-form").attr("action", "/Moderator/" + actionName);
        $("#comeback-form").submit();
    }
    else if (actionForm == "VOLTAR_DECREE") {
        $("#actionForm").val("SHOW_CHAMPIONSHIP_DETAILS");
        $("#cmbMessageDecree").find("option[value='Placar decretado de 0x0 devido a omissão total dos dois técnicos.']").attr("selected", "true");
        $("#registration-form").attr("action", "/Moderator/" + actionName);
        $("#registration-form").submit();
    }
    else if (actionForm == "VOLTAR_COMMENT") {
        $("#actionForm").val("SHOW_CHAMPIONSHIP_DETAILS");
        $("#txtComment").val(".");
        checkFormValid(0);
        $("#registration-form").attr("action", "/Moderator/" + actionName);
        $("#registration-form").submit();
    }
    else if (actionForm == "DELETE_BLACKLIST" || actionForm == "ADD_BLACKLIST") {
        $("#txtComment").val(".");
        checkFormValid(0);
        $("#registration-form").attr("action", "/Moderator/" + actionName);
        $("#registration-form").submit();
    }
    else if (actionForm == "SHOW_CHAMPIONSHIPMATCHTABLE_DETAILS" && actionName != "CommentMatch" && actionName != "DecreeResult") {
        $("#registration-form").attr("action", "/MyMatches/" + actionName);
        $("#registration-form").submit();
    }
    else if (actionForm == "SHOW_LAUNCH_SIMPLE_RESULT_DETAILS" && actionName != "LaunchSimpleResult") {
        $("#registration-form").attr("action", "/MyMatches/" + actionName);
        $("#registration-form").submit();
    }
    else if (actionForm == "VOLTAR_MY_MATCHES") {
        $("#actionForm").val("SHOW_CHAMPIONSHIP_DETAILS");
        $("#txtComment").val(".");
        $("#registration-form").attr("action", "/MyMatches/" + actionName);
        $("#registration-form").submit();
    }
    else if (String(actionForm).indexOf("_MY_MATCHES") > -1) {
        $("#txtComment").val(".");
        $("#registration-form").attr("action", "/MyMatches/" + actionName);
        $("#registration-form").submit();
    }
    else if (String(actionForm).indexOf("_CURRENT_SEASON") > -1) {
        $("#txtComment").val(".");
        $("#registration-form").attr("action", "/CurrentSeason/" + actionName);
        $("#registration-form").submit();
    }
    else {
        $("#registration-form").attr("action", "/Moderator/" + actionName);
        $("#registration-form").submit();
    }
}

function setOrderingDatatableResponsive(arrayOrder1, arrayOrder2, arrayOrder3) {
    var table = $('#datatable-responsive').DataTable();
    if (arrayOrder2 != null && arrayOrder3 != null)
        table.order([[arrayOrder1[0], arrayOrder1[1]], [arrayOrder2[0], arrayOrder2[1]], [arrayOrder3[0], arrayOrder3[1]]]);
    else if (arrayOrder3 == null)
        table.order([[arrayOrder1[0], arrayOrder1[1]], [arrayOrder2[0], arrayOrder2[1]]]);
    else
        table.order([[arrayOrder1[0], arrayOrder1[1]]]);
    //table.order([[3, 'desc'], [0, 'asc']]); --> example
    table.draw();
    table = null;
}

function setSubmitMenuSummaryCurrentSeason(modeType, championshipID, actionForm) {
    $("#currentModeTypeSeason").val(modeType);
    $("#actionType").val(modeType);
    $("#championshipID").val(championshipID);
    if ($("#txtComment").length > 0) { $("#txtComment").val("."); }
    $("#registration-form").attr("action", "/CurrentSeason/" + actionForm);
    $("#registration-form").submit();
}

function setSubmitMenuSwapChampionshipCurrentSeason(modeType, championshipID) {
    $("#currentModeTypeSeason").val(modeType);
    $("#actionType").val(modeType);
    $("#championshipID").val(championshipID);
    $("#actionForm").val("SWAP_OF_CHAMPIONSHIP");
    $("#registration-form").attr("action", "/CurrentSeason/ClashTable");
    $("#registration-form").submit();
}
