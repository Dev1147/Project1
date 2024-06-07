
function getDataAndDrawChart() {
    fetch("/Index?handler=DefectRatesData", { //서버 메서드이름은 OnGetDefectRatesDataAsync 이지만 닷네코어에서 DefectRatesData가 맞다 안그럼JOSN이 HTML로 받아오는 에러 발생!
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
            return response.text();  // 먼저 텍스트로 응답을 받아서 출력합니다.
        })
        .then(text => {
            //console.log("Response text:", text);

            // JSON으로 변환 시도
            try {
                const data = JSON.parse(text);
               // console.log("Data received:", data);
                //alert(JSON.stringify(data));
                console.log("한글이 포함된 자바스크립트 파일입니다.");
                //var rates = data.map(item => item.rate);
                //var rates2 = data.map(item => item.dateRecorded); //대소문자 구분함!
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





// 페이지가 로드될 때 데이터를 가져와 차트를 그리도록 설정
document.addEventListener('DOMContentLoaded', getDataAndDrawChart);
//document.addEventListener('DOMContentLoaded', getDataAndDrawChart2);


//function drawDefectRateChart(data) {
//    // 월별 데이터를 저장할 배열
//    var months = [];
//    var defectRates = [];

//    // 데이터를 반복하여 월별 배열에 추가
//    data.forEach(function (item) {
//        // dateRecorded에서 월을 추출
//        var date = new Date(item.dateRecorded);
//        var month = date.getMonth() + 1; // getMonth()는 0부터 시작하므로 1을 더해줍니다.
//        months.push(month + "월"); // 라벨은 월을 나타냄
//        defectRates.push(item.rate); // 값은 불량률을 나타냄
//    });

//    // 그래프 생성
//    var ctx = document.getElementById('defectRateBarChart').getContext('2d');
//    var myChart = new Chart(ctx, {
//        type: 'bar',
//        data: {
//            labels: months,
//            datasets: [{
//                label: '부적합율',
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

    // 데이터를 반복하여 월별 배열에 추가
    data.forEach(function (item) {
        // dateRecorded에서 월을 추출
        var date = new Date(item.dateRecorded);
        var month = date.getMonth() + 1; // getMonth()는 0부터 시작하므로 1을 더해줍니다.
        months.push(month + "월"); // 라벨은 월을 나타냄
        defectRates.push(item.rate); // 값은 불량률을 나타냄
    });

    var ctx = document.getElementById("defectRateBarChart");
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: months,
            datasets: [{
                label: '부적합율',
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