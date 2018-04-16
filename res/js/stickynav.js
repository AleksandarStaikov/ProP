$(document).ready(function() {
    $('#stickypoint').waypoint(function(direction) {
        if(direction == 'down') {
            $('#home-nav').addClass('no-display');
            $('#main-nav').addClass('fixed-top scrolling-nav');
            $('#main-nav').slideDown(150);
        } else if(direction == 'up') {
            $('#home-nav').removeClass('no-display');
            $('#main-nav').slideUp(100);
        }
        console.log("asda");
    }, {
        offset: '120px'
    })
})