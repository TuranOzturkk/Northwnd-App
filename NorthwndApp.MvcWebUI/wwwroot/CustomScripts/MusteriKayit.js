$(document).ready(function () {
    $("#btnKayit").click(function () {
        var vm =
        {
            Adi: $("#txtAdi").val(),
            Soyadi: $("#txtSoyadi").val(),
            Mail: $("#txtMail").val(),
            Telefon: $("#txtTelefon").val(),
            Sehir: $("#txtSehir").val(),
            Ulke: $("#txtUlke").val(),
            Adres: $("#txtAdres").val(),
            KullaniciAdi: $("#txtKullaniciAdi").val(),
            Parola: $("#txtParola").val()

        };

        var ajaxOptions =
        {
            url: "/MusteriGiris/Add",
            method: "post",
            dataType: "json",
            data: { viewModel: vm },
            success: function (response) {
                if (response.isSuccess) {
                    $("#divMessage").html("<div class='alert alert-success'>" + response.message + "</div>");
                }
            }
        }


       


        $.ajax(ajaxOptions);
    });
});