var app = app || {};
(function(scope){
    scope.repository = [
            {
                question: "What protocol is used for REST API?",
                questionId: 1,
                answers: [
                    {id: 1, text: "HTTP"},
                    {id: 2, text: "FTP"},
                    {id: 3, text: "MAPI"},
                    {id: 4, text: "DNS"}
                ],
                correctAnswerId: 1
            },
            {
                question: "What method usually we use to delete a resource?",
                questionId: 2,
                answers: [
                    {id: 1, text: "HEAD"},
                    {id: 2, text: "GET"},
                    {id: 3, text: "PUT"},
                    {id: 4, text: "DELETE"}
                ],
                correctAnswerId: 4
            },
            {
                question: "What header we use to specify the type of data we are sending to REST service?",
                questionId: 3,
                answers: [
                    {id: 1, text: "Accept-Encoding"},
                    {id: 2, text: "Cookie"},
                    {id: 3, text: "Content-type"},
                    {id: 4, text: "User-Agent"}
                ],
                correctAnswerId: 3
            },
            {
                question: "What is the response status code when a resource is missing?",
                questionId: 4,
                answers: [
                    {id: 1, text: "200 OK"},
                    {id: 2, text: "204 No Content"},
                    {id: 3, text: "404 Not Found"},
                    {id: 4, text: "403 Forbidden"}
                ],
                correctAnswerId: 3
            }
        ];

}(app));