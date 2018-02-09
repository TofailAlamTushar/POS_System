/// <reference path="~/Theme/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#ExpenseDate").datepicker({
        autoclose: true
    });

    $("#AddButton").click(function () {

        CreateRowForExpense();
        TotalAmount()
    });
});

function CreateRowForExpense() {
    var SelectedItem = GetSelectedItem();

    var index = $("#ExpenseDetailsTable").children("tr").length;
    var sl = index;

    var indexCell = "<td style='display:none'> <input type='hidden' id='index" + index + "' name='ExpenseDetails.index' value='" + index + "'/> </td>"
    var serialCell = "<td>" + (++sl) + "</td>";

    var itemNameCell = "<td> <input type='hidden' id='ItemName" + index + "' name='ExpenseDetails[" + index + "].ExpenseItemId' value='" + SelectedItem.ItemName + "' />" + SelectedItem.itemText + " </td>";
    var itemQuantityCell = "<td> <input type='hidden' id='ItemQuntity" + index + "' name='ExpenseDetails[" + index + "].Quantity' value='" + SelectedItem.ItemQuantity + "' />" + SelectedItem.ItemQuantity + " </td>";
    var ExpenseDes = "<td> <input type='hidden' id='Description" + index + "' name='ExpenseDetails[" + index + "].Description' value='" + SelectedItem.ExpenseDes + "' />" + SelectedItem.ExpenseDes + " </td>";
    var ExpenseAmountCell = "<td> <input type='hidden' id='Amount" + index + "' name='ExpenseDetails[" + index + "].Amount' value='" + SelectedItem.ExpenseAmount + "' />" + SelectedItem.ExpenseAmount + " </td>";
    var LineTotalCell = "<td class='total'>" + SelectedItem.ItemQuantity * SelectedItem.ExpenseAmount + " </td>";
    var actionCell = "<td>" + "<input type='button' class='btn btn-danger btn-sm' value='Remove' onclick='GetDeleteId(" + index + ")' id='" + index + "'/>" + "</td>";
    var createNewRow = "<tr id='DelRow_" + index + "'> " + indexCell + serialCell + itemNameCell + itemQuantityCell + ExpenseAmountCell + LineTotalCell + actionCell + " </tr>";

    $("#ExpenseDetailsTable").append(createNewRow);
    $("#ItemName").val("");
    $("#ItemQuantity").val("");
    $("#ExpenseDes").val("");
    $("#ExpenseAmount").val("");
}

var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    TotalAmount();

}

function GetSelectedItem() {

    var ItemName = $("#ItemName").val();
    var ItemQuantity = $("#ItemQuantity").val();
    var ExpenseDes = $("#ExpenseDes").val();
    var ExpenseAmount = $("#ExpenseAmount").val();
    var itemText = $("#ItemName option:selected").text();
    var Item = {
        "ItemName": ItemName,
        "ItemQuantity": ItemQuantity,
        "ExpenseDes": ExpenseDes,
        "ExpenseAmount": ExpenseAmount,
        "itemText": itemText
    }
    return Item;
}

function TotalAmount() {
    var sumOfTotal = 0;
    if ($("#ExpenseDetailsTable").children("tr").length == 0) {
        $("#Total").val(0);
    }
    else {
        $("#ExpenseDetailsTable tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".total").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#Total").val(sumOfTotal);
        });
    }
}
