$.ajaxPrefilter(function(options, originalOptions, jqXHR) {
    var token = localStorage.getItem("token");
    if (token) {
        jqXHR.setRequestHeader('Authorization', 'Bearer ' + token);
    }
});

function login(email, password){
    var dto = {
        Email: email,
        Password: password,

    };
    $.ajax({
        type: 'POST',
        CORS: true,
        url: '/api/login',
        contentType: 'application/json',
        data: JSON.stringify(dto),
        success: function (data) {
            localStorage.setItem("token", data);
            var expires = "expires=Fri, 31 Dec 9999 23:59:59 GMT";
            document.cookie = "token=" + data + ";" + expires + ";path=/";
            console.log('Успех', data);
            window.location.href = '/home';
        },
        error: function (error) {
            console.error('Ошибка', error);
        }
    });
}
function logout() {
    localStorage.removeItem("token");
    document.cookie = "token=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.href = '/user/authorization';
}