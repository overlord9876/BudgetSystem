/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50719
Source Host           : localhost:3306
Source Database       : budgetsystem

Target Server Type    : MYSQL
Target Server Version : 50719
File Encoding         : 65001

Date: 2018-11-12 23:45:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `rolepermission`
-- ----------------------------
DROP TABLE IF EXISTS `rolepermission`;
CREATE TABLE `rolepermission` (
  `RoleCode` varchar(30) DEFAULT NULL COMMENT '角色标识',
  `Permission` varchar(50) DEFAULT NULL COMMENT '权限',
  KEY `FK_Reference_27` (`RoleCode`),
  CONSTRAINT `FK_Reference_27` FOREIGN KEY (`RoleCode`) REFERENCES `role` (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色权限表';

-- ----------------------------
-- Records of rolepermission
-- ----------------------------
INSERT INTO `rolepermission` VALUES ('Role1', 'BuggetManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'InvoiceManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'VoucherNotesManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'MyPendingFlowManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'MySubmitFlowManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'RoleManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'DepartmentManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'FlowManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'OptionManagement');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.Enabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.Disabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.ReSetPassword');
INSERT INTO `rolepermission` VALUES ('Role1', 'UserManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'RoleManagement.DistributeRolePermission');
INSERT INTO `rolepermission` VALUES ('Role1', 'RoleManagement.DistributeRoleUser');
INSERT INTO `rolepermission` VALUES ('Role1', 'DepartmentManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'DepartmentManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'DepartmentManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'DepartmentManagement.DistributeDepartmentUser');
INSERT INTO `rolepermission` VALUES ('Role1', 'FlowManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'FlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'MyPendingFlowManagement.Approve');
INSERT INTO `rolepermission` VALUES ('Role1', 'MyPendingFlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'MySubmitFlowManagement.Confirm');
INSERT INTO `rolepermission` VALUES ('Role1', 'MySubmitFlowManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'BuggetManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'BuggetManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'BuggetManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'BuggetManagement.BudgetAccountBill');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement.Delete');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement.SplitCost');
INSERT INTO `rolepermission` VALUES ('Role1', 'InMoneyManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.Delete');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.Confirm');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.GiveUp');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'OutMoneyManagement.Print');
INSERT INTO `rolepermission` VALUES ('Role1', 'InvoiceManagement.ImportData');
INSERT INTO `rolepermission` VALUES ('Role1', 'InvoiceManagement.Delete');
INSERT INTO `rolepermission` VALUES ('Role1', 'InvoiceManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.Enabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.Disabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'CustomerManagement.Relate');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement.New');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement.Modify');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement.Enabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement.Disabled');
INSERT INTO `rolepermission` VALUES ('Role1', 'SupplierManagement.View');
INSERT INTO `rolepermission` VALUES ('Role1', 'OptionManagement.Save');
INSERT INTO `rolepermission` VALUES ('Role1', 'VoucherNotesManagement.ImportData');
INSERT INTO `rolepermission` VALUES ('Role1', 'VoucherNotesManagement.Delete');
INSERT INTO `rolepermission` VALUES ('Role1', 'VoucherNotesManagement.View');
