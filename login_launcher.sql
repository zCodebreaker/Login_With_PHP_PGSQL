/*
 Navicat Premium Dump SQL

 Source Server         : App_Launcher
 Source Server Type    : PostgreSQL
 Source Server Version : 170002 (170002)
 Source Host           : localhost:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 170002 (170002)
 File Encoding         : 65001

 Date: 15/02/2025 18:40:25
*/


-- ----------------------------
-- Table structure for appupdate
-- ----------------------------
DROP TABLE IF EXISTS "public"."appupdate";
CREATE TABLE "public"."appupdate" (
  "url" varchar(255) COLLATE "pg_catalog"."default",
  "patch" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of appupdate
-- ----------------------------
INSERT INTO "public"."appupdate" VALUES ('http://localhost/patcher/', 'Launcher_13022025.zip');

-- ----------------------------
-- Table structure for connection
-- ----------------------------
DROP TABLE IF EXISTS "public"."connection";
CREATE TABLE "public"."connection" (
  "address" varchar(255) COLLATE "pg_catalog"."default",
  "appversion" varchar(255) COLLATE "pg_catalog"."default",
  "appstatus" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of connection
-- ----------------------------
INSERT INTO "public"."connection" VALUES ('127.0.0.1', '1.2.0.0', 'ONLINE');

-- ----------------------------
-- Table structure for contas
-- ----------------------------
DROP TABLE IF EXISTS "public"."contas";
CREATE TABLE "public"."contas" (
  "usuario" varchar(100) COLLATE "pg_catalog"."default",
  "senha" varchar(255) COLLATE "pg_catalog"."default",
  "hwid" varchar(255) COLLATE "pg_catalog"."default",
  "ban" bool
)
;

-- ----------------------------
-- Records of contas
-- ----------------------------
INSERT INTO "public"."contas" VALUES ('codebreaker', '$2y$10$eJKuIL2kRIGvldCpykG.huXmx8up8RwnVUlZt9CTmcgkFQsN8sis.', '5fbaf56acca0ac029cef1ea98492bcacf3ff19788a1f6c8db29a9b81883ca60b', 'f');

-- ----------------------------
-- Table structure for gameupdate
-- ----------------------------
DROP TABLE IF EXISTS "public"."gameupdate";
CREATE TABLE "public"."gameupdate" (
  "patchurl" varchar(255) COLLATE "pg_catalog"."default",
  "patchname" varchar(255) COLLATE "pg_catalog"."default",
  "gameversion" varchar(32) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of gameupdate
-- ----------------------------
INSERT INTO "public"."gameupdate" VALUES ('http://localhost/game/gamepatcher/', 'patch_13022035.zip', '1.2.0.0');
