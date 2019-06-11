
/*===================================================================*/
/*  ��Ӧ�̱������������ڡ�Ӫҵִ�ո�ӡ�����������ݡ����������ֶ�     */
/*===================================================================*/

ALTER TABLE Supplier add COLUMN  ReviewDate           datetime comment '��������';
ALTER TABLE Supplier add COLUMN  ExistsLicenseCopy    bit default 0 comment 'Ӫҵִ�ո�ӡ��';
ALTER TABLE Supplier add COLUMN  FirstReviewContents  text comment '��������';
ALTER TABLE Supplier add COLUMN  ReviewContents       text comment '��������';

-- ����ؽ�ɫ��Ӳ鿴������ʷ��¼Ȩ��
INSERT INTO RolePermission(RoleCode,Permission)Values('GeneralManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('FinancialAssistantManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('CWRY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('SupplierApproval','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('BMYWY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('FinanceManager','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('YWY','SupplierManagement.ViewApply');
INSERT INTO RolePermission(RoleCode,Permission)Values('Default','SupplierManagement.ViewApply');
-- ����ؽ�ɫ��ӹ�Ӧ�̸�������Ȩ��
INSERT INTO RolePermission(RoleCode,Permission)Values('GeneralManager','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('SupplierApproval','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('BMYWY','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('YWY','SupplierManagement.Approve');
INSERT INTO RolePermission(RoleCode,Permission)Values('Default','SupplierManagement.Approve');

-- �޸���������
DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN 
DECLARE lastVersionNumber INT DEFAULT 0;
SELECT VersionNumber INTO lastVersionNumber FROM Flow WHERE `Name`='��Ӧ����������' AND IsEnabled=1;
UPDATE Flow SET IsEnabled=0 WHERE `Name`='��Ӧ����������' ;
SET  lastVersionNumber=lastVersionNumber+1;
-- �޸Ĺ�Ӧ����������
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES('��Ӧ����������',lastVersionNumber,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('��Ӧ����������',lastVersionNumber,1,1,'%StartUserDepartment%','���ž���','��Ӧ�̳����ž�������');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('��Ӧ����������',lastVersionNumber,2,0,'0150','ó�ܲ�������','��Ӧ�̳���ó�ܲ�����');

-- ������Ӧ�̸�������
DELETE FROM flownode WHERE `Name`='��Ӧ�̸�������';
DELETE FROM flow WHERE `Name`='��Ӧ�̸�������';
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES('��Ӧ�̸�������',1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('��Ӧ�̸�������',1,1,1,'%StartUserDepartment%','���ž���','��Ӧ�̸����ž�������');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES('��Ӧ�̸�������',1,2,0,'0150','ó�ܲ�������','��Ӧ�̸���ó�ܲ�����');

END??
DELIMITER ;
CALL schema_change();
 
-- �޸�ModifyMark �� DateItemType ����
alter table ModifyMark modify column DateItemType varchar(60) not null comment '��������';
 