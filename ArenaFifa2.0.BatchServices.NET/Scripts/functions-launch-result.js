var tableStage_1 = null;
var tableStage_2 = null;
var tableStage0 = null;
var tableStage1 = null;
var tableStage2 = null;
var tableStage3 = null;
var tableStage4 = null;
var tableStage5 = null;
var pagingPlayoff = false;
var tableStageGroup0 = [];


function setVariablesDataTable(totalQualify, indexRelegate, stageInitial, roundInitial, totalListOfStage, totalListOfGroups, teamsForGroup) {
    var divStageSelected = $("div[stageID='" + stageInitial + "']").attr("id").replace("stage","");
    if ($("#onlyOnePlayOffGame").val() == "") { pagingPlayoff = true; } else { pagingPlayoff = false; }

    roundInitial = roundInitial - 1;

    if (teamsForGroup == 0) {
        if ($('#datatable-responsive-stage1').length > 0) {
            tableStage0 = $('#datatable-responsive-stage1').DataTable({
                "paging": true,
                "ordering": false,
                "lengthMenu": [parseInt($("#totalMatchesPerRoundStage0").val())],
                "lengthChange": false,
                "processing": true,
                "searching": false
            });

            if (stageInitial == 0) {
                tableStage0.page(roundInitial).draw('page');
            }
            else {
                tableStage0.page(tableStage0.page.info().pages - 1).draw('page');
            }
            showRoundDetails($('#datatable-responsive-stage1'));
            markSituationTeamOnTable(totalQualify, indexRelegate, 0);
        }
    }
    else {
        for (var i = 0; i < totalListOfGroups; i++) {
            if ($('#datatable-responsive-stage1-' + (i + 1)).length > 0) {
                tableStageGroup0.push(null);
                tableStageGroup0[i] = $('#datatable-responsive-stage1-' + (i + 1)).DataTable({
                    "paging": true,
                    "ordering": false,
                    "lengthMenu": [parseInt($("#totalMatchesPerRoundStage0").val())],
                    "lengthChange": false,
                    "processing": true,
                    "searching": false
                });

                if (stageInitial == 0) {
                    tableStageGroup0[i].page(roundInitial).draw('page');
                }
                else {
                    tableStageGroup0[i].page(tableStageGroup0[i].page.info().pages - 1).draw('page');
                }
                showRoundDetailsForGroup(i);
                markSituationTeamOnTableGroup(totalQualify, i);
            }
        }
    }

    if ($('#datatable-responsive-stageplayoff-1').length > 0) {
        tableStage_1 = $('#datatable-responsive-stageplayoff-1').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff-1").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == -1 && pagingPlayoff) {
            tableStage_1.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff-1'));
    }

    if ($('#datatable-responsive-stageplayoff-2').length > 0) {
        tableStage_2 = $('#datatable-responsive-stageplayoff-2').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff-2").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == -2 && pagingPlayoff) {
            tableStage_2.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff-2'));
    }

    if ($('#datatable-responsive-stageplayoff1').length > 0) {
        tableStage1 = $('#datatable-responsive-stageplayoff1').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff1").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == 1 && pagingPlayoff) {
            tableStage1.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff1'));
    }

    if ($('#datatable-responsive-stageplayoff2').length > 0) {
        tableStage2 = $('#datatable-responsive-stageplayoff2').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff2").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == 2 && pagingPlayoff) {
           tableStage2.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff2'));
    }

    if ($('#datatable-responsive-stageplayoff3').length > 0) {
        tableStage3 = $('#datatable-responsive-stageplayoff3').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff3").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == 3 && pagingPlayoff) {
            tableStage3.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff3'));
    }

    if ($('#datatable-responsive-stageplayoff4').length > 0 && $("totalMatchesPerRoundstageplayoff4").val() != "0") {
        tableStage4 = $('#datatable-responsive-stageplayoff4').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff4").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == 4 && pagingPlayoff) {
            tableStage4.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff4'));
    }

    if ($('#datatable-responsive-stageplayoff5').length > 0 && $("totalMatchesPerRoundstageplayoff5").val() != "0") {
        tableStage5 = $('#datatable-responsive-stageplayoff5').DataTable({
            "paging": pagingPlayoff,
            "ordering": false,
            "lengthMenu": [parseInt($("#totalMatchesPerRoundstageplayoff5").val())],
            "lengthChange": false,
            "processing": true,
            "searching": false
        });
        if (stageInitial == 5 && pagingPlayoff) {
            tableStage5.page(roundInitial).draw('page');
        }
        showRoundDetails($('#datatable-responsive-stageplayoff5'));
    }
    displayDatailsStages(divStageSelected, totalListOfStage);
    if ($("#forGroup").val() == "1" && divStageSelected=="1")
        displayDatailsGroupsStage(divStageSelected, totalListOfGroups);

}

