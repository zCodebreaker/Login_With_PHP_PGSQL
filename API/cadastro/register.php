<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

require __DIR__ . "/../include/config.php";

echo "Iniciando o script...<br>";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    echo "Método POST detectado.<br>";

    $usuario = trim($_POST["usuario"]);
    $senha = $_POST["senha"];
    $confirmarSenha = $_POST["confirmar_senha"];

    echo "Usuário recebido: $usuario<br>";

    if ($senha !== $confirmarSenha) {
        die("Erro: As senhas não coincidem.");
    } else {
        echo "Senhas conferem!<br>";
    }
    echo "Verificando usuário no banco...<br>";
    $stmt = $pdo->prepare("SELECT usuario FROM contas WHERE usuario = ?");
    $stmt->execute([$usuario]);

    if ($stmt->fetch()) {
        die("Erro: Usuário já existe.");
    }

    echo "Usuário não encontrado, continuando...<br>";
    $senhaHash = password_hash($senha, PASSWORD_BCRYPT);

    echo "Senha criptografada.<br>";

    echo "Inserindo usuário no banco...<br>";
    $stmt = $pdo->prepare("INSERT INTO contas (usuario, senha, hwid, ban) VALUES (?, ?, NULL, false)");

    if ($stmt->execute([$usuario, $senhaHash])) {
        echo "<script>alert('Registro bem-sucedido! Agora faça login.'); window.location.href = 'login.php';</script>";
    } else {
        die("Erro ao registrar usuário.");
    }
} else {
    die("Erro: Método de requisição inválido.");
}
?>
