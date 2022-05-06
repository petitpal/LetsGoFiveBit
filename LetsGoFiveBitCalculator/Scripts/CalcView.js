
$().ready(function () {

    // load up number bases into drop downs
    $.ajax({
        url: '/Calc/GetSupportedBases',
        method: 'GET'
    })
        .done(function (data) {

            var options = '';
            data.forEach(function (option) { options += '<option value=' + option + '>' + option + '</option>' });

            var firstNumberBase = $('#first_base');
            firstNumberBase.html(options);

            var secondNumberBase = $('#second_base');
            secondNumberBase.html(options);

            SetCharLimits('#first_number', firstNumberBase);
            SetCharLimits('#second_number', secondNumberBase);

        });

});

function SetCharLimits(inputControlId, baseCtrl) {

    $.ajax({
        url: '/Calc/GetValidDigitsForBase',
        method: 'GET',
        data: { numberBase: baseCtrl.val() }
    })
        .done(function (data) {

            var allowedCharsRegex = '[';
            data.forEach(function (char) { allowedCharsRegex += char });
            allowedCharsRegex += ']';

            $(inputControlId).off('keydown');
            $(inputControlId).val('');
            $(inputControlId).on('keydown', function (e) {

                if (e.which == 8 || e.which == 46) return true;

                var regex = new RegExp(allowedCharsRegex, 'i');
                return (regex.exec(e.key) != null);

            });
        });

}


function Calculate(op) {

    $.ajax({
        url: '/Calc/Calculate',
        method: 'GET',
        data: {
            operation: op,
            firstNumber: $('#first_number').val(),
            firstBase: $('#first_base').val(),
            secondNumber: $('#second_number').val(),
            secondBase: $('#second_base').val()
        }
    })
        .done(function (data) {
            $('#result').val(data);
        });
}

