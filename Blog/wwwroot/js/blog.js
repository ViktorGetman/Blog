﻿

function deleteUser(userId) {
    var result = confirm("Вы уверены, что хотите удалить пользователя?");

    if (result) {
        // Пользователь нажал "Да", отправляем запрос к API и обновляем страницу
        $.ajax({
            type: 'DELETE',
            CORS: true,
            url: '/api/user/'.concat(userId),  // Укажите правильный URL для вашего API
            success: function (data) {
                window.location.href = '/User/Authorization/';
            },
            error: function (error) {
                console.error('Ошибка', error);
            }
        });
    }
}


function deletePost(postId) {
    var result = confirm("Вы уверены, что хотите удалить этот пост?");

    if (result) {
        // Пользователь нажал "Да", отправляем запрос к API и обновляем страницу
        $.ajax({
            type: 'DELETE',
            CORS: true,
            url: '/api/post/'.concat(postId),  // Укажите правильный URL для вашего API
            success: function (data) {
                window.location.reload();
            },
            error: function (error) {
                console.error('Ошибка', error);
            }
        });
    }
}


function deleteComment(commentId) {
    var result = confirm("Вы уверены, что хотите удалить этот комментарий?");

    if (result) {
        // Пользователь нажал "Да", отправляем запрос к API и обновляем страницу
        $.ajax({
            type: 'DELETE',
            CORS: true,
            url: '/api/comment/'.concat(commentId),  // Укажите правильный URL для вашего API
            success: function (data) {
                window.location.reload();
            },
            error: function (error) {
                console.error('Ошибка', error);
            }
        });
    }
}


    $('#logoutButton').click(function () {
        $.ajax({
            type: 'POST',
            url: '/api/logout', // Укажите правильный URL для вашего API
            success: function () {
                // Перенаправление на страницу авторизации после успешного выхода
                window.location.href = '/user/authorization'; // Укажите правильный URL для страницы авторизации
            },
            error: function (error) {
                console.error('Ошибка выхода', error);
            }
        });
        });


    $(document).ready(function () {
        $('#authorizationForm').submit(function (event) {
            event.preventDefault();

            var formData = {
                Email: $('#Email').val(),
                Password: $('#Password').val(),

            };

            $.ajax({
                type: 'POST',
                CORS: true,
                url: '/api/login',  // Укажите правильный URL для вашего API
                contentType: 'application/json',
                data: JSON.stringify(formData),
                success: function (data) {
                    console.log('Успех', data);
                    window.location.href = '/home';
                },
                error: function (error) {
                    console.error('Ошибка', error);
                }
            });
        });
    });