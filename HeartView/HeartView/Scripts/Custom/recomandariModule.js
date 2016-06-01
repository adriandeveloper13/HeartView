var recomandariModule = function () {

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

    return {
        create: create
    }
}();