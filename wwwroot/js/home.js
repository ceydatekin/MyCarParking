$('body').on('click', '#parket', function () {
    
    var carplate = $('#carplate').val();

    var formdata = new FormData();
    formdata.append('carplate', carplate);

    $.ajax({
        url: '/API/carpark/addcar',
        method: 'post',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (resp) {
            console.log(resp)
            var data = JSON.parse(resp)
            if (data.success == true) {
                $('#parkgirisi').modal('hide')
                $('.toast').toast('show');
                /*notifyFunc("success", "Kurum Başarıyla Eklendi!");*/
                //'\<div class="alert alert-success" role="alert">\
                //    Success Alert\
                //    </div > \
                //'
                console.log(resp.message);
            }
            else if (data.success == false)
                alert("Sistem Kullanıcı değilsiniz veya otoparkımız doludur")
                console.log("araba park edilirken hata oldu")
        },
        error: function (err) {
            console.log(err)
        }
    });
});


$('body').on('click', '#cikisyap', function () {

    var carplate = $('#carplate').val();

    var formdata = new FormData();
    formdata.append('carplate', carplate);

    $.ajax({
        url: 'API/carpark/deletecar',
        method: 'post',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (resp) {
            console.log(resp)
            var data = JSON.parse(resp)
            if (data.success == true) {
                $('#parkgirisi').modal('hide')
                $('.toast').toast('show');
                /*notifyFunc("success", "Kurum Başarıyla Eklendi!");*/
                //'\<div class="alert alert-success" role="alert">\
                //    Success Alert\
                //    </div > \
                //'
                console.log(resp.message);
            }
            else if (data.success == false)
                console.log("araba park edilirken hata oldu")
        },
        error: function (err) {
            console.log(err)
        }
    });
});

$('body').on('click', '#yeniarac', function () {

    var name = $('#name').val();
    var surname = $('#surname').val();
    var plate = $('#plate').val();

    var formdata = new FormData();
    formdata.append('name', name);
    formdata.append('surname', surname);
    formdata.append('plate', plate);
    $.ajax({
        url: '/API/addcar',
        method: 'post',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (resp) {
            console.log(resp)
            var data = JSON.parse(resp)
            if (data.success == true) {
                $('#parkgirisi').modal('hide')
                $('.toast').toast('show');

                console.log(resp.message);
            }
            else if (data.success == false)
                console.log("HATA!!!")
        },
        error: function (err) {
            console.log(err)
        }
    });
});
$('body').on('click', '#login-submit', function () {

    var username = $('#username').val();
    var password = $('#password').val();

    var formdata = new FormData();

    formdata.append('username', username);
    formdata.append('password', password);


    $.ajax({
        url: '/girisYapPost',
        method: 'post',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (resp) {

            if (resp == true) {
                window.location.href = "/listele"
                console.log("buradayız2");
            }
            else {
                alert("hatalı Giriş")
                window.location.reload(2);
                console.log("buradayız3");


            }
        },
        error: function (err) {
            console.log(err)
        }
    });
});