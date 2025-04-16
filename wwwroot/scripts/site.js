// Function to get the user's location
window.getLocation = function () {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve({
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    });
                },
                (error) => {
                    reject(error.message);
                }
            );
        } else {
            reject("Geolocation is not supported by this browser.");
        }
    });
};

// Function to apply the theme based on the user's preference
window.applyTheme = function (themeClass) {
    document.body.className = themeClass;
    localStorage.setItem("theme", themeClass); // Save theme preference
};

// Function to load the theme from localStorage on page load
window.loadTheme = function () {
    let savedTheme = localStorage.getItem("theme");
    if (savedTheme) {
        document.body.className = savedTheme;
    }
};
