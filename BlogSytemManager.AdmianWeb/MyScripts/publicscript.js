function SearchTop(controllername,id) {
    var parm = $("#" + id).attr("name");
    var value = $("#" + id).val();
    window.location.href = "/BaseAdmin/PublicSearch?controllname=" + controllername + "&wherename=" + parm + "&wherevalue=" + value;
}