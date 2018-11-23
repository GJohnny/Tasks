function searchProduct() {
    debugger;

    var searchTextBox = document.getElementById("search-text");
    var searchText = searchTextBox.value;

    $.ajax({
        url: "/Home/SearchProducts?search=" + searchText,
        method: "get",
        success: function (data) {
            $("#product-search").html(data);
        }
    });
}