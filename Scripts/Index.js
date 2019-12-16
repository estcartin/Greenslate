$(function () {

    $("#UserSelect").change(function (e)
    {
        // Clear for data if the dropdown is reset by the user.
        if (e.target.selectedIndex === 0)
        {
            $("#MainTableContent").empty();
            $("#MainTable, #ErrorMessage").addClass("hidden");
            $("#NoContentMessage").removeClass("hidden");
            return;
        }

        // Selected value which is the User Id.
        var data = { id: e.target.value };

        // Ajax call to retrieve the projects for the user.
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

    // Handles the success event for the ajax call.
    function successFunc(data, status)
    {
        // Parse the data received from the ajax call
        var projects = $.parseJSON(data);

        // Check for successful call.
        if (status !== "success" && !projects.Status.IsSuccessful)
        {
            errorFunc();
            return;
        }

        // Get and clean the table
        var table = $("#MainTableContent");
        $("#MainTable").removeClass("hidden");
        $("#NoContentMessage, #ErrorMessage").addClass("hidden");
        table.empty();

        // Add each of the received elements to the cleared table.
        $.each(projects.Data, function (i, item)
        {
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

    // Handles the error event for the ajax call.
    function errorFunc(xhr, statusText, thrownError)
    {
        // Display error message if the call failed.
        $("#ErrorMessage").removeClass("hidden");
        $("#NoContentMessage, #MainTable").addClass("hidden");
    }

    // Formats the date to display.
    var formatDate = function (date)
    {
        // Add aditional day to the month. GetMonth function returns 0 - 11 for Jan - Dec
        var month = parseInt(date.getMonth()) + parseInt(1);

        // Return the formatted date.
        return ('0' + month).slice(-2) + "/" + ('0' + date.getDate()).slice(-2) + "/" + date.getFullYear();
    }
});