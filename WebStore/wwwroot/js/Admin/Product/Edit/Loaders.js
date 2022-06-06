var GetSpinner = function () {
    return $("<h1 class='text-center loader'><i class='emblem-loader-emblem bi bi-tornado'></i><span class='emblem-loader-text'>CL</span></h1>");
}

var InsertSpinner = function ($target) {
    $target.append(GetSpinner());
}

var RemoveSpinner = function ($target) {
    $target.find(".loader").remove();
}