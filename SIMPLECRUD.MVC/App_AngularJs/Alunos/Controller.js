


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

    //Método resposável por adicionar um novo Aluno
    $scope.inserirAlunoNovo = function () {

        var aluno = {
            alunoId: $scope.alunoId,
            nome: $scope.nome,
            cursoId: $scope.cursoId,
            curso: $scope.curso
        };
        var adicionarInfos = alunosService.inserirAlunoNovo(aluno);

        adicionarInfos.then(function (a) {
            if (a.data.success === true) {
                carregarAlunos();
                alert("Aluno inserido com Successo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                $scope.limparCampos();
            }
            else {
                alert("Não foi possível realizar a inserção do Aluno!");
            }
        },
        function () {
            alert("ERRO.\nErro ocorrido ao tentar adicionar um novo Aluno.");
        });
    }

    //Limpar os campos após inserir os dados.
    $scope.limparCampos = function () {
        $scope.alunoId = '',
        $scope.nome = '',
        $scope.cursoId = '',
        $scope.curso = '';
    }
});