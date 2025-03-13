<?php
header("Content-Type: application/json");
include __DIR__ . "/../include/config.php";

$serverIp = $_SERVER['SERVER_ADDR']; 

if ($serverIp == "::1") {
    $serverIp = "127.0.0.1";
}

$launcherVersion = isset($_GET['launcher_version']) ? trim($_GET['launcher_version']) : null;
$gameVersion = isset($_GET['game_version']) ? trim($_GET['game_version']) : null;

try {
    $pdo = new PDO("pgsql:host=$host;dbname=$dbname", $user, $password);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $response = [
        "status" => "success",
        "message" => "API online e configuracao correta."
    ];
    if ($launcherVersion) {
        $query = "SELECT address, appversion, appstatus FROM connection ORDER BY appversion DESC LIMIT 1";
        $stmt = $pdo->query($query);
        $row = $stmt->fetch(PDO::FETCH_ASSOC);

        if (!$row) {
            echo json_encode(["status" => "error", "message" => "Não é possível conectar à tabela connection."]);
            exit;
        }
        $expectedVersion = $row['appversion'];
        $expectedApiIp = $row['address'];
        $appStatus = $row['appstatus'];
        if ($serverIp !== $expectedApiIp) {
            echo json_encode([
                "status" => "error",
                "message" => "Erro de configuração. A API esta rodando no IP errado.",
                "expected_ip" => $expectedApiIp,
                "actual_ip" => $serverIp
            ]);
            exit;
        }
        if ($appStatus !== "ONLINE") {
            echo json_encode(["status" => "error", "message" => "O servidor esta OFFLINE."]);
            exit;
        }
        if (version_compare($expectedVersion, $launcherVersion, '>')) {
            $updateQuery = "SELECT url, patch FROM appupdate ORDER BY patch DESC LIMIT 1";
            $updateStmt = $pdo->query($updateQuery);
            $updateRow = $updateStmt->fetch(PDO::FETCH_ASSOC);

            if ($updateRow) {
                $response["launcher_update"] = [
                    "new_version" => $expectedVersion,
                    "update_url" => $updateRow['url'],
                    "patch_file" => $updateRow['patch']
                ];
            }
        }
    }
    if ($gameVersion) {
        $gameUpdateQuery = "SELECT patchurl, patchname, gameversion FROM gameupdate ORDER BY gameversion DESC LIMIT 1";
        $gameUpdateStmt = $pdo->query($gameUpdateQuery);
        $gameUpdateRow = $gameUpdateStmt->fetch(PDO::FETCH_ASSOC);

        if ($gameUpdateRow) {
            $latestGameVersion = $gameUpdateRow['gameversion'];

            if (version_compare($latestGameVersion, $gameVersion, '>')) {
                $response["game_update"] = [
                    "patch_url" => $gameUpdateRow['patchurl'],
                    "patch_name" => $gameUpdateRow['patchname'],
                    "game_version" => $latestGameVersion
                ];
            }
        }
    }

    echo json_encode($response);
} catch (PDOException $e) {
    echo json_encode(["status" => "error", "message" => "Falha na conexao com o banco: " . $e->getMessage()]);
}
