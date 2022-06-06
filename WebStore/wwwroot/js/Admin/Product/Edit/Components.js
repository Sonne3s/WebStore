$(function () {
    $("button[data-action='add-component']").click(function () {
        $this = $(this);

        let counter = parseInt($this.attr("data-new-component-counter"));
        $this.attr("data-new-component-counter", counter + 1)
        let componentName = $this.prev("input").val();
        let inputUrl = $this.attr("data-input-url") + "?name=" + componentName + "&counter=" + counter;
        let containerUrl = $this.attr("data-container-url") + "?name=" + componentName + "&counter=" + counter;
        let addComponentButtonContainer = $("#add-component-button-container");
        let componentContainers = $("#properties-containers");

        $.ajax({
            url: inputUrl,
        }).done(function (data) {
            let $data = $(data);
            let $fakeContainer = $("<div></div>");
            $fakeContainer.append($data);
            setClickHandler($fakeContainer);
            addComponentButtonContainer.before($data);
        });

        $.ajax({
            url: containerUrl,
        }).done(function (data) {
            let $data = $(data);
            setAddPropertyChoiseHandler($data);
            componentContainers.append($data);
        });
    });

    //setRadioState($("[type='radio'].active"));
    //setClickHandler($(this));

    function setRadioState($target) {
        $("[type='radio'][role='tab']").attr("data-last-state", "unactive");
        $target.attr("data-last-state", "active");
    }

    function setClickHandler($target) {
        $target.find("[type='radio']").click(function (e) {
            $this = $(this);
            $form = $("#" + Admin.Edit.FormId);
            if ($form.validate().form()) {
                $this.tab('show');
                setRadioState($this);
            }
            else {
                $("[name='" + $this.attr("name") + "']").removeClass("active").prop('checked', false);;
                let lastRadio = $("[data-last-state='active']");
                lastRadio.addClass("active").prop('checked', true);;
            }
        });
    }
});