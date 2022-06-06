$(function () {
    $("[type='tel']").change(function () {
        let $this = $(this);
        formatPhoneNumber($this.val(), $this);
    });
});

function formatPhoneNumber(phoneNumberString, $input) {
    var cleaned = ('' + phoneNumberString).replace(/\D/g, '')
    var match = cleaned.match(/^(7|8|0)?(\d{3})(\d{3})(\d{4})$/)
    if (match) {
        $input.val(['+7', '(', match[2], ') ', match[3], '-', match[4]].join(''));
    }
    else {
        $input.closest("form").find("[type='submit']").click();
    }
}