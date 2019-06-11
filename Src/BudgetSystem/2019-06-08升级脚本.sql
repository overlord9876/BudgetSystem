
/*===================================================================*/
/*  供应商表增加年审日期、营业执照复印件、初审内容、复审内容字段     */
/*===================================================================*/

ALTER TABLE Supplier add COLUMN  ReviewDate           datetime comment '年审日期';
ALTER TABLE Supplier add COLUMN  ExistsLicenseCopy    bit default 0 comment '营业执照复印件';
ALTER TABLE Supplier add COLUMN  FirstReviewContents  text comment '初审内容';
ALTER TABLE Supplier add COLUMN  ReviewContents       text comment '复审内容';

-- 给相关角色添加查看复评历史记录权限
INSERT INTO RolePermission(RoleCode,Permission)Values('GeneralManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('FinancialAssistantManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('CWRY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('SupplierApproval','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('BMYWY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('FinanceManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('YWY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('Default','SupplierManagement.ViewApply');
-- 给相关角色添加供应商复评申请权限
INSERT INTO RolePermission(RoleCode,Permission)Values('GeneralManager','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('SupplierApproval','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('BMYWY','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('YWY','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('Default','SupplierManagement.Approve');

-- 修改审批流程
DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN 
DECLARE lastVersionNumber INT DEFAULT 0;
SELECT VersionNumber INTO lastVersionNumber FROM Flow WHERE `Name`='供应商审批流程' AND IsEnabled=1;
UPDATE Flow SET IsEnabled=0 WHERE `Name`='供应商审批流程' ;
SET  lastVersionNumber=lastVersionNumber+1;
-- 修改供应商审批流程
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES('供应商审批流程',lastVersionNumber,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('供应商审批流程',lastVersionNumber,1,1,'%StartUserDepartment%','部门经理','供应商初审部门经理审批');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('供应商审批流程',lastVersionNumber,2,0,'0150','贸管部审批人','供应商初审贸管部审批');

-- 新增供应商复审流程
DELETE FROM flownode WHERE `Name`='供应商复审流程';
DELETE FROM flow WHERE `Name`='供应商复审流程';
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES('供应商复审流程',1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('供应商复审流程',1,1,1,'%StartUserDepartment%','部门经理','供应商复审部门经理审批');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('供应商复审流程',1,2,0,'0150','贸管部审批人','供应商复审贸管部审批');

END??
DELIMITER ;
CALL schema_change();
 
-- 修改ModifyMark 表 DateItemType 长度
alter table ModifyMark modify column DateItemType varchar(60) not null comment '数据类型';
 