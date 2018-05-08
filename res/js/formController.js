$(document).ready(function() {
    $(':text, :password, [type="email"]').on('focus', function() {
        if($(this).attr('id') != 'dob') {
            $("label[for='" + $(this).attr('id') + "']").addClass('active');
        }   
    })

    $(':text, :password, [type="email"]').on('focusout', function() {
        if($(this).val() == "" && $(this).attr('id') != 'dob')
        {
            $("label[for='" + $(this).attr('id') + "']").removeClass('active');
        }
        
    })

    var cal = $('#dob').datepicker({
        showOtherMonths: true
    })

    $('.gj-icon').on('click', function() {
        if($(this).css('color') == 'rgb(66, 133, 244)') {
            $(this).css('color', 'rgba(0, 0, 0, 0.87)');
        } else {
            $(this).css('color', 'rgb(66, 133, 244)');
        }
        
    })
})