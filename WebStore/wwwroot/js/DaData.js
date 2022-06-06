$(function () {
    var daDataTimer;

    $("[data-action='dadata']").click(function (event) {
        $(this).dropdown("hide");
    });

    $("[data-action='dadata']").keyup(function (event) {
        $(this).dropdown("hide");
        $this = $(this);
        clearTimeout(daDataTimer);
        daDataTimer = setTimeout(function () {
            let val = $this.val();

            if ($this.attr("data-last-val") != val) {
                if (checkingValid(val) === true) {
                    $this.attr("data-last-val", val);
                    daDataRequest($this);
                }
            }
        }, 1000)
    });
});

function checkingValid(text) {
    if (text != '') { 
        let pattern = /^[,.а-яА-ЯёЁ0-9\s\-]+$/;

        return pattern.test(text);
    }
}

function fillDropDown($input, values) {
    let $container = $input.next();
    let $sample = $container.find("li.sample");
    $container.empty();
    $container.append($sample);
    values.forEach(function (item) {
        let $li = $sample.clone();
        $li.text(item.value);
        $li.click(function () {
            $input.val($li.text());
        })
        $sample.before($li);
        $li.removeClass("d-none").removeClass("sample");
    })
}

function daDataRequest($input) {
    let url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";
    let token = "be53b77b706cf3258db030adcf8de2ce3baf7831";

    let options = {
        method: "POST",
        mode: "cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + token
        },
        body: JSON.stringify({ query: $input.val(), count: 5 })
    }

    fetch(url, options)
        .then(function (response) {
            return response.text()
        })
        .then(function (result) {
            fillDropDown($input, JSON.parse(result).suggestions)
            $input.dropdown("show");
            console.log(JSON.parse(result).suggestions[0].value);
        })
        .catch(function (error) {
            console.log("error", error)
        });
}