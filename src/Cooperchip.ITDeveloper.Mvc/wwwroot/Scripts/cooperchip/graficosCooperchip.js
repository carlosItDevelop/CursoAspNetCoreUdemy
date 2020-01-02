(function () {
    'use strict';
    // Gráfico de Linha: Estado do Paciente
    new Morris.Line({
        // ID of the element in which to draw the chart.
        element: 'graficoLinhaEstadoPaciente',
        data: [
            { ano: '2010', value1: 20, value2: 10, value3: 15, value4: 5 },
            { ano: '2011', value1: 10, value2: 5, value3: 18, value4: 10 },
            { ano: '2012', value1: 5, value2: 5, value3: 15, value4: 5 },
            { ano: '2013', value1: 5, value2: 10, value3: 13, value4: 20 },
            { ano: '2014', value1: 17, value2: 15, value3: 10, value4: 18 },
            { ano: '2015', value1: 11, value2: 18, value3: 15, value4: 12 },
            { ano: '2016', value1: 15, value2: 13, value3: 20, value4: 16 }
        ],
        xkey: 'ano',
        ykeys: ['value1', 'value2', 'value3', 'value4'],
        labels: ['Estável', 'Observação', 'Crítico', 'Sem Avaliação'],
        resize: true,
        lineColors: ['#ED5353', '#2CB4AC', '#185b51', '#872311'],
        lineWidth: 1
    });

})();

(function(){

    // Gráfico de Área: Evolução Alta / Baixa
    new Morris.Area({
        element: 'evolucaoAltaBaixa',
        data: [
            { y: '2010', a: 100, b: 62, c: 72 },
            { y: '2011', a: 79, b: 65, c: 75 },
            { y: '2012', a: 85, b: 40, c: 69 },
            { y: '2013', a: 78, b: 65, c: 73 },
            { y: '2014', a: 90, b: 40, c: 67 },
            { y: '2015', a: 95, b: 65, c: 70 },
            { y: '2016', a: 98, b: 60, c: 76 }
        ],
        xkey: 'y',
        ykeys: ['a', 'b', 'c'],
        labels: ['Evolução Top', 'Evolução Down', 'No Limite'],
        lineColors: ['#ff002e', '#04f253', '#708477'],
        resize: true
    });

})();

(function(){

    // Gráfico de Área: Evolução Alta / Baixa
    new Morris.Donut({
        element: 'graficosAtendidosFaltosos',
        data: [
            { label: "Agendados", value: 12 },
            { label: "Confirmados", value: 30 },
            { label: "Faltosos", value: 5 },
            { label: "Atendidos", value: 20 }
        ],
        resize: true

    });

})();

(function(){

    // Gráfico de Barras: 
    Morris.Bar({
        element: 'graficosInternacaoAlta',
        data: [
            { y: '2010', a: 100, b: 90 },
            { y: '2011', a: 75, b: 65 },
            { y: '2012', a: 50, b: 40 },
            { y: '2013', a: 75, b: 65 },
            { y: '2014', a: 50, b: 40 },
            { y: '2015', a: 75, b: 65 },
            { y: '2016', a: 100, b: 90 }
        ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Internação', 'Alta'],
        resize: true
    });


})();
