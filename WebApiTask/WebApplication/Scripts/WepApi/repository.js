app.service('repository', ['$http', function ($http) {
    return {
        send: function (todo) {
            $http.post("api/Values", todo);
        }
    }
}])