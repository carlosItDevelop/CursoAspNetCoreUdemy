$(document).ready(function () {
    $("#btnBusca").click(function () {
        //$("#termoBusca").onchange(function () {
        var termobusca = $("#termoBusca").val();
        $.ajax({
            method: "GET",
            url: "/Pam/Filtrar?pesquisa=" + termobusca,
            success: function (data) {
                $("#tbl tbody > tr").remove();
                $.each(data, function (i, pam) {
                    $("#tbl tbody").append(
                        "<tr>" +
                        "   <td>" + pam.Descricao + "</td>" +
                        "   <td colspan='3' style='text-align: center'>" +
                        "       <a href='/Pam/Edit/" + pam.PamId + "' class='btn btn-default'>Editar</a>" +
                        "       <a href='/Pam/Details/" + pam.PamId + "' class='btn btn-success'>Detalhes</a>" +
                        "       <a href='/Pam/Delete/" + pam.PamId + "' class='btn btn-danger'>Excluir</a>" +
                        "   </td>" +
                        "</tr>"
                     );
                });
            },
            error: function (data) {
                alert("Houve erro na pesquisa!");
            }
        });
    });
});