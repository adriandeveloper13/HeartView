var doctorModule = function() {

    function setPostData() {
        var postData = new FormData($("#save-doctor")[0]);

        return postData;
    }

    function create(aspNetUserId) {
        debugger;

        //var result = commonModule.validateForm("save-doctor");
        //if (!result) {
        //    return;
        //}

        var postData = setPostData();
        postData.append("AspNetUserId", aspNetUserId);

        ajaxHelper.postFile("/Doctori/Create", postData, function (data) {
                debugger;
                if (commonModule.isDataValid(data)) {
                    commonModule.navigate("/Pacienti/Listare?doctorId=" +data.Id );
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