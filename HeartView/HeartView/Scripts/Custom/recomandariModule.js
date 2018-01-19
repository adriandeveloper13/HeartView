﻿var recomandariModule = function () {

    function setPostData() {
        var postData = new FormData($("#save-recomandare")[0]);

        return postData;
    }

    function create(pacientId) {
        debugger;

        //var result = commonModule.validateForm("save-doctor");
        //if (!result) {
        //    return;
        //}

        var postData = setPostData();
        postData.append("IDPacient", pacientId);

        ajaxHelper.postFile("/Recomandari/CreateRecomandare", postData, function (data) {
            debugger;
            if (commonModule.isDataValid(data)) {
                commonModule.navigate("/Recomandari/ListareRecomandariPacienti?pacientId=" + data.IDPacient);
            } else {
                commonModule.navigate("/Home/About");
            }
        },
            function () {
                commonModule.navigate("/Home/About");
            });
    };


    function updateRecomandare(recomandareId, pacientId, doctorId, aspNetUserId) {
        debugger;
        var postData = setPostData();
        postData.append("Id", pacientId);
        postData.append("IDPacient", PageTransitionEvent);
        postData.append("IDDoctor", doctorId);
        ajaxHelper.postFile("/Recomandari/UpdateRecomandare", postData, function (data) {
            debugger;
            if (commonModule.isDataValid(data)) {
                commonModule.navigate("/Recomandari/ListareRecomandariPacienti?pacientId=" + data.IDPacient +"&doctorId=" + data.IDDoctor);
            } else {
                commonModule.navigate("/Home/About");
            }
        },
            function () {
                commonModule.navigate("/Home/About");
            });
    };

    return {
        create: create,
        updateRecomandare
    }
}();