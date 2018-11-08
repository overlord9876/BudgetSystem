/*
 Navicat Premium Data Transfer

 Source Server         : 127.0.0.1
 Source Server Type    : MySQL
 Source Server Version : 50723
 Source Host           : localhost:3306
 Source Schema         : budgetsystem

 Target Server Type    : MySQL
 Target Server Version : 50723
 File Encoding         : 65001

 Date: 08/11/2018 21:07:53
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for 客户业务页匹配关系表
-- ----------------------------
DROP TABLE IF EXISTS `客户业务页匹配关系表`;
CREATE TABLE `客户业务页匹配关系表`  (
  `Customer` int(11) NOT NULL,
  `Salesman` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  PRIMARY KEY (`Customer`, `Salesman`) USING BTREE,
  INDEX `FK_Reference_10`(`Salesman`) USING BTREE,
  CONSTRAINT `FK_Reference_10` FOREIGN KEY (`Salesman`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_9` FOREIGN KEY (`Customer`) REFERENCES `customer` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for actualreceipts
-- ----------------------------
DROP TABLE IF EXISTS `actualreceipts`;
CREATE TABLE `actualreceipts`  (
  `ID` int(11) NOT NULL,
  `Cus_ID` int(11) NOT NULL,
  `Name` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `OriginalCoin` decimal(10, 0) NULL DEFAULT NULL,
  `RMB` decimal(10, 0) NULL DEFAULT NULL,
  `BankCharges` decimal(10, 0) NULL DEFAULT NULL,
  `ReceiptDate` datetime(0) NULL DEFAULT NULL,
  `State` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CreateTimestamp` datetime(0) NOT NULL,
  `Description` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_7`(`CreateUser`) USING BTREE,
  INDEX `FK_Reference_8`(`Cus_ID`) USING BTREE,
  CONSTRAINT `FK_Reference_6` FOREIGN KEY (`CreateUser`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_7` FOREIGN KEY (`CreateUser`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_8` FOREIGN KEY (`Cus_ID`) REFERENCES `customer` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for approvalconfig
-- ----------------------------
DROP TABLE IF EXISTS `approvalconfig`;
CREATE TABLE `approvalconfig`  (
  `Name` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `CreateTimestamp` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for approvalconfigdetail
-- ----------------------------
DROP TABLE IF EXISTS `approvalconfigdetail`;
CREATE TABLE `approvalconfigdetail`  (
  `Name` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `OrderNo` int(11) NOT NULL,
  `ApprovalUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Name`, `OrderNo`) USING BTREE,
  INDEX `FK_Reference_3`(`ApprovalUser`) USING BTREE,
  CONSTRAINT `FK_Reference_1` FOREIGN KEY (`Name`) REFERENCES `approvalconfig` (`Name`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_3` FOREIGN KEY (`ApprovalUser`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for budget
-- ----------------------------
DROP TABLE IF EXISTS `budget`;
CREATE TABLE `budget`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ContractNO` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `State` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `Salesman` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `Department` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `CreateDate` datetime(0) NOT NULL,
  `SignDate` datetime(0) NULL DEFAULT NULL,
  `Validity` datetime(0) NULL DEFAULT NULL,
  `Purchaser` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Purchaser1` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Purchaser2` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Purchaser3` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Purchaser4` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Purchaser5` varchar(128) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `TradeMode` smallint(6) NULL DEFAULT NULL COMMENT '0=一般贸易\r\n            1=来料加工\r\n            2=进料加工\r\n            3=纯进口\r\n            4=内贸',
  `TradeNature` smallint(6) NULL DEFAULT NULL COMMENT '0=做单\r\n            1=过单',
  `OutProductDetail` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  `PriceClause` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Seaport` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `OutSettlementMethod` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `OutSettlementMethod2` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `OutSettlementMethod3` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `TotalAmount` decimal(10, 0) NULL DEFAULT NULL,
  `Country` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Supplier` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  `IsQualifiedSupplier` bit(1) NULL DEFAULT NULL,
  `InProductDetail` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  `InSettlementMethod1` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `InSettlementMethod2` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `AdvancePayment` decimal(10, 0) NULL DEFAULT NULL,
  `InterestRate` float NULL DEFAULT NULL,
  `Days` smallint(6) NULL DEFAULT NULL,
  `Commission` decimal(10, 0) NULL DEFAULT NULL,
  `Premium` decimal(10, 0) NULL DEFAULT NULL,
  `BankCharges` decimal(10, 0) NULL DEFAULT NULL,
  `DirectCosts` decimal(10, 0) NULL DEFAULT NULL,
  `FeedMoney` decimal(10, 0) NULL DEFAULT NULL,
  `ExchangeRate` float NULL DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for budgetapproval
-- ----------------------------
DROP TABLE IF EXISTS `budgetapproval`;
CREATE TABLE `budgetapproval`  (
  `ID` int(11) NOT NULL,
  `BudgetId` int(11) NOT NULL,
  `OrderNo` int(11) NULL DEFAULT NULL,
  `Approver` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `ApprovalTime` datetime(0) NULL DEFAULT NULL,
  `Result` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `IsCurrentRounds` bit(1) NOT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_4`(`BudgetId`) USING BTREE,
  INDEX `FK_Reference_5`(`Approver`) USING BTREE,
  CONSTRAINT `FK_Reference_4` FOREIGN KEY (`BudgetId`) REFERENCES `budget` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_5` FOREIGN KEY (`Approver`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for customer
-- ----------------------------
DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Country` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `CreateDate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for department
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department`  (
  `Code` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL COMMENT '标识',
  `Name` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '名称',
  `Manager` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '部门经理',
  `AssistantManager` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '部门副经理',
  `Remark` varchar(100) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '描述',
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateDatetime` datetime(0) NULL DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`Code`) USING BTREE,
  INDEX `FK_Reference_24`(`AssistantManager`) USING BTREE,
  INDEX `FK_Reference_25`(`Manager`) USING BTREE,
  INDEX `FK_Reference_26`(`CreateUser`) USING BTREE,
  CONSTRAINT `FK_Reference_24` FOREIGN KEY (`AssistantManager`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_25` FOREIGN KEY (`Manager`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_26` FOREIGN KEY (`CreateUser`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '部门表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES ('CWB', '财务部', 'admin', 'admin', '111', 'admin', '2018-10-20 00:44:56');
INSERT INTO `department` VALUES ('TestDept1', '测试部门1', 'test1', 'test2', '', 'admin', '0001-01-01 00:00:00');
INSERT INTO `department` VALUES ('YWB1', '业务一部111', 'admin', 'admin', '111', NULL, '0001-01-01 00:00:00');

-- ----------------------------
-- Table structure for flow
-- ----------------------------
DROP TABLE IF EXISTS `flow`;
CREATE TABLE `flow`  (
  `Name` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL COMMENT '流程名称',
  `VersionNumber` int(11) NOT NULL COMMENT '流程版本号',
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `Remark` varchar(200) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '流程说明',
  `IsEnabled` bit(1) NULL DEFAULT NULL COMMENT '是否使用版本',
  PRIMARY KEY (`Name`, `VersionNumber`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '审批配置主表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of flow
-- ----------------------------
INSERT INTO `flow` VALUES ('供应商审批', 0, 'admin', '2018-10-25 22:55:19', '预设空流程', b'0');
INSERT INTO `flow` VALUES ('供应商审批', 1, 'admin', '2018-10-26 23:33:51', '预设空流程', b'0');
INSERT INTO `flow` VALUES ('供应商审批', 2, 'admin', '2018-10-26 23:51:36', '预设空流程', b'0');
INSERT INTO `flow` VALUES ('供应商审批', 3, 'admin', '2018-10-26 23:52:37', '预设空流程', b'0');
INSERT INTO `flow` VALUES ('供应商审批', 4, 'admin', '2018-10-27 00:09:28', '预设空流程', b'1');
INSERT INTO `flow` VALUES ('预算单审批', 0, 'admin', '2018-10-25 22:53:49', '预设空流程', b'0');
INSERT INTO `flow` VALUES ('预算单审批', 1, 'admin', '2018-10-26 23:53:21', '1111', b'0');
INSERT INTO `flow` VALUES ('预算单审批', 2, 'admin', '2018-10-26 23:53:39', '1111222', b'0');
INSERT INTO `flow` VALUES ('预算单审批', 3, 'admin', '2018-10-29 00:22:30', '1111222', b'1');

-- ----------------------------
-- Table structure for flowinstance
-- ----------------------------
DROP TABLE IF EXISTS `flowinstance`;
CREATE TABLE `flowinstance`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `FlowName` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '流程名称',
  `FlowVersionNumber` int(11) NULL DEFAULT NULL COMMENT '流程版本号',
  `DateItemID` int(11) NULL DEFAULT NULL COMMENT '数据项ID',
  `DateItemType` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '数据类型',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '发起时间',
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '发起人',
  `ApproveResult` bit(1) NULL DEFAULT NULL COMMENT '结果',
  `IsClosed` bit(1) NULL DEFAULT NULL COMMENT '是否已结束',
  `CloseReason` varchar(100) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '关闭原因',
  `CloseDateTime` datetime(0) NULL DEFAULT NULL COMMENT '关闭时间',
  `IsCreateUserConfirm` bit(1) NULL DEFAULT NULL COMMENT '发起人是否已确认',
  `ConfirmDateTime` datetime(0) NULL DEFAULT NULL COMMENT '确认时间',
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `Index_Date`(`DateItemID`, `DateItemType`) USING BTREE,
  INDEX `FK_Reference_FlowInstance_Flow`(`FlowName`, `FlowVersionNumber`) USING BTREE,
  CONSTRAINT `FK_Reference_FlowInstance_Flow` FOREIGN KEY (`FlowName`, `FlowVersionNumber`) REFERENCES `flow` (`Name`, `VersionNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '审批主表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of flowinstance
-- ----------------------------
INSERT INTO `flowinstance` VALUES (5, '预算单审批', 3, 999, '测试业务数据', '2018-10-29 00:24:04', 'admin', b'0', b'1', '审批不通过', '2018-10-29 00:28:01', b'1', '2018-11-03 22:32:08');
INSERT INTO `flowinstance` VALUES (6, '预算单审批', 3, 999, '测试业务数据', '2018-10-29 00:28:56', 'admin', b'1', b'1', '审批通过', '2018-10-29 00:45:47', b'0', NULL);
INSERT INTO `flowinstance` VALUES (8, '预算单审批', 3, 999, '测试业务数据', '2018-10-29 00:47:18', 'TestUser1', b'1', b'1', '审批通过', '2018-10-29 00:50:28', b'0', NULL);
INSERT INTO `flowinstance` VALUES (9, '预算单审批', 3, 999, '测试业务数据', '2018-10-29 00:50:46', 'TestUser2', b'0', b'1', '审批不通过', '2018-10-29 00:51:42', b'0', NULL);
INSERT INTO `flowinstance` VALUES (10, '预算单审批', 3, 999, '测试业务数据', '2018-11-02 22:30:41', 'TestUser2', b'0', b'1', '流转失败，流程发起人未配置部门，无法定位审批人', '2018-11-03 01:01:46', b'0', NULL);
INSERT INTO `flowinstance` VALUES (11, '预算单审批', 3, 999, '测试业务数据', '2018-11-03 01:02:36', 'admin', b'0', b'0', NULL, NULL, b'0', NULL);

-- ----------------------------
-- Table structure for flownode
-- ----------------------------
DROP TABLE IF EXISTS `flownode`;
CREATE TABLE `flownode`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `Name` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '流程名称',
  `VersionNumber` int(11) NULL DEFAULT NULL COMMENT '流程版本号',
  `OrderNo` int(11) NULL DEFAULT NULL COMMENT '顺序号',
  `NodeConfig` int(11) NULL DEFAULT NULL COMMENT '节点配置0人1部门&经理 2部门&副经理',
  `NodeValue` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '节点配置值',
  `NodeValueRemark` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '节点配置值描述(用于打印时的抬头)',
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `Index_Flow`(`Name`, `VersionNumber`) USING BTREE,
  CONSTRAINT `FK_Reference_FlowNode_Flow` FOREIGN KEY (`Name`, `VersionNumber`) REFERENCES `flow` (`Name`, `VersionNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 21 CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '审批配置子表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of flownode
-- ----------------------------
INSERT INTO `flownode` VALUES (1, '供应商审批', 1, 1, 0, '%StartUser%', '11');
INSERT INTO `flownode` VALUES (2, '供应商审批', 1, 2, 2, '%StartUserDepartment%', '22');
INSERT INTO `flownode` VALUES (3, '供应商审批', 2, 1, 0, '%StartUser%', '11');
INSERT INTO `flownode` VALUES (4, '供应商审批', 2, 2, 2, '%StartUserDepartment%', '22');
INSERT INTO `flownode` VALUES (5, '供应商审批', 2, 3, 0, '%StartUser%', '33');
INSERT INTO `flownode` VALUES (6, '供应商审批', 3, 1, 0, '%StartUser%', '11');
INSERT INTO `flownode` VALUES (7, '供应商审批', 3, 2, 2, '%StartUserDepartment%', '22');
INSERT INTO `flownode` VALUES (8, '供应商审批', 3, 3, 0, 'test1', '31');
INSERT INTO `flownode` VALUES (9, '供应商审批', 3, 4, 0, '%StartUser%', '33');
INSERT INTO `flownode` VALUES (10, '预算单审批', 1, 1, 0, '1111', '22');
INSERT INTO `flownode` VALUES (11, '预算单审批', 2, 1, 0, '1111', '22');
INSERT INTO `flownode` VALUES (12, '预算单审批', 2, 2, 0, 'test1', '33');
INSERT INTO `flownode` VALUES (13, '供应商审批', 4, 1, 0, '%StartUser%', '11');
INSERT INTO `flownode` VALUES (14, '供应商审批', 4, 2, 2, '%StartUserDepartment%', '22');
INSERT INTO `flownode` VALUES (15, '供应商审批', 4, 3, 0, 'test1', '31');
INSERT INTO `flownode` VALUES (16, '供应商审批', 4, 4, 0, '%StartUser%', '33');
INSERT INTO `flownode` VALUES (17, '预算单审批', 3, 1, 0, 'admin', '管理员审批');
INSERT INTO `flownode` VALUES (18, '预算单审批', 3, 2, 1, 'CWB', '财务部经理审批');
INSERT INTO `flownode` VALUES (19, '预算单审批', 3, 3, 0, '%StartUser%', '自己审批');
INSERT INTO `flownode` VALUES (20, '预算单审批', 3, 4, 2, '%StartUserDepartment%', '自己的副经理审批');

-- ----------------------------
-- Table structure for flowrunpoint
-- ----------------------------
DROP TABLE IF EXISTS `flowrunpoint`;
CREATE TABLE `flowrunpoint`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `NodeID` int(11) NULL DEFAULT NULL COMMENT '节点ID',
  `NodeOrderNo` int(11) NULL DEFAULT NULL COMMENT '节点的ID顺序号',
  `InstanceID` int(11) NULL DEFAULT NULL COMMENT '实例ID',
  `NodeApproveUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '实际审批人',
  `NodeApproveResult` bit(1) NULL DEFAULT NULL COMMENT '节点审批结果',
  `NodeApproveRemark` varchar(300) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '节点审批意见',
  `State` bit(1) NULL DEFAULT NULL COMMENT '运行点状态0，未处理，1已审批',
  `RunPointCreateDate` datetime(0) NULL DEFAULT NULL COMMENT '生成时间',
  `NodeApproveDate` datetime(0) NULL DEFAULT NULL COMMENT '审核时间',
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_FlowRunpoint_FlowNode`(`NodeID`) USING BTREE,
  INDEX `Index_MyApprove`(`NodeApproveUser`, `State`) USING BTREE,
  INDEX `FK_Reference_FlowRunpoint_FlowInstance`(`InstanceID`) USING BTREE,
  CONSTRAINT `FK_Reference_FlowRunpoint_FlowInstance` FOREIGN KEY (`InstanceID`) REFERENCES `flowinstance` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_FlowRunpoint_FlowNode` FOREIGN KEY (`NodeID`) REFERENCES `flownode` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '审批过程表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of flowrunpoint
-- ----------------------------
INSERT INTO `flowrunpoint` VALUES (1, 17, 1, 5, 'admin', b'0', '不同意', b'1', '2018-10-29 00:24:05', '2018-10-29 00:27:58');
INSERT INTO `flowrunpoint` VALUES (2, 17, 1, 6, 'admin', b'1', '不同意', b'1', '2018-10-29 00:28:56', '2018-10-29 00:36:22');
INSERT INTO `flowrunpoint` VALUES (3, 18, 2, 6, 'admin', b'1', '同意', b'1', '2018-10-29 00:37:40', '2018-10-29 00:38:32');
INSERT INTO `flowrunpoint` VALUES (4, 18, 2, 6, 'admin', b'1', '同意', b'1', '2018-10-29 00:38:36', '2018-10-29 00:39:23');
INSERT INTO `flowrunpoint` VALUES (5, 18, 2, 6, 'admin', b'1', '同意', b'1', '2018-10-29 00:39:25', '2018-10-29 00:41:08');
INSERT INTO `flowrunpoint` VALUES (6, 18, 2, 6, 'admin', b'1', '同意', b'1', '2018-10-29 00:42:53', '2018-10-29 00:44:01');
INSERT INTO `flowrunpoint` VALUES (7, 19, 3, 6, 'admin', b'1', '同意', b'1', '2018-10-29 00:44:22', '2018-10-29 00:44:36');
INSERT INTO `flowrunpoint` VALUES (8, 20, 4, 6, 'test2', b'1', '同意', b'1', '2018-10-29 00:45:02', '2018-10-29 00:45:37');
INSERT INTO `flowrunpoint` VALUES (9, 17, 1, 8, 'admin', b'1', '同意', b'1', '2018-10-29 00:47:18', '2018-10-29 00:47:55');
INSERT INTO `flowrunpoint` VALUES (10, 18, 2, 8, 'admin', b'1', '同意', b'1', '2018-10-29 00:47:57', '2018-10-29 00:48:18');
INSERT INTO `flowrunpoint` VALUES (11, 19, 3, 8, 'TestUser1', b'1', '同意', b'1', '2018-10-29 00:48:30', '2018-10-29 00:49:06');
INSERT INTO `flowrunpoint` VALUES (12, 20, 4, 8, 'test2', b'1', '同意', b'1', '2018-10-29 00:49:29', '2018-10-29 00:50:28');
INSERT INTO `flowrunpoint` VALUES (13, 17, 1, 9, 'admin', b'1', '同意', b'1', '2018-10-29 00:50:46', '2018-10-29 00:51:03');
INSERT INTO `flowrunpoint` VALUES (14, 18, 2, 9, 'admin', b'1', '同意', b'1', '2018-10-29 00:51:04', '2018-10-29 00:51:19');
INSERT INTO `flowrunpoint` VALUES (15, 19, 3, 9, 'TestUser2', b'1', '同意', b'1', '2018-10-29 00:51:19', '2018-10-29 00:51:22');
INSERT INTO `flowrunpoint` VALUES (16, 17, 1, 10, 'admin', b'1', '1111', b'1', '2018-11-02 22:30:41', '2018-11-03 00:36:54');
INSERT INTO `flowrunpoint` VALUES (17, 18, 2, 10, 'admin', b'1', '', b'1', '2018-11-03 00:36:54', '2018-11-03 00:37:15');
INSERT INTO `flowrunpoint` VALUES (18, 19, 3, 10, 'TestUser2', b'1', '{\r\n                case FlowRunState.启动流程成功:\r\n                    result = true;\r\n                    info = \"启动流程成功\";\r\n                    break;\r\n                case FlowRunState.数据项已正在:\r\n                    info = \"提交流程失败，当前数据项的流程已存在，不可以发起重复审批\";\r\n                    break;', b'1', '2018-11-03 00:37:15', '2018-11-03 01:01:46');
INSERT INTO `flowrunpoint` VALUES (19, 17, 1, 11, 'admin', b'1', '{\r\n                case FlowRunState.启动流程成功:\r\n                    result = true;\r\n                    info = \"启动流程成功\";\r\n                    break;\r\n                case FlowRunState.数据项已正在:\r\n                    info = \"提交流程失败，当前数据项的流程已存在，不可以发起重复审批\";\r\n                    break;', b'1', '2018-11-03 01:02:36', '2018-11-03 01:02:56');
INSERT INTO `flowrunpoint` VALUES (20, 18, 2, 11, 'admin', b'1', '11\r\nbb\r\ncc', b'1', '2018-11-03 01:02:56', '2018-11-03 01:04:55');
INSERT INTO `flowrunpoint` VALUES (21, 19, 3, 11, 'admin', NULL, NULL, b'0', '2018-11-03 01:04:55', NULL);

-- ----------------------------
-- Table structure for paymentnotes
-- ----------------------------
DROP TABLE IF EXISTS `paymentnotes`;
CREATE TABLE `paymentnotes`  (
  `ID` int(11) NOT NULL,
  `Submitter` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CommitTime` datetime(0) NULL DEFAULT NULL,
  `Money` decimal(10, 0) NOT NULL,
  `State` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `Approver` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `ApproveTime` datetime(0) NOT NULL,
  `BudgetID` int(11) NOT NULL,
  `Supplier` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `Overdue` int(11) NULL DEFAULT NULL,
  `PaymentDate` datetime(0) NULL DEFAULT NULL,
  `Description` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_12`(`BudgetID`) USING BTREE,
  INDEX `FK_Reference_14`(`Submitter`) USING BTREE,
  INDEX `FK_Reference_15`(`Approver`) USING BTREE,
  CONSTRAINT `FK_Reference_12` FOREIGN KEY (`BudgetID`) REFERENCES `budget` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_14` FOREIGN KEY (`Submitter`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_15` FOREIGN KEY (`Approver`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for receivableaccounts
-- ----------------------------
DROP TABLE IF EXISTS `receivableaccounts`;
CREATE TABLE `receivableaccounts`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Bud_ID` int(11) NULL DEFAULT NULL,
  `Name` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `InvoiceNo` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `InvoiceDate` datetime(0) NULL DEFAULT NULL,
  `OriginalCoin` decimal(10, 0) NULL DEFAULT NULL,
  `RMB` decimal(10, 0) NULL DEFAULT NULL,
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CreateTimestamp` datetime(0) NOT NULL,
  `Remark` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_22`(`Bud_ID`) USING BTREE,
  CONSTRAINT `FK_Reference_22` FOREIGN KEY (`Bud_ID`) REFERENCES `budget` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '应收账款应当是开具发票给客户，此时为应收账款' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for receivablesconfirmation
-- ----------------------------
DROP TABLE IF EXISTS `receivablesconfirmation`;
CREATE TABLE `receivablesconfirmation`  (
  `ID` int(11) NOT NULL,
  `Act_ID` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_23`(`Act_ID`) USING BTREE,
  CONSTRAINT `FK_Reference_21` FOREIGN KEY (`ID`) REFERENCES `receivableaccounts` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_23` FOREIGN KEY (`Act_ID`) REFERENCES `actualreceipts` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `Code` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL COMMENT '角色标识',
  `Name` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '角色名称',
  `Remark` varchar(100) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '角色描述',
  PRIMARY KEY (`Code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '角色表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('CW', '财务', NULL);
INSERT INTO `role` VALUES ('Default', '系统管理员', '系统全局管理员');
INSERT INTO `role` VALUES ('YWY', '业务员', NULL);

-- ----------------------------
-- Table structure for rolepermission
-- ----------------------------
DROP TABLE IF EXISTS `rolepermission`;
CREATE TABLE `rolepermission`  (
  `RoleCode` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '角色标识',
  `Permission` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '权限',
  INDEX `FK_Reference_27`(`RoleCode`) USING BTREE,
  CONSTRAINT `FK_Reference_27` FOREIGN KEY (`RoleCode`) REFERENCES `role` (`Code`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '角色权限表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of rolepermission
-- ----------------------------
INSERT INTO `rolepermission` VALUES ('CW', 'UserManagement');
INSERT INTO `rolepermission` VALUES ('CW', 'UserManagement.View');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.ReSetPassword');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.Modify');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.New');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.Disabled');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.Enabled');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.View');
INSERT INTO `rolepermission` VALUES ('YWY', 'FlowManagement.Modify');
INSERT INTO `rolepermission` VALUES ('YWY', 'FlowManagement');
INSERT INTO `rolepermission` VALUES ('YWY', 'FlowManagement.View');
INSERT INTO `rolepermission` VALUES ('YWY', 'RoleManagement.New');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.DistributeRoleUser');
INSERT INTO `rolepermission` VALUES ('YWY', 'UserManagement.DistributeRolePermission');
INSERT INTO `rolepermission` VALUES ('YWY', 'DepartmentManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.New');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.ReSetPassword');
INSERT INTO `rolepermission` VALUES ('Default', 'RoleManagement.New');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.DistributeRolePermission');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.DistributeRoleUser');
INSERT INTO `rolepermission` VALUES ('Default', 'DepartmentManagement');
INSERT INTO `rolepermission` VALUES ('Default', 'DepartmentManagement.New');
INSERT INTO `rolepermission` VALUES ('Default', 'DepartmentManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Default', 'DepartmentManagement.View');
INSERT INTO `rolepermission` VALUES ('Default', 'FlowManagement');
INSERT INTO `rolepermission` VALUES ('Default', 'FlowManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Default', 'FlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Default', 'RoleManagement');
INSERT INTO `rolepermission` VALUES ('Default', 'RoleManagement.DistributeRolePermission');
INSERT INTO `rolepermission` VALUES ('Default', 'RoleManagement.DistributeRoleUser');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.Disabled');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.Enabled');
INSERT INTO `rolepermission` VALUES ('Default', 'UserManagement.View');
INSERT INTO `rolepermission` VALUES ('Default', 'MySubmitFlowManagement.Confirm');
INSERT INTO `rolepermission` VALUES ('Default', 'MySubmitFlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Default', 'MySubmitFlowManagement');
INSERT INTO `rolepermission` VALUES ('Default', 'MyPendingFlowManagement.Approve');
INSERT INTO `rolepermission` VALUES ('Default', 'MyPendingFlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Default', 'MyPendingFlowManagement');

-- ----------------------------
-- Table structure for supplier
-- ----------------------------
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `BankAccountName` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `BankNO` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `BankName` varchar(256) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `IsQualified` bit(1) NULL DEFAULT NULL,
  `CreateDate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for supplierapprovaldetail
-- ----------------------------
DROP TABLE IF EXISTS `supplierapprovaldetail`;
CREATE TABLE `supplierapprovaldetail`  (
  `ID` int(11) NOT NULL,
  `SupplierID` int(11) NULL DEFAULT NULL,
  `OrderNo` int(11) NULL DEFAULT NULL,
  `Approver` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `ApprovalTime` datetime(0) NULL DEFAULT NULL,
  `Result` varchar(10) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `IsCurrentRounds` bit(1) NOT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_17`(`SupplierID`) USING BTREE,
  CONSTRAINT `FK_Reference_17` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for systemconfig
-- ----------------------------
DROP TABLE IF EXISTS `systemconfig`;
CREATE TABLE `systemconfig`  (
  `Name` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `Value` text CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  PRIMARY KEY (`Name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '不做复杂的，使用Json进行配置' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `UserName` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL COMMENT '用户名',
  `RealName` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '用户姓名',
  `Role` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '用户角色',
  `Department` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '所属部门',
  `Password` varchar(80) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '密码',
  `State` bit(1) NULL DEFAULT NULL COMMENT '用户状态',
  `CreateUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateDateTime` datetime(0) NULL DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`UserName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci COMMENT = '用户表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('11', '22', 'Default', 'CWB', '6B86B273FF34FCE19D6B804EFF5A3F5747ADA4EAA22F1D49C01E52DDB7875B4B', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('1111', '1111', 'Default', 'CWB', '4FC82B26AECB47D2868C4EFBE3581732A3E7CBCC6C2EFB32062C08170A05EEB8', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('admin', 'admin', 'Default', 'TestDept1', '6B86B273FF34FCE19D6B804EFF5A3F5747ADA4EAA22F1D49C01E52DDB7875B4B', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('fda', 'fd', 'Default', 'YWB1', 'C6F3AC57944A531490CD39902D0F777715FD005EFAC9A30622D5F5205E7F6894', b'0', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('test', 'test', 'Default', '', '4FC82B26AECB47D2868C4EFBE3581732A3E7CBCC6C2EFB32062C08170A05EEB8', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('test1', 'test1', 'Default', 'YWB1', 'abc', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('test2', 'test2', 'Default', '', 'abc', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('TestUser1', '测试用户A', 'Default', 'TestDept1', '6B86B273FF34FCE19D6B804EFF5A3F5747ADA4EAA22F1D49C01E52DDB7875B4B', b'1', 'admin', '2018-11-07 22:51:19');
INSERT INTO `user` VALUES ('TestUser2', '测试用户2', 'Default', '', '6B86B273FF34FCE19D6B804EFF5A3F5747ADA4EAA22F1D49C01E52DDB7875B4B', b'1', 'admin', '2018-11-07 22:51:19');

-- ----------------------------
-- Table structure for useroperationnotes
-- ----------------------------
DROP TABLE IF EXISTS `useroperationnotes`;
CREATE TABLE `useroperationnotes`  (
  `ID` int(11) NOT NULL,
  `OperationType` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `OperationUser` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `OperationDate` datetime(0) NOT NULL,
  `OperationContent` text CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_11`(`OperationUser`) USING BTREE,
  CONSTRAINT `FK_Reference_11` FOREIGN KEY (`OperationUser`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for voucherno
-- ----------------------------
DROP TABLE IF EXISTS `voucherno`;
CREATE TABLE `voucherno`  (
  `Pay_ID` int(11) NOT NULL,
  `Vou_ID` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  PRIMARY KEY (`Pay_ID`, `Vou_ID`) USING BTREE,
  INDEX `FK_Reference_20`(`Vou_ID`) USING BTREE,
  CONSTRAINT `FK_Reference_19` FOREIGN KEY (`Pay_ID`) REFERENCES `paymentnotes` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_20` FOREIGN KEY (`Vou_ID`) REFERENCES `vouchernotes` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for vouchernotes
-- ----------------------------
DROP TABLE IF EXISTS `vouchernotes`;
CREATE TABLE `vouchernotes`  (
  `ID` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `BudgetId` int(11) NOT NULL,
  `VoucherNo` varchar(50) CHARACTER SET gbk COLLATE gbk_chinese_ci NULL DEFAULT NULL,
  `InvoiceDate` datetime(0) NULL DEFAULT NULL,
  `Payment` decimal(10, 0) NULL DEFAULT NULL,
  `Submitter` varchar(30) CHARACTER SET gbk COLLATE gbk_chinese_ci NOT NULL,
  `CommitTime` datetime(0) NOT NULL,
  `Description` text CHARACTER SET gbk COLLATE gbk_chinese_ci NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `FK_Reference_13`(`BudgetId`) USING BTREE,
  INDEX `FK_Reference_16`(`Submitter`) USING BTREE,
  CONSTRAINT `FK_Reference_13` FOREIGN KEY (`BudgetId`) REFERENCES `budget` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Reference_16` FOREIGN KEY (`Submitter`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = gbk COLLATE = gbk_chinese_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Procedure structure for CreateClass
-- ----------------------------
DROP PROCEDURE IF EXISTS `CreateClass`;
delimiter ;;
CREATE PROCEDURE `CreateClass`(IN tName VARCHAR(30))
BEGIN
	DECLARE done INT DEFAULT 0; 

	DECLARE typestring VARCHAR(30);
	DECLARE cname VARCHAR(300);
	DECLARE ctype VARCHAR(300);
	DECLARE cdesc VARCHAR(300);
	DECLARE mycursor CURSOR FOR 
		SELECT COLUMN_NAME ,DATA_TYPE,COLUMN_COMMENT FROM	information_schema.`COLUMNS` WHERE	TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done=1;

	DROP TEMPORARY TABLE IF EXISTS `cc`;

	CREATE TEMPORARY TABLE cc (str VARCHAR(300)) ;

	INSERT Into cc values ('/// <summary>');


	SELECT table_comment into cdesc from information_schema.`TABLES` where TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;

	INSERT Into cc values (CONCAT('/// ',cdesc));
	INSERT Into cc values ('/// </summary>');
	INSERT Into cc values (CONCAT('public class ',tName,':IEntity'));
	INSERT Into cc values ('{');

	
	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,ctype,cdesc; 

			IF NOT DONE THEN 
				
				if ctype = 'varchar' or ctype = 'text' THEN
					set typestring = 'string';
				elseif ctype ='bit' THEN
					set typestring = 'bool';
				elseif ctype ='datetime' or ctype ='date' or ctype ='time' THEN
					set typestring = 'DateTime';
				elseif ctype ='int' or ctype ='smallint'THEN
					set typestring = 'int';
				elseif ctype ='decimal' THEN
					set typestring = 'decimal';
				elseif ctype ='float' THEN
					set typestring = 'float';
				else 
					set typestring = ctype;
				end if;
				INSERT Into cc values ('    /// <summary>');
				INSERT Into cc values (CONCAT('    /// ',cdesc));
				INSERT Into cc values ('    /// </summary>');
				INSERT Into cc values (CONCAT( '    public ', typestring ,' ', cname,'{ get; set; }'));
				INSERT Into cc values ('');
			END IF;

		UNTIL done END REPEAT;

	close mycursor;




	INSERT Into cc values ('}');

	SELECT * from cc;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CreateSql
-- ----------------------------
DROP PROCEDURE IF EXISTS `CreateSql`;
delimiter ;;
CREATE PROCEDURE `CreateSql`(IN tName VARCHAR(30))
BEGIN
	DECLARE done INT DEFAULT 0; 

	DECLARE pkey VARCHAR(30);
	DECLARE cname VARCHAR(300);
	DECLARE csel VARCHAR(10);
	DECLARE cint VARCHAR(10);
	DECLARE cup VARCHAR(10);
	DECLARE cdel VARCHAR(10);
	DECLARE cno int DEFAULT 0; 

	DECLARE mycursor CURSOR FOR 
		SELECT COLUMN_NAME ,COLUMN_KEY FROM	information_schema.`COLUMNS` WHERE	TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done=1;

	DROP TEMPORARY TABLE IF EXISTS `sqltable`;


	CREATE TEMPORARY TABLE sqltable (sqltype VARCHAR(30),str VARCHAR(300),nn int) ;
	
	INSERT Into sqltable values ('select',CONCAT('string selectSql = "Select '),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('insert',CONCAT('string insertSql = "Insert Into `',tName,'` ('),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT('string updateSql = "Update `',tName,'` Set '),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('delete',CONCAT('string deleteSql = "Delete From `',tName,'` Where '),cno);
	set cno = cno+1;

	Set csel='';
	Set cint='';
	Set cup='';
	Set cdel='';

	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,pkey; 

			IF NOT DONE THEN 
				
				
				
				INSERT Into sqltable values ('select',CONCAT(csel,'`',cname,'`'),cno);
				set cno = cno+1;
				Set csel = ',';

				INSERT Into sqltable values ('insert',CONCAT(cint,'`',cname,'`'),cno);
				set cno = cno+1;
				Set cint = ',';
				
				if pkey <> 'PRI' then
					INSERT Into sqltable values ('update',CONCAT(cup,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cup=',';
				end if;

			END IF;

		UNTIL done END REPEAT;

	close mycursor;


	INSERT Into sqltable values ('select',CONCAT(' From `',tName,'` Where'),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('insert',CONCAT(') Values ('),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT(' Where '),cno);
	set cno = cno+1;

	set done =0;
	Set csel='';
	Set cint='';
	Set cup='';
	Set cdel='';


	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,pkey; 

			IF NOT DONE THEN 


				if pkey = 'PRI' then
					INSERT Into sqltable values ('select',CONCAT(csel,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set csel=' and ';
				end if;

				INSERT Into sqltable values ('insert',CONCAT(cint,'@',cname,''),cno);
				set cno = cno+1;
				Set cint=',';

				if pkey = 'PRI' then
					INSERT Into sqltable values ('update',CONCAT(cup,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cup=' and ';
				end if;

				if pkey = 'PRI' then
					INSERT Into sqltable values ('delete',CONCAT(cdel,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cdel=' and ';
				end if;



			END IF;

		UNTIL done END REPEAT;

	close mycursor;

	INSERT Into sqltable values ('select',CONCAT('";'),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('insert',CONCAT(')";'),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT('";'),cno);
  set cno = cno+1;
	INSERT Into sqltable values ('delete',CONCAT('";'),cno);

  select group_concat(str Order by nn SEPARATOR  '') as sqlstr from sqltable  group by sqltype;


END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
