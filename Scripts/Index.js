$(function () {

    $("#UserSelect").change(function (e)
    {
        
        if (e.target.selectedIndex === 0)
        {
            $("#MainTableContent").empty();
            $("#MainTable, #ErrorMessage").addClass("hidden");
            $("#NoContentMessage").removeClass("hidden");
            return;
        }


        var data = { id : e.target.value };

        $.ajax({
            type: "GET",
            url: "/Home/GetUserProjectInfo",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    });

    function successFunc(data, status)
    {
        if (status !== "success")
        {
            errorFunc();
            return;
        }

        var table = $("#MainTableContent");
        $("#MainTable").removeClass("hidden");
        $("#NoContentMessage, #ErrorMessage").addClass("hidden");
        table.empty();

        var projects = $.parseJSON(data);


        $.each(projects, function (i, item) {

            table.append(
                '<tr>' +
                '<th scope="row">' + item.ProjectId + '</th>' +
                '<td>' + formatDate(new Date(item.StartDate)) + '</td>' +
                '<td>' + item.TimeToStart + '</td>' +
                '<td>' + formatDate(new Date(item.EndDate)) + '</td>' +
                '<td>' + item.Credits + '</td>' + 
                '<td>' + item.Status + '</td>' +
                '</tr>');
            
        });
        
    }

    function errorFunc(xhr, statusText, thrownError) {
        $("#ErrorMessage").removeClass("hidden");
        $("#NoContentMessage, #MainTable").addClass("hidden");
    }

    var formatDate = function (date) {

        var month = parseInt(date.getMonth()) + parseInt(1);

        return ('0' + month).slice(-2) + "/" + ('0' + date.getDate()).slice(-2) + "/" + date.getFullYear();
    }

        
});