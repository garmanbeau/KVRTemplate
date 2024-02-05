// validation.js

function validateForm() {
    // Client-side validation
    var emailInput = document.getElementById('email');
    var passwordInput = document.getElementById('password');

    if (!isValidEmail(emailInput.value)) {
        alert('Invalid email address');
        return false;
    }

    if (!isValidPassword(passwordInput.value)) {
        alert('Invalid password');
        return false;
    }

    // Server-side validation (you may replace this with an AJAX call to your server)
    var formData = {
        email: emailInput.value,
        password: passwordInput.value
    };

    // Example: Simulate server-side validation using a function
    if (!serverSideValidation(formData)) {
        alert('Server-side validation failed');
        return false;
    }

    return true; // Submit the form if all validation passes
}

function isValidEmail(email) {
    // Implement email validation logic
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function isValidPassword(password) {
    // Implement password validation logic
    // Example: Password must be at least 8 characters
    return password.length >= 8;
}

function serverSideValidation(formData) {
    // Implement server-side validation logic
    // Example: Check if the email and password combination is valid
    // Replace this with actual server-side validation logic
    return formData.email === 'example@email.com' && formData.password === 'securepassword';
}// JavaScript source code
