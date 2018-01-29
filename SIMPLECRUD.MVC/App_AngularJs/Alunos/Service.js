

//Método responsável por realizar a leitura de todos alunos. READ
alunoApp.service('alunosService', function ($http) {

    this.listarTodosAlunos = function () {
        return $http.get("/Alunos/ListarAlunos");
    }

    //Método responsável por Inserir um Aluno novo: CREATE
    this.inserirAlunoNovo = function (aluno) {
        var request = $http({
            method: 'post',
            url: '/Alunos/InserirAlunoNovo/',
            data: aluno
        });
        return request;
    }
})