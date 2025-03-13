<?php
require __DIR__ . "/../include/config.php";

header("Content-Type: application/json");

file_put_contents("log_headers.txt", print_r(getallheaders(), true));

$contentType = $_SERVER["CONTENT_TYPE"] ?? $_SERVER["HTTP_CONTENT_TYPE"] ?? "";

if (stripos($contentType, "application/json") === false) {
    http_response_code(415);
    echo json_encode([
        "status" => 415,
        "erro" => "tipo_de_conteudo_invalido",
        "detalhes" => "Content-Type deve ser application/json"
    ]);
    exit;
}

$raw_data = file_get_contents("php://input");

if (empty($raw_data)) {
    http_response_code(400);
    echo json_encode(["status" => 400, "erro" => "json_vazio", "detalhes" => "Nenhum dado JSON foi enviado"]);
    exit;
}

$data = json_decode($raw_data, true);

if ($data === null) {
    http_response_code(400);
    echo json_encode([
        "status" => 400,
        "erro" => "json_invalido",
        "detalhes" => json_last_error_msg(),
        "recebido" => $raw_data
    ]);
    exit;
}

if (!isset($data["usuario"], $data["senha"], $data["hwid"])) {
    http_response_code(400);
    echo json_encode(["status" => 400, "erro" => "dados_incompletos"]);
    exit;
}

$usuario = trim($data["usuario"]);
$senha = $data["senha"];
$hwid = trim($data["hwid"]);

$stmt = $pdo->prepare("SELECT senha, hwid, ban FROM contas WHERE usuario = ?");
$stmt->execute([$usuario]);
$user = $stmt->fetch(PDO::FETCH_ASSOC);

if (!$user) {
    http_response_code(401);
    echo json_encode(["status" => 401, "erro" => "usuario_nao_encontrado"]);
    exit;
}

if (!password_verify($senha, $user["senha"])) {
    http_response_code(403);
    echo json_encode(["status" => 403, "erro" => "senha_errada"]);
    exit;
}

if ($user["ban"] == 1) {
    http_response_code(403);
    echo json_encode(["status" => 403, "erro" => "banido"]);
    exit;
}

if (empty($user["hwid"])) {
    $updateHwid = $pdo->prepare("UPDATE contas SET hwid = ? WHERE usuario = ?");
    $updateHwid->execute([$hwid, $usuario]);
    
    http_response_code(200);
    echo json_encode(["status" => 200, "mensagem" => "HWID registrado com sucesso"]);
    exit;
}

if ($user["hwid"] !== $hwid) {
    http_response_code(403);
    echo json_encode(["status" => 403, "erro" => "hwid_errado"]);
    exit;
}

http_response_code(200);
echo json_encode(["status" => 200, "mensagem" => "Login bem-sucedido"]);
?>