function markSituationTeamOnTable(totalQualify, indexRelegate, indexJustOnePlace) {
    if (tableStage0 != null) {
        $("tbody.tableBodyContainer").find("tr").filter(function (index) {
            if (index < parseInt(totalQualify)) { return true; } else { return false; }
        }).addClass("gentelella-teamtable-qualified");

        if (parseInt(indexRelegate) > 0) {
            $("tbody.tableBodyContainer").find("tr").filter(function (index) {
                if (index > parseInt(indexRelegate)) { return true; } else { return false; }
            }).addClass("gentelella-teamtable-relegated");
        }
        if (parseInt(indexJustOnePlace) > 0) {
            $("tbody.tableBodyContainer").find("tr").filter(function (index) {
                if (index == parseInt(indexJustOnePlace)) { return true; } else { return false; }
            }).addClass("gentelella-teamtable-relegated");
        }
    }

}

function markSituationTeamOnTableGroup(totalQualify, index) {
    if (tableStageGroup0[index] != null) {
        $("tbody.tableBodyContainer-" + (index+1)).find("tr").filter(function (index) {
            if (index < parseInt(totalQualify)) { return true; } else { return false; }
        }).addClass("gentelella-teamtable-qualified");
    }

}

function showRoundDetails(objTDDetails) {
    var totalMatchByRound = 0;
    var round = 0;
    var filterList = 0;
    var roundDetails = "";
    var descrptionStageNoExist = "Esta fase <b>NÃO</b> foi gerada ainda, aguarde o final do prazo da fase anterior para que a moderação gere esta fase.";
    if (objTDDetails.attr("id").indexOf("stage1") > -1) {

        totalMatchByRound = parseInt($("#totalMatchesPerRoundStage0").val());
        round = tableStage0.page.info().page + 1;
        filterList = (totalMatchByRound * round) - (totalMatchByRound - 1);

        roundDetails = $("#tr" + filterList).children("td:first").html();
        $("#stageID-0-roundDetails").html(roundDetails);

    }
    else if (objTDDetails.attr("id").indexOf("stageplayoff") > -1) {

        var stageID = objTDDetails.attr("id").replace("datatable-responsive-", "").replace("_paginate", "");
        totalMatchByRound = parseInt($("#totalMatchesPerRound" + stageID).val());

        if (stageID == "stageplayoff-1")
            round = tableStage_1.page.info().page + 1;
        else if (stageID == "stageplayoff-2")
            round = tableStage_2.page.info().page + 1;
        else if (stageID == "stageplayoff1")
            round = tableStage1.page.info().page + 1;
        else if (stageID == "stageplayoff2")
            round = tableStage2.page.info().page + 1;
        else if (stageID == "stageplayoff3")
            round = tableStage3.page.info().page + 1;
        else if (stageID == "stageplayoff4")
            round = tableStage4.page.info().page + 1;
        else if (stageID == "stageplayoff5")
            round = tableStage5.page.info().page + 1;

        if (!isNaN(round)) {
            filterList = (totalMatchByRound * round) - (totalMatchByRound - 1);
            if ($("#tr" + stageID + "-" + filterList).length > 0) {
                roundDetails = $("#tr" + stageID + "-" + filterList).children("td:first").html();
                if (String(roundDetails).indexOf("&lt;roundLegNum&gt;") > -1 && round == 1)
                    roundDetails = roundDetails.replace("&lt;roundLegNum&gt;", "Jogo de Ida");
                else if (String(roundDetails).indexOf("&lt;roundLegNum&gt;") > -1 && round == 2)
                    roundDetails = roundDetails.replace("&lt;roundLegNum&gt;", "Jogo de Volta");

                $("#" + stageID + "-roundDetails").html(roundDetails);
            }
            else
                $("#" + stageID + "-roundDetails").html(descrptionStageNoExist);
        }
        else
            $("#" + stageID + "-roundDetails").html(descrptionStageNoExist);

    }
}

function showRoundDetailsForGroup(indexGroup) {
    var totalMatchByRound = 0;
    var round = 0;
    var filterList = 0;
    var roundDetails = "";
    totalMatchByRound = parseInt($("#totalMatchesPerRoundStage0").val());
    round = tableStageGroup0[indexGroup].page.info().page + 1;
    filterList = (totalMatchByRound * round) - (totalMatchByRound - 1);

    roundDetails = $("#tr" + filterList).children("td:first").html();
    $("#stageID-0-roundDetails-" + (indexGroup + 1)).html("Grupo " + (indexGroup + 1) + " - " + roundDetails);
}

function displayDatailsStages(pTypeStage, totalListOfStage, totalListOfGroups) {
    for (var i = 1; i <= totalListOfStage; i++) {
        if (i == parseInt(pTypeStage)) { $("#stage" + i).show(); }
        else { $("#stage" + i).hide(); }
    }
    colorStages(pTypeStage, totalListOfStage);
    $(".bs-callout-warning").addClass("gentelella-hidden");

    if ($("#forGroup").val() == "1" && pTypeStage == 1) {
        $("#groupID").val(pTypeStage);
        displayDatailsGroupsStage($("#groupID").val(), totalListOfGroups);
    }
    else if ($("#forGroup").val() == "1" && pTypeStage != 1) {
        $("#groupID").val("ALL");
        setSourceImgTeamLogoForGroup();
    }
}

