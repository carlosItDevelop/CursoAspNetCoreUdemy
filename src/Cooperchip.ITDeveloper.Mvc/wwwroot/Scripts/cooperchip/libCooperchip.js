(function () {

    'use strict';
    /*
     * Select2 personalizada por Carlos e Jean da WebSchool
     */


    $("#dropdown").select2({
        theme: "bootstrap"
    });


    $(".busca-ajax-cid").select2({
        ajax: {
            id: function (e) { return e.Codigo; },
            placeholder: "Cid...",
            url: "/Prontuario/GetCid",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                //console.log(params);
                return {
                    q: params
                    //page: params.page
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.Codigo,
                        Diagnostico: item.Diagnostico,
                        Codigo: item.Codigo,
                        CidAdaptadaId: item.CidAdaptadaId
                    };
                });
                //params.page = params.page || 1;
                return {
                    results: results
                    //pagination: {
                    //    more: (params.page * 30) < data.total_count
                    //}
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatCid,
        formatSelection: formatSelectionCid
        //escapeMarkup: function (m) { return m; }
    });
    function formatCid(res) {
        var markup = '<b>[' + res.Codigo + ']</b> : Diagnóstico: <b>' + res.Diagnostico + '</b>';
        return markup;
    };

    function formatSelectionCid(res) {
        var markup = '<b>[' + res.Codigo + ']</b> : Diagnóstico: <b>' + res.Diagnostico + '</b>';
        return markup;
    }


    /*---/ ------------------------------------------------------------------*/




    $(".busca-paciente").select2({
        ajax: {
            id: function (e) { return e.PacienteGuid; },
            placeholder: "Paciente...",
            url: "/Prontuario/getPaciente",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                return {
                    q: params
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.PacienteGuid,
                        nome: item.Nome,
                        email: item.Email
                    };
                });
                return {
                    results: results
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatPaciente,
        formatSelection: formatSelectionPaciente
    });
    function formatPaciente(res) {
        var markup = 'Nome: <b>' + res.nome + '</b> - Email: <b>' + res.email + '</b>';
        return markup;
    };
    function formatSelectionPaciente(res) {
        var markup = 'Nome: <b>' + res.nome + '</b> - Email: <b>' + res.email + '</b>';
        return markup;
    }


    /*---/ ------------------------------------------------------------------*/

    /* ----/ BuscaMedicamentos para Implementação de AtbEmUso e AtbJaUtilizado ---- */


    $(".busca-ajax-medicamentos").select2({
        ajax: {
            id: function (e) { return e.Descricao; },
            placeholder: "Medicamentos...",
            url: "/Prontuario/GetMedicamentosSelect2",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                return {
                    q: params
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.Descricao
                    };
                });
                return {
                    results: results
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatMedicamento,
        formatSelection: formatSelectionMedicamento
    });
    function formatMedicamento(res) {
        var markup = '<b>' + res.id + '</b>';
        return markup;
    };
    function formatSelectionMedicamento(res) {
        var markup = '<b>' + res.id + '</b>';
        return markup;
    }
    /* ----/ FIM: BuscaMedicamentos para Implementação de AtbEmUso e AtbJaUtilizado ---- */



    /* ----/ BuscaMedicamentos para Implementação de ApresentacaoInteracaomedicamentosa ---- */

    $(".busca-ajax-apresentacao-ajuste").select2({
        ajax: {
            id: function (e) { return e.MedicamentoId; },
            placeholder: "Medicamentos...",
            url: "/Prontuario/GetMedicamentosSelect2",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                return {
                    q: params
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.MedicamentoId,
                        descricao: item.Descricao,
                        generico: item.Generico,
                        idgenerico: item.idGenerico
                    }
                });
                return {
                    results: results
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatAjuste,
        formatSelection: formatSelectionAjuste
    });
    function formatAjuste(res) {
        var markup = '<b>' + res.descricao + ' *** (Genérico: ' + res.generico + ')</b>';
        return markup;
    };
    function formatSelectionAjuste(res) {
        var markup = '<b>' + res.descricao + ' *** (Genérico: ' + res.generico + ')</b>';
        return markup;
    }

    /* ----/ FIM: BuscaMedicamentos para Implementação de ApresentacaoInteracaomedicamentosa ---- */


    //busca-ajax-interacao-generico
    /* ----/ BuscaMedicamentos para Implementação de InteracaoMedicamentosa CRUD ---------- */
    $(".busca-ajax-interacao-generico").select2({
        ajax: {
            id: function (e) { return e.GenericoId; },
            placeholder: "Medicamentos...",
            url: "/Prontuario/GetDescricaoParaGenericos",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                return {
                    q: params
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.GenericoId,
                        descricao: item.Descricao
                    };
                });
                return {
                    results: results
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatGenerico,
        formatSelection: formatSelectionGenerico
    });
    function formatGenerico(res) {
        var markup = '<b> Genérico: ' + res.descricao + '</b>';
        return markup;
    };
    function formatSelectionGenerico(res) {
        var markup = '<b> Genérico: ' + res.descricao + '</b>';
        return markup;
    }
    /* ----/ FIM: BuscaMedicamentos para Implementação de InteracaoMedicamentosa CRUD ---- */



    // ----/ GetMedicamentosAjusteInteracao ---------------------------------------------- //
    $(".busca-ajax-apresentacao-interacao").select2({
        ajax: {
            id: function (e) { return e.MedicamentoId; },
            placeholder: "Medicamentos...",
            url: "/Prontuario/GetMedicamentosAjusteInteracao",
            contentType: "application/json",
            dataType: 'json',
            type: 'GET',
            delay: 250,
            language: 'pt-BR',
            allowClear: true,
            data: function (params) {
                return {
                    q: params
                };
            },
            results: function (data, params) {
                var results = $.map(data.items, function (item) {
                    return {
                        id: item.MedicamentoId,
                        descricao: item.Descricao,
                        generico: item.Generico,
                        idgenerico: item.idGenerico
                    };
                });
                return {
                    results: results
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; },
        minimumInputLength: 3,
        formatResult: formatInteracao,
        formatSelection: formatSelectionInteracao
    });
    function formatInteracao(res) {
        var markup = '<b>' + res.descricao + ' *** (Genérico: ' + res.generico + ')</b>';
        return markup;
    };
    function formatSelectionInteracao(res) {
        var markup = '<b>' + res.descricao + ' *** (Genérico: ' + res.generico + ')</b>';
        return markup;
    }
    // ----/ FIM: GetMedicamentosAjusteInteracao ----------------------- //



    // --- Manipulando elementos --------------------------------------- //
    function getVal(nome) {
        return $("input[name='" + nome + "']").val();
    }


    function getValOpt(radioname) {
        var valor = "";
        $("input:radio[name='" + radioname + "']").each(function () {
            if ($(this).is(':checked')) valor = $(this).val();
        });
        return valor;
    }


    function getValSplit(nome) {
        var valor = $("input[name='" + nome + "']").val();
        console.log(valor.split(",", 10));
        return valor.split(",", 10);
    }




    function getChkMultiple(classe) {
        var arr = $("." + classe + ":checked").map(function () {
            return this.value;
        }).get();
        //console.log(arr);
        return arr;
    }


    // --- Manipulando Datas ------------------------------------- //

    // Converte uma data no formato json para date
    function ConverterDataJsonParaData(jsonDate) {
        var dataFormatada = new Date(parseInt(jsonDate.substr(6)));
        return ((dataFormatada.getDate() < 10) ? "0" : "")
            + dataFormatada.getDate() + "/" + (((dataFormatada.getMonth() + 1) < 10) ? "0" : "")
            + (dataFormatada.getMonth() + 1) + "/" + dataFormatada.getFullYear();
    }

    // Converte um data no formato json para hora
    function ConverterDataJsonParaHora(jsonDate) {
        var dataFormatada = new Date(parseInt(jsonDate.substr(6)));
        return ((dataFormatada.getHours() < 10) ? "0" : "") + dataFormatada.getHours() + ":"
            + ((dataFormatada.getMinutes() < 10) ? "0" : "") + dataFormatada.getMinutes();
    }

    // Calcula apenas o ano;
    function CalculaIdade(strdata) {
        var mydate = new Date();
        var year = mydate.getYear();
        if (year < 1000) year += 1900;
        return year - strdata.substr(6, 9);
    }

    // ----- ValidaDat -------------------------------------------- //
    function validaDat(nomeCampo, valor) {
        var date = valor;
        var ardt = new Array;
        var expReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
        ardt = date.split("/");
        var erro = false;
        if (date.search(expReg) === -1) {
            erro = true;
        }
        else if (((ardt[1] === 4) || (ardt[1] === 6) || (ardt[1] === 9) || (ardt[1] === 11)) && (ardt[0] > 30))
            erro = true;
        else if (ardt[1] === 2) {
            if ((ardt[0] > 28) && ((ardt[2] % 4) !== 0))
                erro = true;
            if ((ardt[0] > 29) && ((ardt[2] % 4) === 0))
                erro = true;
        }
        if (erro) {
            alert("Data Inválida para : " + nomeCampo);
            //alert("'" + valor + "' não é uma data válida!!!");
            //campo.focus();
            //campo.value = "";
            return false;
        }
        return true;
    }

})();




