

function UserLogin() {
    debugger;
    var username = $('#username').val();
    var pass = $('#password').val();
    $.ajax({
        url: '/Home/Login/',
        type: 'POST',
        datatype: 'json',
        data: { Username: username, password: pass }


    }).done(function (data) {
        if (data == 0) {
            window.location.href = "/Management";
        }
        else if (data == 1) {
            window.location.href = "/User";
        }
        else {
            swal(
                'Username or Passwoord are wrong ',
                     'Pleas try again',
                    'warning'
                )
        }
    });
}

function Error_signup()
{
    swal(
         'Please Enter all filds ',
              'Pleas try again',
             'warning'
         )
}
function Error_Email() {
    swal(
         'You been signed up befor ',
             'Pleas try again',
             'warning'
         )
}
function Error_EmailFormat() {
    swal(
         'Please Enter a valid Email ',
             'Pleas try again',
             'warning'
         )
}

function UsersingUp() {
    debugger;
    var Fname = $('#Fname').val();
    var lname = $('#lname').val();
    var email = $('#email').val();
    var password = $('#password').val();
    var birthday = $('#birthday').val();
    var gender = $('#gender').val();
    var condition = Conditions.checked;
    if (Fname == "" || lname == "" || email == "" || password == "" || birthday == "10/24/1900" || gender == "" || condition == false) {
        Error_signup();
        return;
    }
    $.ajax({
        url: "/Home/signUp",
        type: "Post",
        datatype: "json",
        data: { Fname: Fname, lname: lname, email: email, password: password, birthday: birthday, gender: gender, condition: condition }
    }).done(function (data) {
        if(data==1)
        {
           window.location.href="/User";
        }
        if(data==2)
        {
            Error_Email();
        }
        if (data == 3) {
            Error_EmailFormat();
        }
        if (data == 4) {
            Error_signup();
        }

    });



}