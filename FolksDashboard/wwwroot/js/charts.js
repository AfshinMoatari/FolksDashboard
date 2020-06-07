function GenerateBarChart(expenses) {
    let barColors = ['246EB9', '4CB944', '294C60', 'F5EE9E', 'F06543', '2F4B26', 'BEDCFE', '34252F', 'CC2936']
    const ctx = document.getElementById('barchart').getContext('2d');
    const barChartData = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']
    };
    const myBar = new Chart(ctx, {
        type: 'bar',
        data: barChartData,
        options: {
            title: {
                display: true,
                text: 'Expenses - Monthly'
            },
            tooltips: {
                mode: 'index',
                intersect: false
            },
            responsive: true,
            scales: {
                xAxes: [{
                    stacked: true,
                }],
                yAxes: [{
                    stacked: true
                }]
            }
        }
    });

    function loadChart(dataSets) {
        for (var j = 0; j < Object.keys(dataSets).length; j++) {
            var newDataset = {
                label: Object.keys(dataSets)[j],
                backgroundColor: '#' + barColors[j],
                data: []
            }
            barChartData.datasets.push(newDataset);
            myBar.update();
        }
        myBar.data.datasets.forEach(function (dataset, j) {
            for (var i = 0 in Object.values(dataSets)[j][0]) {
                myBar.data.datasets[j].data.push(Object.values(dataSets)[j][0][i]);
            }
            myBar.update();
        });
    }
    loadChart(expenses);
}