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
})