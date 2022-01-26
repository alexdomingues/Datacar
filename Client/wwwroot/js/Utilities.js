function initializeInactivityTimer(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 5000);
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout"); 
    }

}