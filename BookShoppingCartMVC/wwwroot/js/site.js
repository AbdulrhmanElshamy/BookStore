function onModalSuccess(response) {
    $(".books-section").empty();
    $(".books-section").append(response);
}


function AddItem(res) {
    if (res > 99) {
        $('.cart-count').text("99+");
    }
    $('.cart-count').text(res);
}

$(document).ready(function () {
    if ($('.cart-count').length > 0) {
        $.ajax({
            type: 'GET',
            url: "/Cart/GetCartItems",
            success: function (count) {
                console.log(count);
                AddItem(count)
            }
        });
    }
})