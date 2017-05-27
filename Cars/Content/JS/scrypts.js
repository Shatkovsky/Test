/*JavaScript*/
function SetIMG(selected_url) {
    var item = document.getElementById("Preview");
    item.src = selected_url;
}
/*Практика jQuery*/
$(document).ready(function () {
    $('#header').fadeTo(2000, 0.3, function () {
        $('html, body').animate({ scrollTop: $('#content').offset().top }, 2000);
    });
});

/*Ajax jQuery*/
$(document).on('submit', 'form', function () {

    var UserName = $('input[name=Name]').val();
    var UserTel = $('input[name=Tel]').val();
    var Car = $('select').val();
    //Валидация введенных данных.
    //Проверяем имя
    if (UserName.length > 0) {
        //Проверяем номер телефона
        var regular = /^\8-[0-9]{3}-[0-9]{3}-[0-9]{4}/;
        if (regular.test(UserTel) == true) {
            alert('Phone is OK!');
            SubmitForm(UserName, UserTel, Car);
        }
        else {
            alert("Wrong phone number");
        }
    }
    else {
        alert("You fogot enter your name");
    }
});

/*Ajax jQuery*/
function SubmitForm(name, tel, car) {
    $.ajax({
        method: "POST",
        url: "/Home/Form",
        data: { Name: name, Tel: tel, Car: car }
    })
   .done(function (context) {
       alert(context);
   }).fail(function () {
       alert("Error when sending data");
   });
}

