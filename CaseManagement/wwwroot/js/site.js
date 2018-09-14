
$(".success").click(function () {
    $.bootstrapGrowl('New case created.', {
        type: 'success',
        delay: 2000,
    });
});

$(".successApplicant").click(function () {
    $.bootstrapGrowl('New Applicant Created.', {
        type: 'success',
        delay: 2000,
    });
});



$(".successSubmission").click(function () {
    $.bootstrapGrowl('New Submission Created.', {
        type: 'success',
        delay: 2000,
    });
});



$(".error").click(function () {
    $.bootstrapGrowl('You Got Error', {
        type: 'danger',
        delay: 2000,
    });
});


$(".info").click(function () {
    $.bootstrapGrowl('It is for your kind information', {
        type: 'info',
        delay: 2000,
    });
});


$(".warning").click(function () {
    $.bootstrapGrowl('It is for your kind warning', {
        type: 'warning',
        delay: 2000,
    });
});