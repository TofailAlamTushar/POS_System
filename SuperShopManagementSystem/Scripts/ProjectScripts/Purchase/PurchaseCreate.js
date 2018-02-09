/// <reference path="~/Theme/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#PurchaseDate").datepicker({
        autoclose: true
    });

    $("#AddButton").click(function () {

        CreateRowForPurchase();
        TotalAmount()
    });
});

function CreateRowForPurchase() {
    var SelectedItem = GetSelectedItem();

    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    var indexCell = "<td style='display:none'> <input type='hidden' id='index" + index + "' name='PurchaseDetail.index' value='" + index + "'/> </td>"
    var serialCell = "<td>" + (++sl) + "</td>";

    var itemNameCell = "<td> <input type='hidden' id='ItemName" + index + "' name='PurchaseDetail[" + index + "].ItemId' value='" + SelectedItem.ItemName + "' />" + SelectedItem.itemText + " </td>";
    var itemQuantityCell = "<td> <input type='hidden' id='ItemQuntity" + index + "' name='PurchaseDetail[" + index + "].Quntity' value='" + SelectedItem.ItemQuntity + "' />" + SelectedItem.ItemQuntity + " </td>";
    var itemPriceCell = "<td> <input type='hidden' id='ItemPrice" + index + "' name='PurchaseDetail[" + index + "].Price' value='" + SelectedItem.ItemPrice + "' />" + SelectedItem.ItemPrice + " </td>";
    var LineTotalCell = "<td class='total'>" + SelectedItem.ItemQuntity * SelectedItem.ItemPrice + " </td>";
    var actionCell = "<td>" + "<input type='button' class='btn btn-danger btn-sm' value='Remove' onclick='GetDeleteId(" + index + ")' id='" + index + "'/>" + "</td>";
    var createNewRow = "<tr id='DelRow_" + index + "'> " + indexCell + serialCell + itemNameCell + itemQuantityCell + itemPriceCell + LineTotalCell + actionCell+" </tr>";

    $("#PurchaseDetailsTable").append(createNewRow);
    $("#ItemName").val("");
    $("#ItemQuntity").val("");
    $("#ItemPrice").val("");
    
}

var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    TotalAmount();

}

function GetSelectedItem() {

    var ItemName = $("#ItemName").val();
    var ItemQuntity = $("#ItemQuntity").val();
    var ItemPrice = $("#ItemPrice").val();
    var itemText = $("#ItemName option:selected").text();
    var Item = {
        "ItemName": ItemName,
        "ItemQuntity": ItemQuntity,
        "ItemPrice": ItemPrice,
        "itemText": itemText
    }
    return Item;
}

function TotalAmount() {
    var sumOfTotal = 0;
    if ($("#PurchaseDetailsTable").children("tr").length == 0) {
        $("#Total").val(0);
    }
    else {
        $("#PurchaseDetailsTable tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".total").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#Total").val(sumOfTotal);
        });
    }
}
