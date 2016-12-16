app.service('repository', ['$http', function ($http) {
    return {
        add: function (todo) {
            return $http.post("/api/Values/", todo);
        },

        getAll: function () {
            return $http.get("/api/Values/");
        },

        get: function (id) {
            return $http.get("/api/Values/" + id);
        },

        remove: function (id) {
            return $http.delete("/api/Values/" + id);
        },

        update: function (todo) {
            return $http.put("/api/Values/", todo);
        }
    }
}])