// The keypad on the login page: every button adds its digit to the PIN field.
// With four digits the form is sent, so nobody has to press an extra button.
const pinField = document.getElementById("pin");
const loginForm = document.getElementById("loginForm");

document.querySelectorAll("[data-digit]").forEach(function (button) {
    button.addEventListener("click", function () {
        if (pinField.value.length >= 4) {
            return;
        }

        pinField.value += button.dataset.digit;
        if (pinField.value.length === 4) {
            loginForm.submit();
        }
    });
});

document.getElementById("clearPin").addEventListener("click", function () {
    pinField.value = "";
});
