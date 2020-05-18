
var IsSelectedArray = $("input:checkbox[name=IsSelected]:checked").map(function ()
{
    return $(this).val()
}).get();