function colorStages(pTypeStage, totalListOfStage) {
    for (var i = 1; i <= totalListOfStage; i++) {
        if (i == pTypeStage) { $(".stage" + i).addClass("gentelella-btn-dark"); }
        else { $(".stage" + i).removeClass("gentelella-btn-dark"); }
    }
}


function displayDatailsStage1(pTypeDetail) {
    if (pTypeDetail == "matchTable") {
        $("#matchTable").show();
        $("#teamTable").hide();
    }
    else {
        $("#matchTable").hide();
        $("#teamTable").show();
    }
    colorStage1(pTypeDetail);
    $(".bs-callout-warning").addClass("gentelella-hidden");
}

function colorStage1(pTypeDetail) {
    if (pTypeDetail == "matchTable") {
        $(".matchTable").removeClass("gentelella-btn-default").addClass("gentelella-btn-success");
        $(".teamTable").removeClass("gentelella-btn-success").addClass("gentelella-btn-default");
    }
    else {
        $(".teamTable").removeClass("gentelella-btn-default").addClass("gentelella-btn-success");
        $(".matchTable").removeClass("gentelella-btn-success").addClass("gentelella-btn-default");
    }
}

function setSourceImgTeamLogo() {
    var container = document.querySelector("tbody.tableBodyContainer");
    var matches = container.querySelectorAll("img");
    for (var i = 0; i < matches.length; i++) {
        $("img[listMatchTeamID='" + matches[i].id + "']").each(function () {
            $(this).attr('src', matches[i].src);
        })
    }
}

function setSourceImgTeamLogoForGroup() {
    if ($("#groupID").val().indexOf("ALL") == -1) {
        var container = document.querySelector("tbody.tableBodyContainer-" + $("#groupID").val());
        var matches = container.querySelectorAll("img");
        for (var i = 0; i < matches.length; i++) {
            $("img[listMatchTeamID='" + matches[i].id + "']").each(function () {
                $(this).attr('src', matches[i].src);
            })
        }
    }
    else {
        var total = parseInt($("#totalGroups").val());

        for (var j = 1; j <= total; j++) {
            var container = document.querySelector("tbody.tableBodyContainer-" + j);
            var matches = container.querySelectorAll("img");
            for (var i = 0; i < matches.length; i++) {
                $("img[listMatchTeamID='" + matches[i].id + "']").each(function () {
                    $(this).attr('src', matches[i].src);
                })
            }
        }
    }
}

function displayDatailsGroupsStage(pTypeGroup, totalListOfGroup) {
    displayDatailsGroupStage1("matchTable", totalListOfGroup);
    for (var i = 1; i <= totalListOfGroup; i++) {
        if (i == parseInt(pTypeGroup)) { $("div[groupIDx='" + i + "']").show(); }
    }
    colorGroups(pTypeGroup, totalListOfGroup);
    $(".bs-callout-warning").addClass("gentelella-hidden");
    setSourceImgTeamLogoForGroup();
}

function colorGroups(pTypeGroup, totalListOfGroup) {
    for (var i = 1; i <= totalListOfGroup; i++) {
        if (i == pTypeGroup) { $(".group" + i).addClass("gentelella-btn-dark"); }
        else { $(".group" + i).removeClass("gentelella-btn-dark"); }
    }
}


function displayDatailsGroupStage1(pTypeDetail, totalListOfGroup) {
    for (var i = 1; i <= totalListOfGroup; i++) {
        $("#matchTable[groupID='" + i + "']").hide();
        $("#teamTable[groupID='" + i + "']").hide();
    }
    if (pTypeDetail == "matchTable") {
        $("#matchTable[groupID='" + $("#groupID").val() + "']").show();
        $("#teamTable[groupID='" + $("#groupID").val() + "']").hide();
    }
    else {
        $("#teamTable[groupID='" + $("#groupID").val() + "']").show();
        $("#matchTable[groupID='" + $("#groupID").val() + "']").hide();
    }
    colorGroup1(pTypeDetail);
    $(".bs-callout-warning").addClass("gentelella-hidden");
}

function colorGroup1(pTypeDetail) {
    if (pTypeDetail == "matchTable") {
        $(".matchTable").removeClass("gentelella-btn-default").addClass("gentelella-btn-success");
        $(".teamTable").removeClass("gentelella-btn-success").addClass("gentelella-btn-default");
    }
    else {
        $(".teamTable").removeClass("gentelella-btn-default").addClass("gentelella-btn-success");
        $(".matchTable").removeClass("gentelella-btn-success").addClass("gentelella-btn-default");
    }
}
