$(function () {
    $("button[data-action='add-component']").click(function() {
        $this = $(this);
        let componentId = parseInt($this.attr("data-index"), 10);
        $this.attr("data-index", componentId + 1);
        let componentName = $this.prev("input").val();

        let inputId = "input-component" + componentId;
        let tabId = "tab-component" + componentId;

        let parent = $this.closest("div");
        let sampleInput = parent.next();
        let cloneInput = sampleInput.clone(true);
        cloneInput.children("input").attr("id", inputId);
        cloneInput.children("input").attr("data-bs-target", "#" + tabId);
        cloneInput.children("label").append(componentName);
        cloneInput.children("label").attr("for", inputId);
        parent.before(cloneInput.children());

        let sampleTabPane = $(".tab-pane.sample");
        let cloneTabPane = sampleTabPane.clone(true);
        cloneTabPane.removeClass("sample");
        cloneTabPane.attr("id", tabId);
        let cloneTabPaneAddPropertyButton = cloneTabPane.children("button");
        cloneTabPaneAddPropertyButton.attr("data-val", cloneTabPaneAddPropertyButton.attr("data-val") + "?componentId=" + componentId);
        let cloneTabPaneHiddenInputForName = cloneTabPane.children("input[name='component']");
        cloneTabPaneHiddenInputForName.val(componentName);
        cloneTabPaneHiddenInputForName.attr("id", "Component" + componentId + "Name");
        cloneTabPaneHiddenInputForName.attr("name", "Component" + componentId + "Name");
        sampleTabPane.before(cloneTabPane);
    });

    $("button[data-action='remove-component']").click(function () {
        let $this = $(this);
        let $label = $this.prev();
        let $input = $label.prev();
        let $generalInput = $($("[name='" + $input.attr("name") + "']")[0]);
        let targetId = $input.attr("data-bs-target");
        let $container = $(targetId);
        $container.remove();
        $input.remove();
        $label.remove();
        $this.remove();
        $generalInput.click();
    });
});