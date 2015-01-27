$(function () {
    $("#StartTime_Date").datepicker({ dateFormat: "yy/mm/dd" });
    $("#EndTime_Date").datepicker({ dateFormat: "yy/mm/dd" });
});
$(function () {
    $("#getEventInfo").click(function () {
        $.ajax({
            type: "GET",
            url: "/api/Events",
            data: "url=" + $("#Url").val(),
            success: function (json) {
                $("#Title").val(json.Title);
                var date = new Date(json.StartTime);
                $("#StartTime_Date").val(date.getFullYear());
                $("#StartTime_Hour").val(date.getHours());
                $("#StartTime_Minute").val(date.getMinutes());
                date = new Date(json.EndTime);
                $("#EndTime_Date").val(date.getFullYear());
                $("#EndTime_Hour").val(date.getHours());
                $("#EndTime_Minute").val(date.getMinutes());
                $("#Contents").val(json.Contents);
                $("#Venue_Name").val(json.Venue.Name);
                $("#Venue_Address").val(json.Venue.Address);
                $("#Venue_Url").val(json.Venue.Url);
            }
        });
    });
});
