function showLoginForm() {
    
    const loginForm = document.getElementById('content');
    loginForm.style.display = 'block';
    loginForm.innerHTML = `
        <h2>Login</h2>
        <form id="login-form">
            <div class="mb-3">
                <label for="username" class="form-label">Username</label>
                <input type="text" class="form-control" id="email" required>
            </div>
            <div class="mb-3">
                <label for="password" class="form-label">Password</label>
                <input type="password" class="form-control" id="password" required>
            </div>
            <button type="submit" class="btn btn-primary" onclick="formSubmitHandler()">Login</button>
        </form>
    `;

    
}
function formSubmitHandler(e) {
    
    e.peventDefault(); // Prevent form submission and page reload
    const username = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    console.log('Username:', username);
    console.log('Password:', password);
}