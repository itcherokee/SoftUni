(function () {
    $(function () {
        var PARSE_APP_ID = "7o3oacwrwSthfqaolXW6QkHimHUBQoL0Vlc2kiA4";
        var PARSE_REST_API_KEY = "k7HiHcAIZjtdjg2wMUPaBGKZMuymjHLi3Jqi7zDw";

        var output = $('#countries');

        function getCountries() {
            $.ajax({

            })
        }
    })
}());

$.ajax({
    accepts: "",    // The content type sent in the request header that tells the server
    // what kind of response it will accept in return
    async: true,    // By default, all requests are sent asynchronously (i.e. this is set to true by default).
    // If you need synchronous requests, set this option to false.
    beforeSend: function () {
    },   // A pre-request callback function that can be used to modify the jqXHR object
    // before it is sent. Use this to set custom headers, etc.
    cache: true,    // If set to false, it will force requested pages not to be cached by the browser.
    // Note: Setting cache to false will only work correctly with HEAD and GET requests.
    // It works by appending "_={timestamp}" to the GET parameters
    complete: function () {
    }, // A function to be called when the request finishes (after success and error
    // callbacks are executed). The function gets passed two arguments:
    // The jqXHR (in jQuery 1.4.x, XMLHTTPRequest) object and a string categorizing
    // the status of the request ("success", "notmodified", "error", "timeout",
    // "abort", or "parsererror").
    contents: "", // An object of string/regular-expression pairs that determine how jQuery will parse the response,
    // given its content type.
    contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // When sending data to the server, use this
    // content type. Default is "application/x-www-form-urlencoded; charset=UTF-8", which is fine for most cases.
    // If you explicitly pass in a content-type to $.ajax(), then it is always sent to the server (even if no data is sent).
    context: '', //This object will be made the context of all Ajax-related callbacks. By default, the context
    // is an object that represents the ajax settings used in the call ($.ajaxSettings merged with
    // the settings passed to $.ajax).
    converters:  {"* text": window.String, "text html": true, "text json": jQuery.parseJSON, "text xml": jQuery.parseXML},
    // An object containing dataType-to-dataType converters. Each converter's value is a function that returns
    // the transformed value of the response.
    data: '', // Type: PlainObject or String or Array. Data to be sent to the server. It is converted to a query string,
    // if not already a string. It's appended to the url for GET-requests. See processData option to prevent this
    // automatic processing. Object must be Key/Value pairs. If value is an Array, jQuery serializes multiple values
    // with same key based on the value of the traditional setting
    dataFilter : function(){}, // Type: Function( String data, String type ) => Anything. A function to be used to handle
    // the raw response data of XMLHttpRequest. This is a pre-filtering function to sanitize the response.
    // You should return the sanitized data. The function accepts two arguments: The raw data returned from
    // the server and the 'dataType' parameter.
    dataType : '', // (default: Intelligent Guess (xml, json, script, or html)). Type: String.
    // The type of data that you're expecting back from the server. If none is specified, jQuery will try to infer it
    // based on the MIME type of the response (an XML MIME type will yield XML, in 1.4 JSON will yield a JavaScript
    // object, in 1.4 script will execute the script, and anything else will be returned as a string). The available
    // types (and the result passed as the first argument to your success callback)
    error : function(){}, // Type: Function( jqXHR jqXHR, String textStatus, String errorThrown ).
    // A function to be called if the request fails. The function receives three arguments: The jqXHR object,
    // a string describing the type of error that occurred and an optional exception object, if one occurred.
    // Possible values for the second argument (besides null) are "timeout", "error", "abort", and "parsererror".
    // When an HTTP error occurs, errorThrown receives the textual portion of the HTTP status, such as "Not Found"
    // or "Internal Server Error." As of jQuery 1.5, the error setting can accept an array of functions. Each function
    // will be called in turn. Note: This handler is not called for cross-domain script and cross-domain JSONP requests.
    // This is an Ajax Event.
    global: true, // Whether to trigger global Ajax event handlers for this request. The default is true.
    // Set to false to prevent the global handlers like ajaxStart or ajaxStop from being triggered.
    // This can be used to control various Ajax Events.
    headers:{}, // An object of additional header key/value pairs to send along with requests using the XMLHttpRequest
    // transport. The header X-Requested-With: XMLHttpRequest is always added, but its default XMLHttpRequest value
    // can be changed here. Values in the headers setting can also be overwritten from within the beforeSend function.
    ifModified: false, // Allow the request to be successful only if the response has changed since the last request.
    // This is done by checking the Last-Modified header. Default value is false, ignoring the header.
    isLocal : false, // (default: depends on current location protocol). Allow the current environment to be recognized
    // as "local," (e.g. the filesystem), even if jQuery does not recognize it as such by default. The following
    // protocols are currently recognized as local: file, *-extension, and widget. If the isLocal setting needs
    // modification, it is recommended to do so once in the $.ajaxSetup() method.
    mimeType: '', // A mime type to override the XHR mime type.
    password: '', // A password to be used with XMLHttpRequest in response to an HTTP access authentication request.
    processData: true, // By default, data passed in to the data option as an object (technically, anything other
    // than a string) will be processed and transformed into a query string, fitting to the default content-type
    // "application/x-www-form-urlencoded". If you want to send a DOMDocument, or other non-processed data,
    // set this option to false.
    statusCode :{}, // An object of numeric HTTP codes and functions to be called when the response has
    // the corresponding code. If the request is successful, the status code functions take the same parameters
    // as the success callback; if it results in an error (including 3xx redirect), they take the same parameters
    // as the error callback.
    success: function(){}, // Type: Function( Anything data, String textStatus, jqXHR jqXHR ).
    // A function to be called if the request succeeds. The function gets passed three arguments: The data returned
    // from the server, formatted according to the dataType parameter or the dataFilter callback function, if specified;
    // a string describing the status; and the jqXHR (in jQuery 1.4.x, XMLHttpRequest) object. Success setting can
    // accept an array of functions. Each function will be called in turn. This is an Ajax Event.
    timeout: 5000, // Set a timeout (in milliseconds) for the request. This will override any global timeout set
    // with $.ajaxSetup(). The timeout period starts at the point the $.ajax call is made; if several other requests
    // are in progress and the browser has no connections available, it is possible for a request to time out before
    // it can be sent. In jQuery 1.4.x and below, the XMLHttpRequest object will be in an invalid state if the request
    // times out; accessing any object members may throw an exception.
    traditional: false, // Set this to true if you wish to use the traditional style of param serialization.
    type : 'GET', // The type of request to make ("POST" or "GET"), default is "GET". Note: Other HTTP request methods,
    // such as PUT and DELETE, can also be used here, but they are not supported by all browsers.
    url : '', // (default: The current page). A string containing the URL to which the request is sent.
    username : '' // A username to be used with XMLHttpRequest in response to an HTTP access authentication request.
});



























