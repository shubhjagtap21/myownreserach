// left sub menu
$('.sub-menu ul').hide();
$(".sub-menu a").click(function () {
    $(this).parent(".sub-menu").children("ul").slideToggle("100");
    $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
});

// left menu changes on click 
function sidebar_toggle() {
    var leftdiv = document.getElementById("sidebar-wrapper");
    leftdiv.classList.toggle("left_side_toggle");
    var rightdiv = document.getElementById("wrapper");
    rightdiv.classList.toggle("right_side_toggle");
    var arrow = document.getElementById("rot_arrow");
    arrow.classList.toggle("rotate_arrow");
}

// popover enable
var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function(popoverTriggerEl) {
  return new bootstrap.Popover(popoverTriggerEl)
})

// popover click change
setTimeout((function() { 
    $('[data-bs-toggle=popover]').popover();
  }),500);

  $('body').on('click', function (e) {
    //did not click a popover toggle, or icon in popover toggle, or popover
    if ($(e.target).data('toggle') !== 'popover' && $(e.target).parents('[data-bs-toggle="popover"]').length === 0
        && $(e.target).parents('.popover.in').length === 0) {
        (($('[data-bs-toggle="popover"]').popover('hide').data('bs.popover') || {}).inState || {}).click = false;
    }
    });