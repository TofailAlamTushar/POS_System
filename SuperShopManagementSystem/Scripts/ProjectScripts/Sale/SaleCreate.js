
$(document).ready(function () {
    $("#SaleDate").datepicker({
        autoclose: true
    });
    $("#ItemName").on("change", function () {
        
        var salesQuantity = 0;
        $("#SaleDetailsTable tr ").each(function (index, value) {
            var Quantity = parseInt(($(this).find(".quantity").html()));
            salesQuantity = salesQuantity + Quantity;
        });

        var id = $(this).val();
        $.ajax({
            url: "/Sales/GetItemSalesPrice",
            type: "post",
            data: { id: id },
            success: function (response) {
                $("#ItemPrice").val(response)
            }
        });

        $.ajax({
            url: "/Sales/GetItemStock",
            type: "post",
            data: { id: id },
            success: function (response) {
                var stock = parseInt(response);
                var availabeStock = stock - salesQuantity;
                if (availabeStock <= 0) {
                    $("#Stock").val(0)
                }
                else {
                    $("#Stock").val(availabeStock)
                }
            }
        });
    });

    $("#AddButton").click(function () {
        CreateRowForSale();
    });

    $("#VAT").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).val(0)
        }
        TotalAmount();
    });
    $("#DueAmount").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).val(0);
        }
    });
    $("#Discount").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).val(0);
        }
        TotalAmount();

    });
    
});

function CreateRowForSale() {
    var SelectedItem = GetSelectedItem();

    var index = $("#SaleDetailsTable").children("tr").length;
    var sl = index;

    var indexCell = "<td style='display:none'> <input type='hidden' id='index" + index + "' name='SalesDetails.index' value='" + index + "'/> </td>"
    var serialCell = "<td>" + (++sl) + "</td>";

    var itemNameCell = "<td> <input type='hidden' id='ItemName" + index + "' name='SalesDetails[" + index + "].ItemId' value='" + SelectedItem.ItemName + "' />" + SelectedItem.itemText + " </td>";
    var itemQuantityCell = "<td class='quantity'> <input type='hidden' id='ItemQuntity" + index + "' name='SalesDetails[" + index + "].Quntity' value='" + SelectedItem.ItemQuntity + "' />" + SelectedItem.ItemQuntity + " </td>";
    var itemPriceCell = "<td> <input type='hidden' id='ItemPrice" + index + "' name='SalesDetails[" + index + "].Price' value='" + SelectedItem.ItemPrice + "' />" + SelectedItem.ItemPrice + " </td>";
    var LineTotalCell = "<td class='total'>" + SelectedItem.ItemQuntity * SelectedItem.ItemPrice + " </td>";
    var actionCell = "<td>" + "<input type='button' class='btn btn-danger btn-sm' value='Remove' onclick='GetDeleteId(" + index + ")' id='" + index + "'/>" + "</td>";
    var createNewRow = "<tr id='DelRow_" + index + "'> " + indexCell + serialCell + itemNameCell + itemQuantityCell + itemPriceCell + LineTotalCell + actionCell+" </tr>";

    $("#SaleDetailsTable").append(createNewRow);

    $("#ItemName").val("");
    $("#ItemQuntity").val("");
    $("#ItemPrice").val("");
    $("#ItemStockQuantity").val("");
    SubTotalAmount();
    TotalAmount();
}

function GetSelectedItem() {

    var ItemName = $("#ItemName").val();
    var ItemQuntity = $("#ItemQuntity").val();
    var ItemPrice = $("#ItemPrice").val();
    var ItemStockQuantity = $("#ItemStockQuantity").val();
    var itemText = $("#ItemName option:selected").text();

    var Item= {
        "ItemName": ItemName,
        "ItemQuntity": ItemQuntity,
        "ItemPrice": ItemPrice,
        "ItemStockQuantity": ItemStockQuantity,
        "itemText": itemText
    }
    return Item;
}
var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    SubTotalAmount();
    TotalAmount();
}
function SubTotalAmount() {
    var sumOfTotal = 0;
    if ($("#SaleDetailsTable").children("tr").length == 0) {
        $("#SubTotal").val(0);
    }
    else {
        $("#SaleDetailsTable tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".total").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#SubTotal").val(sumOfTotal);
        });
    }

}
function TotalAmount() {
    var subTotal = $("#SubTotal").val();
    var discount = $("#Discount").val();
    var VAT = $("#VAT").val();

    if (subTotal == "" || subTotal == undefined) {
        subTotal = 0;
    }
    if (discount == "" || discount == undefined) {
        discount = 0;
    }
    if (VAT == "" || VAT == undefined) {
        VAT = 0;
    }
    discount = parseFloat(discount);
    VAT = parseFloat(VAT);
    subTotal = parseFloat(subTotal);

    if (subTotal != null && discount != null && VAT != null) {
        var grandTotal = subTotal + subTotal * (VAT / 100) - discount;
        $("#Total").val(grandTotal);
    }
}