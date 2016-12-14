var app = angular.module('webApi', [])
.controller('toDo', ['$scope', 'repository', function ($scope, repository) {
    $scope.todos = [];

    function init() {

    }

    $scope.send = function (todo) {
        var newTodo = {
            author: todo.author,
            title: todo.title,
            description: todo.description,
            creationDate: new Date().toDateString()
        }

        repository.send(newTodo);

        $scope.todos.push(newTodo);

        todo.author = "";
        todo.title = "";
        todo.description = "";
    }
}])