﻿var app = angular.module('webApi', [])
.controller('toDo', ['$scope', 'repository', function ($scope, repository) {
    $scope.todos = [];
    $scope.updateShow = false;

    function ToDo(todo) {
        this.id = todo.Id,
        this.author = todo.Author,
        this.title = todo.Title,
        this.description = todo.Description,
        this.creationDate = todo.CreationDate
    }

    function clear(todo) {
        todo.author = "";
        todo.title = "";
        todo.description = "";
    }

    $scope.add = function (todo) {
        //var newTodo = {
        //    id: todo.id,
        //    author: todo.author,
        //    title: todo.title,
        //    description: todo.description
        //};
        repository.add(todo).success(function () {
            clear(todo);
        });
        $scope.updateShow = false;
    }

    $scope.getAll = function () {
        repository.getAll().success(function (response) {
            $scope.todos = [];
            var a = Array.of(response);
            response.forEach(function (element, index, array) {
                $scope.todos.push(new ToDo(element));
            })
        });
    }

    $scope.get = function (id) {
        $scope.todos = [];
        repository.get(id).success(function (response) {
            $scope.todos.push(new ToDo(response));
            $scope.todo = new ToDo(response);
            $scope.updateShow = true;
        })
        $scope.id = "";
    }

    $scope.remove = function (index, id) {
        if (confirm('Are you sure?'))
        {
            repository.remove(id).then(function () {
                $scope.todos.splice(index, 1);
                $scope.updateShow = false;
            }, function () {
                alert("Not Found!");
            });
        }        
    }

    $scope.update = function (todo) {
        repository.update(todo).success(function () {
            clear(todo);
        });
        $scope.updateShow = false;
    }
}])