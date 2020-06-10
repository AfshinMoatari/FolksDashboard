const chartbackgroundColors = ['#246EB9', '#4CB944', '#294C60', '#F5EE9E', '#F06543', '#2F4B26', '#BEDCFE', '#34252F', '#CC2936']
function GenerateBarChart(expensesM) {
    const barChart = document.getElementById('barchart').getContext('2d');
    const barChartData = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']
    };
    const FolksBar = new Chart(barChart, {
        type: 'bar',
        data: barChartData,
        options: {
            title: {
                display: true,
                text: 'Expenses - Monthly'
            },
            legend: {
                display: true,
                position: "top",
                labels: {
                    fontColor: "#333",
                    fontSize: 16
                }
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

    function BarloadData(dataSets) {
        for (var j = 0; j < Object.keys(dataSets).length; j++) {
            var newDataset = {
                label: Object.keys(dataSets)[j],
                backgroundColor: chartbackgroundColors[j],
                data: []
            }
            barChartData.datasets.push(newDataset);
            for (var i = 0 in Object.values(dataSets)[j][0]) {
                FolksBar.data.datasets[j].data.push(Object.values(dataSets)[j][0][i]);
            }
            FolksBar.update();
        }
    }
    BarloadData(expensesM);
}   

function GenerateDoughnutChart(expensesY) {
    const doughnutChart = document.getElementById('doughnutchart').getContext('2d');

    const FolksDoughnut = new Chart(doughnutChart, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [],
                backgroundColor: chartbackgroundColors,
            }],
        },
        options: {
            title: {
                display: true,
                text: 'Expenses - Yearly'
            },
            legend: {
                display: true,
                position: "top",
                labels: {
                    fontColor: "#333",
                    fontSize: 16
                }
            },
            responsive: true,
        }
    });

    function DoughnutloadData(dataSets) {
        for (var i = 0; i < dataSets.length; i++) {
            FolksDoughnut.data.datasets[0].data.push(dataSets[i].total);
            FolksDoughnut.data.labels.push(dataSets[i].name);
            FolksDoughnut.update();
        }
    }
    DoughnutloadData(expensesY);
}


