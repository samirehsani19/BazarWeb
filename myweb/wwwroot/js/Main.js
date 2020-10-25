const shoppingUrl = "https://localhost:44377/api/v1.0/Shopping";

//Getting product id by clicked and sent it to controller by url
function AddToCart(item) {
    var itemId = $(item).attr("itemid");
    console.log("Current item id = " + itemId);

    $.ajax({
        url: shoppingUrl,
        data: JSON.stringify({ ProductID: itemId }),
        type: "Post",
        contentType: "application/json; charset=utf-8",
        success: function (response) {

            console.log("ProductID posted succesfull");
            console.log(response);
            $("#cartItem").text("Cart(" + response + ")").css({ "font-size": "20px" });

        }, error: function () {
            alert("Failed to add product to shopping cart ");
        }
    });
}
