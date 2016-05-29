var commonModule = function () {

    function isDataValid(data) {
        return typeof (data) != "undefined" && data != null ;//todo here i deleted the condition: data.Success != null
    }

    function guid() {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + "-" + s4() + "-" + s4() + "-" +
          s4() + "-" + s4() + s4() + s4();
    }

    function navigate(endPointUrl) {
        window.location.href = endPointUrl;
    }

    function refreshPage(refreshUrl, tableName) {
        debugger;
        ajaxHelper.getWithoutData(refreshUrl,
            function (partialView) {
                debugger;
                $(tableName).html(partialView);
            });
    };


    function mark(id, endPointUrl, refreshUrl, tableName) {

        var postData = new Object();
        postData.id = id;

        ajaxHelper.post(endPointUrl, postData, function (data) {
            debugger;
            if (isDataValid(data)) {
                debugger;
                refreshPage(refreshUrl, tableName);
            } else {
                navigate("/Home/Index");
            }
        }, function () {
            navigate("/Home/Index");
        });
    };

    function baseEdit(id, endPointUrl) {
        window.location.href = endPointUrl + id;
    };


    function toggleLoadingOn(loadingBackground, loadingImage) {
        $(loadingBackground).show();
        $(loadingImage).show();
    }

    function toggleLoadingOff(loadingBackground, loadingImage) {
        $(loadingBackground).hide();
        $(loadingImage).hide();
        $("#loading-message").html("");
        $("#loading-message").hide();
    }

    function toggleLoadingWithMessageOn(message) {
        $("#loading-message").html(message);
        $("#loading-message").show();
        toggleLoadingOn("#overlay", "#loading");
    }

    function validateForm(formName) {
        var $form = $("#" + formName);
        $form.validate();
        return $form.valid();
    };

    function validateAjaxForm(formName) {
        var $form = $("#" + formName);
        $form.validate();

        $form.unbind();
        $form.data("validator", null);
        $.validator.unobtrusive.parse($form);

        return $form.valid();
    }

    return {
        guid: guid,
        toggleLoadingWithMessageOn: toggleLoadingWithMessageOn,
        mark: mark,
        baseEdit: baseEdit,
        toggleLoadingOn: toggleLoadingOn,
        toggleLoadingOff: toggleLoadingOff,
        validateForm: validateForm,
        validateAjaxForm: validateAjaxForm,
        navigate: navigate,
        refreshPage: refreshPage,
        isDataValid: isDataValid
    };
}();