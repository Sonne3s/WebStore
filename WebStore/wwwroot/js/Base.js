$.fn.purpose = function (name) {
    if (name === undefined) {
        return this.attr("data-purpose");
    }

    let result = this.find("[data-purpose='" + name + "']");
    if (this.hasAttr(name)) {
        result.add(this);
    }

    return result
};

var AttrSelector = function (attrName, attrValue) {
    return "[" + attrName + "='" + attrValue + "']";
};

String.prototype.LastSelector = function LastSelector() {
    return this + ":last";
};