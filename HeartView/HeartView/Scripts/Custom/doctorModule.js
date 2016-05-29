var doctorModule = function() {

    function setPostData() {
        var postData = new FormData($("#save-doctor")[0]);

        return postData;
    }

    function create(aspNetUsetId) {
        debugger;

        //var result = commonModule.validateForm("save-doctor");
        //if (!result) {
        //    return;
        //}

        var postData = setPostData();
        postData.append("AspNetUserId", aspNetUsetId);

        ajaxHelper.postFile("/Doctori/Create", postData, function (data) {
                debugger;
                if (commonModule.isDataValid(data)) {
                    commonModule.navigate("/Home/Index");
                } else {
                    commonModule.navigate("/Home/About");
                }
            },
            function() {
                commonModule.navigate("/Home/About");
            });
    };

    return {
        create: create
    }
}();