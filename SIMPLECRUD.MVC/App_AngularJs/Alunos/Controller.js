


alunoApp.controller('alunosCtrl', function ($scope, alunosService) {

    carregarAlunos();

    function carregarAlunos() {
        var listarAlunos = alunosService.listarTodosAlunos();

        listarAlunos.then(function (a) {
            $scope.Alunos = a.data;
        },
        function () {
            alert("Ocorreu um erro ao tentar listar todos os alunos");
        });
    }
});