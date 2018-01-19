var pacientModule = function () {

    function setPostData() {
        var postData = new FormData($("#save-pacient")[0]);

        return postData;
    }

    function create(aspNetUsetId, doctorId) {
        debugger;

        //var result = commonModule.validateForm("save-doctor");
        //if (!result) {
        //    return;
        //}

        var postData = setPostData();
        postData.append("IDDoctor", doctorId);
        postData.append("AspNetUserId", aspNetUsetId);

        ajaxHelper.postFile("/Pacienti/Create", postData, function (data) {
            debugger;
            if (commonModule.isDataValid(data)) {
                commonModule.navigate("/Pacienti/Listare?doctorId=" + data.IDDoctor);
            } else {
                commonModule.navigate("/Home/About");
            }
        },
            function () {
                commonModule.navigate("/Home/About");
            });
    };



    function updatePacient(pacientId, doctorId, aspNetUserId) {
        debugger;
        var postData = setPostData();
        postData.append("Id", pacientId);
        postData.append("IDDoctor", doctorId);
        postData.append("AspNetUserId", aspNetUserId);
        ajaxHelper.postFile("/Pacienti/UpdatePacient", postData, function (data) {
            debugger;
            if (commonModule.isDataValid(data)) {
                commonModule.navigate("/Pacienti/Listare?doctorId=" + data.IDDoctor);
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
        updatePacient: updatePacient
    }
}();