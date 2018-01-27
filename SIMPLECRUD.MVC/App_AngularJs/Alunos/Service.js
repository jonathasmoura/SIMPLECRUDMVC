
var alunoApp;

alunoApp.service('alunosService', function ($http) {

    this.listarTodosAlunos = function () {
        return $http.get("/Alunos/ListarAlunos");
    }
})