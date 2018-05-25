
//////////////////////////////////////////////////////////
// 
//   This code changes the selected text in an extended
//   Bootstrap drop-down list.
// 

$(".bext-dropdown li a").click(function () {
    var selected = $(this).text();
    $(this).parents('.btn-group')
        .find('.bext-dropdown-selected')
        .text(selected);
    var dataValue = $(this).attr("data-value");
    $(this).parents('.btn-group')
        .find('input[type=hidden]')
        .val(dataValue);
});

//////////////////////////////////////////////////////////
// 
//   This code changes the checkmark on a checkbox
//   created as a Bootstrap button.
// 
$(".bext-checkbox").click(function () {
    var hidden = $(this).next();
    var currentStatus = hidden.val().toLowerCase();
    var newStatus = !currentStatus || currentStatus === 'false' ? true : false;
    hidden.val(newStatus);
    var glyph = newStatus ? "glyphicon-ok" : "glyphicon-unchecked";
    $(this).find('span').removeClass("glyphicon-ok").removeClass("glyphicon-unchecked").addClass(glyph);
    $(this).toggleClass("bext-selected");

    // Fire the CHANGE event to receivers
    $(this).trigger({ type: "change", id: hidden.attr('id'), state: hidden.val() });
    $("#" + hidden.id).trigger({ type: "change", id: hidden.attr('id'), state: hidden.val() });
});

