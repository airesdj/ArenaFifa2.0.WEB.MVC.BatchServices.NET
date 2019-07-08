function detectMobileDevice()
{
   var uagent = navigator.userAgent.toLowerCase();
   if (uagent.search("iphone") > -1 || uagent.search("mobile") > -1)
	  return 1;
   else
	  return 0;
}
function hidden_show_ObjectMobile(listOfObject, typeObject) {
	var arrayList = listOfObject.split(",");
	for (var i = 0; i<arrayList.length;i++) {
		document.getElementById(arrayList[i]).style.display = typeObject;
	}
}

function setContentHeightRegistration() {
        //$(".gentelella-right_col").css('min-height', $(window).height());

        var bodyHeight = $('body').outerHeight(),
            footerHeight = $('body').hasClass('footer_fixed') ? -10 : $("footer").height(),
            leftColHeight = $(".gentelella-left_col").eq(1).height() + $(".sidebar-footer").height(),
            contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

        // normalize content
        contentHeight -= $(".gentelella-nav_menu").height() + footerHeight + bodyHeight;

        $(".gentelella-right_col").css('min-height', contentHeight);
}


function activeSidebarMenu(pUrl) {
    var activePage = pUrl //pUrl.substring(pUrl.lastIndexOf('/') + 1);
	$("#sidebar-menu").find('a[href="' + activePage + '"]').parent('li').addClass('current-page');
	$("#sidebar-menu").find('a[href="' + activePage + '"]').attr("style", "color: #f0ad4e;font-weight:bold"); 
	$("#sidebar-menu").find('a[href="' + activePage + '"]').parent('li').parents('ul').slideDown(function() {
		setContentHeightRegistration();
	}).parent().addClass('active');
}

function onUploadLogoTeamClub(pNameInputFile, pNameInputImg) {
    changeQuestionDescriptionUpdateLogo(pNameInputFile);
    $("#" + pNameInputFile).on('change', function () {
        var returnMessage = "";
        var fileExtension = $(this).val().substring($(this).val().lastIndexOf(".") + 1, $(this).val().length);

        if (fileExtension.toLowerCase() != "jpg" && fileExtension.toLowerCase() != "jpeg" && fileExtension.toLowerCase() != "png")
            returnMessage = "Somento arquivos JPG, JPEG e PNG sao permitidos!";

        if ($(this)[0].files[0].size / 1024 > 70)
            returnMessage = "O tamanho maximo permitido para o novo arquivo eh de 70Kb!";

        if (returnMessage != "") {
            $("#modalScreeenResultTitle").html("UPLOAD LOGO");
            $("#modalScreeenResultSubTitle").html("Upload nao pode ser executado");
            $(this).attr("data-toggle", "modal");
            $(this).attr("data-target", "#bs-result-modal-sm");
            $("#modalScreeenResultMessage").html(returnMessage);
            $('#bs-result-modal-sm').modal('show');
            $(this).attr("data-toggle", "");
            $(this).attr("data-target", "");
            $(this).val(null);
        }
        else {
            readURL($(this)[0], pNameInputImg);
        }
    });
}

function readURL(input, pNameInputImg) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#" + pNameInputImg).attr("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}


function changeQuestionDescriptionUpdateLogo(pNameInputFile) {
    $("button.update-logo").on("click", function () {
        if ($("#fileLogoTeam").val() == "")
            $('#registration-form-logo').submit();
        else {
            var pathFileSplit = $("#" + pNameInputFile).val().split("\\");
            var fileName = pathFileSplit[pathFileSplit.length - 1];
            $(this).attr("data-toggle", "modal");
            $(this).attr("data-target", "#bs-delete-modal-sm");
            $("#modalScreeenDeleteTitle").html("ATUALIZANDO DADOS DO CLUBE");
            $("#modalScreeenDeleteSubTitle").html("Alterar Logo do Clube");
            $("#modalScreeenDeleteQuestion").html("Deseja realmente alterar a logo do seu clube?<br><b>Nova Logo: " + fileName + "</b>");
            $("#modalScreeenDeleteButton").on("click", function () { $('#registration-form-logo').submit(); });
            $('#bs-delete-modal-sm').modal('show');
            $(this).attr("data-toggle", "");
            $(this).attr("data-target", "");
        }
    });
}

