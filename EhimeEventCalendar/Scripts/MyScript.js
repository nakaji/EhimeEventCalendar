$(function () {
    $("#StartTime_Date").datepicker({ dateFormat: "yy/mm/dd" });
    $("#EndTime_Date").datepicker({ dateFormat: "yy/mm/dd" });

    $("#getEventInfo").click(function () {
        $.ajax({
            type: "GET",
            url: "/api/Events",
            data: "url=" + $("#Url").val(),
            success: function (json) {
                $("#Title").val(json.Title);
                var date = new Date(json.StartTime);
                $("#StartTime_Date").val(date.getFullYear() + "/" + ("0"+(date.getMonth() + 1)).slice(-2) + "/" + ("0"+date.getDay())).slice(-2);
                $("#StartTime_Hour").val(date.getHours());
                $("#StartTime_Minute").val(date.getMinutes());
                date = new Date(json.EndTime);
                $("#EndTime_Date").val(date.getFullYear() + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + ("0" + date.getDay())).slice(-2);
                $("#EndTime_Hour").val(date.getHours());
                $("#EndTime_Minute").val(date.getMinutes());
                //$("#Contents").val(json.Contents);
                CKEDITOR.instances.Contents.setData(json.Contents);
                $("#Venue_Name").val(json.Venue.Name);
                $("#Venue_Address").val(json.Venue.Address);
                $("#Venue_Url").val(json.Venue.Url);
            }
        });
    });
});
