
function getDataAndDrawChart() {
    fetch("/Index?handler=DefectRatesData", { //���� �޼����̸��� OnGetDefectRatesDataAsync ������ ����ھ�� DefectRatesData�� �´� �ȱ׷�JOSN�� HTML�� �޾ƿ��� ���� �߻�!
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    })
        .then(response => {
            //console.log("Response status:", response.status);
            //console.log("Response headers:", response.headers);

            if (!response.ok) {
                throw new Error(`Network response was not ok. Status: ${response.status}`);
            }
            return response.text();  // ���� �ؽ�Ʈ�� ������ �޾Ƽ� ����մϴ�.
        })
        .then(text => {
            //console.log("Response text:", text);

            // JSON���� ��ȯ �õ�
            try {
                const data = JSON.parse(text);
               // console.log("Data received:", data);
                //alert(JSON.stringify(data));
                console.log("�ѱ��� ���Ե� �ڹٽ�ũ��Ʈ �����Դϴ�.");
                //var rates = data.map(item => item.rate);
                //var rates2 = data.map(item => item.dateRecorded); //��ҹ��� ������!
                //alert(JSON.stringify(rates));
                //alert(JSON.stringify(rates2));

                drawDefectRateChart(data);
            } catch (error) {
                console.error("Failed to parse JSON:", error);
            }
        })
        .catch(error => {
            console.error("There was a problem with the fetch operation:", error);
            console.error("Status:", error.status);
            console.error("Message:", error.message);
        });
}

//function getDataAndDrawChart2() {
//    $.ajax({
//        url: "/Index?handler=DefectRatesData",
//        type: "GET",
//        contentType: "application/json; charset=utf-8", 
//        dataType: "json",
//        headers: {
//            Accept: 'application/json',
//        },
//        success: function (data) {
//            console.log("Data received:", data);
//            //alert(JSON.stringify(data));
//            drawDefectRateChart(data);
//        },
//        error: function (xhr, status, error) {
//            console.error("AJAX request failed:", xhr);
//            console.error("Status:", status);
//            console.error("Error:", error);
//            console.error(xhr.responseText);
//        }
//    });
//}





// �������� �ε�� �� �����͸� ������ ��Ʈ�� �׸����� ����
document.addEventListener('DOMContentLoaded', getDataAndDrawChart);
//document.addEventListener('DOMContentLoaded', getDataAndDrawChart2);


//function drawDefectRateChart(data) {
//    // ���� �����͸� ������ �迭
//    var months = [];
//    var defectRates = [];

//    // �����͸� �ݺ��Ͽ� ���� �迭�� �߰�
//    data.forEach(function (item) {
//        // dateRecorded���� ���� ����
//        var date = new Date(item.dateRecorded);
//        var month = date.getMonth() + 1; // getMonth()�� 0���� �����ϹǷ� 1�� �����ݴϴ�.
//        months.push(month + "��"); // ���� ���� ��Ÿ��
//        defectRates.push(item.rate); // ���� �ҷ����� ��Ÿ��
//    });

//    // �׷��� ����
//    var ctx = document.getElementById('defectRateBarChart').getContext('2d');
//    var myChart = new Chart(ctx, {
//        type: 'bar',
//        data: {
//            labels: months,
//            datasets: [{
//                label: '��������',
//                data: defectRates,
//                backgroundColor: 'rgba(255, 99, 132, 0.2)',
//                borderColor: 'rgba(255, 99, 132, 1)',
//                borderWidth: 1
//            }]
//        },
//        options: {
//            scales: {
//                y: {
//                    beginAtZero: true
//                }
//            }
//        }
//    });
//}
function drawDefectRateChart(data) {
    var months = [];
    var defectRates = [];

    // �����͸� �ݺ��Ͽ� ���� �迭�� �߰�
    data.forEach(function (item) {
        // dateRecorded���� ���� ����
        var date = new Date(item.dateRecorded);
        var month = date.getMonth() + 1; // getMonth()�� 0���� �����ϹǷ� 1�� �����ݴϴ�.
        months.push(month + "��"); // ���� ���� ��Ÿ��
        defectRates.push(item.rate); // ���� �ҷ����� ��Ÿ��
    });

    var ctx = document.getElementById("defectRateBarChart");
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: months,
            datasets: [{
                label: '��������',
                data: defectRates,
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                xAxes: [{
                    time: {
                        unit: 'month'
                    },
                    gridLines: {
                        display: false
                    },
                    ticks: {
                        maxTicksLimit: 12
                    }
                }],
                //yAxes: [{
                //    ticks: {
                //        min: 0,
                //        max: 15000,
                //        maxTicksLimit: 5
                //    },
                //    gridLines: {
                //        display: true
                //    }
                //}],
            },
            legend: {
                display: false
            }
        }
    });
}