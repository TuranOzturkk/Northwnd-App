$(document).ready(function () {
    $("#btnSave").click(function () {
        var vm =
        {
            CategoryId: $("#ddlCategories").val(),
            SupplierId: $("#ddlSuppliers").val(),
            ProductName: $("#txtProductName").val(),
            UnitPrice: $("#txtUnitPrice").val(),
            UnitsInStock: $("#txtUnitsInStock").val()
        };

        var ajaxOptions =
        {
            url: "/Product/Add",
            method: "post",
            dataType: "json",
            data: { viewModel: vm },
            success: function (response) {
                if (response.isSuccess) {
                    //$("#divMessage").html("<div class='alert alert-success'>" + response.message + "</div>");
                    Swal.fire({
                        icon: 'success',
                        title: 'İşlem Başarılı',
                        text: response.message
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = "/Home/Index";
                        }
                    })
                }
            }
        }


        $.ajax(ajaxOptions);
    });
});