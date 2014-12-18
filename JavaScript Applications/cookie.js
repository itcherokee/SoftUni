function getCookie(name) {
    var nameEQ = name + '=';
    var allCookies = document.cookie.split(';');
    for(var i = 0; i < allCookies.length; i += 1) {
        var cookie = allCookies[i];
        while (cookie.charAt(0) == ' ') {
            cookie = cookie.substring(1, cookie.length);
        }
        if (cookie.indexOf(nameEQ) == 0) {
            return cookie.substring(nameEQ.length, cookie.length);
        }
    }
    return null;
}

function setCookie(name, value, expires, path, domain) {
    var cookie = name + '=' + escape(value) + ';';
    if (expires) {
        if(expires instanceof Date) {
            expires = new Date();
        } else {
            expires = new Date(new Date().getTime() +
                parseInt(expires) * 1000 * 60 * 60 * 24);
        }
        cookie += 'expires=' + expires.toGMTString() + ';';
    }
    if (path) { cookie += 'path=' + path + ';'; }
    if (domain) { cookie += 'domain=' + domain + ';'; }
    document.cookie = cookie;
}

function deleteCookie(name) {
    if(getCookie(name)) {
        setCookie(name, '', -1);
    }
}
