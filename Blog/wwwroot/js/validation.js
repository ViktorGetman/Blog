function validateRegistrationForm(form, submitHandler) {
    form.validate({
        rules: {
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            Age: {
                required: true,
                digits: true
            },
            Password: {
                required: true,
                minlength: 6
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            Email: {
                required: true,
                email: true
            }
        },
        messages: {
            FirstName: "Пожалуйста, введите ваше имя",
            LastName: "Пожалуйста, введите вашу фамилию",
            Age: {
                required: "Пожалуйста, введите ваш возраст",
                digits: "Введите только цифры"
            },
            Password: {
                required: "Пожалуйста, введите пароль",
                minlength: "Пароль должен содержать минимум 6 символов"
            },
            ConfirmPassword: {
                required: "Пожалуйста, подтвердите пароль",
                equalTo: "Пароли не совпадают"
            },
            Email: {
                required: "Пожалуйста, введите ваш email",
                email: "Введите корректный email"
            }
        },
        errorElement: 'span',
        errorClass: 'error-message text-danger',
        submitHandler: submitHandler
    });
}
function validateCommentForm(form, submitHandler) {
    form.validate({
        rules: {
            Content: {
                required: true
            }
        },
        messages: {
            Content: "Пожалуйста, введите ваш коментарий"
        },
        errorElement: 'span',
        errorClass: 'error-message text-danger',
        submitHandler: submitHandler
    });
}
function validatePostForm(form, submitHandler) {
    form.validate({
        rules: {
            postName: {
                required: true
            },
            postContent: {
                required: true
            }
        },
        messages: {
            postName: "Пожалуйста, введите название поста",
            postContent: "Пожалуйста, введите текст поста"
        },
        errorElement: 'span',
        errorClass: 'error-message text-danger',
        submitHandler: submitHandler
    });
}
function validateUserRoleForm(form, submitHandler) {
    form.validate({
        rules: {
            newRole: {
                checkRoles: true
            }
        },
        messages: {
            newRole: "Пожалуйста, добавьте пользователю хотябы одну роль"
        },
        errorElement: 'span',
        errorClass: 'error-message text-danger',
        submitHandler: submitHandler
    });
    $.validator.addMethod("checkRoles", function (value, element) {
        // Получаем количество тегов
        var tagsCount = $("#rolesList .badge").length;
        return tagsCount > 0;
    });
}
function validateRoleForm(form, submitHandler) {
    form.validate({
        rules: {
            Name: {
                required: true

            },
            Description: {
                required: true

            },
            RoleType: {
                required: true

            }
        },
        messages: {
            Name: "Пожалуйста, укажите название роли",
            Description: "Пожалуйста, добавьте описание роли",
            RoleType: "Пожалуйста, укажите тип роли",
        },
        errorElement: 'span',
        errorClass: 'error-message text-danger',
        submitHandler: submitHandler
    });
}

