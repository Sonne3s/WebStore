$(function () {
    initial();

    $("[data-action='remove-img']").click(function () {
        $this = $(this)
        let input = document.getElementById('images');
        let images = Array.from(input.files);
        let $img = $($this.prev());
        let name = $img.attr("data-filename");
        let lastModified = $img.attr("last-modified");
        let file = images.find(function (item) {
            return item.name === name && item.lastModified == lastModified;
        });
        let fileIndex = images.indexOf(file);
        images.splice(fileIndex, 1);
        let container = new DataTransfer();
        images.forEach(function (item) {
            container.items.add(item);
        });
        input.files = container.files;
        $(input).data("oldValues", input.files);
        $this.parent().remove();
    });

    $('#images').on('change', function () {
        $this = $(this);
        let oldValues = $this.data("oldValues");
        imagesPreview(this, $('div.gallery'));
        if (oldValues != undefined) {
            this.files = appendToFileList(oldValues, this.files);
        }
        $this.data("oldValues", this.files);
    });
});

function initial() {
    let fileInputElement = document.getElementById('images');
    let container = new DataTransfer();
    let images = $.map($(".image-container:not(.sample)").find(".upload-image"), function (obj, i) {
        return {
            Base64: $(obj).attr("src"),
            Name: $(obj).attr("data-filename"),
            pageObj: $(obj),
        }
    });
    images.forEach(function (item) {
        urltoFile(item.Base64, item.Name).then(function (file) {
            container.items.add(file);
            item.pageObj.attr("last-modified", file.lastModified);
            if (container.items.length === images.length) {
                fileInputElement.files = container.files;
                $(fileInputElement).data("oldValues", container.files);
            }
        });
    });
}

function getSorted(array, attrName) {
    return $(array.sort(function (a, b) {
        var aVal = parseInt(a.getAttribute(attrName)),
            bVal = parseInt(b.getAttribute(attrName));
        return aVal - bVal;
    }));
}

function sortAfterUpload(arrayComponents, fileList, $placeToInsertImagePreview) {
    if (arrayComponents.length === fileList.length) {
        getSorted(arrayComponents, "data-id").appendTo($placeToInsertImagePreview);
    }
}

function urltoFile(url, filename, mimeType) {
    mimeType = mimeType || (url.match(/^data:([^;]+);/) || '')[1];
    return (fetch(url)
        .then(function (res) { return res.arrayBuffer(); })
        .then(function (buf) { return new File([buf], filename, { type: mimeType }); })
    );
}

function imagesPreview(input, $placeToInsertImagePreview) {
    if (input.files) {
        let filesAmount = input.files.length;
        let images = [];
        for (i = 0; i < filesAmount; i++) {
            addPreview(input.files, i, images, $placeToInsertImagePreview);
        }
    }
};

function addPreview(fileList, index, array, $placeToInsertImagePreview) {
    let reader = new FileReader();
    let file = fileList[index];
    reader.onload = function (event) {
        let lastDataId = parseInt($placeToInsertImagePreview.attr("data-last-id") || 0);
        let dataId = lastDataId + index + 1;
        let container = $(".image-container.sample").clone(true);
        container.removeClass("d-none").removeClass("sample");
        let image = container.find("img");
        image.attr("src", event.target.result);
        image.attr("data-filename", file.name);
        image.attr("last-modified", file.lastModified);
        image.attr("last-modified", file.lastModified);
        image.attr("data-id", dataId);
        array.push(container[0]);
        sortAfterUpload(array, fileList, $placeToInsertImagePreview);
    }
    reader.readAsDataURL(file);
}

function appendToFileList(lastFileList, newFileList) {
    let lastFileListArray = Array.from(lastFileList);
    let newFileListArray = Array.from(newFileList);
    let concatenatedFileListArray = lastFileListArray.concat(newFileListArray);
    let container = new DataTransfer();
    concatenatedFileListArray.forEach(function (item) {
        container.items.add(item);
    });

    return container.files;
}