
DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN
IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'SupplierRelationDepartment') THEN

/*==============================================================*/
/* Table: SupplierRelationDepartment                            */
/*==============================================================*/
create table SupplierRelationDepartment
(
   ID                   int not null,
   Dep_ID               int not null,
   primary key (ID, Dep_ID)
);

alter table SupplierRelationDepartment comment '��Ӧ�̹�������';

alter table SupplierRelationDepartment add constraint FK_Reference_SupplierRelationDepartment_Department foreign key (Dep_ID)
      references Department (ID) on delete restrict on update restrict;

alter table SupplierRelationDepartment add constraint FK_Reference_SupplierRelationDepartment_Supplier foreign key (ID)
      references Supplier (ID) on delete restrict on update restrict;

END IF; 

END??
DELIMITER ;
CALL schema_change();


DELIMITER $$
DROP PROCEDURE IF EXISTS Procedure_SupplierRelationDepartmentConvert$$
create procedure Procedure_SupplierRelationDepartmentConvert() -- �����洢����
begin -- ��ʼ�洢����

declare SID INT; -- ��Ӧ��ID
declare DID INT; -- ����ID
DECLARE done INT DEFAULT FALSE; -- �Զ�������α�ѭ������,Ĭ��false

DECLARE t_error INTEGER DEFAULT 0;
DECLARE My_Cursor CURSOR FOR (SELECT ID,DeptID from supplier WHERE ID not in (SELECT ID from SupplierRelationDepartment )); -- �����α겢��������
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE; -- �󶨿��Ʊ������α�,�α�ѭ�������Զ�תtrue
OPEN My_Cursor; -- ���α�
  myLoop: LOOP -- ��ʼѭ����,myLoopΪ�Զ���ѭ����,����ѭ��ʱ�õ�
    FETCH My_Cursor into SID,DID; -- ���α굱ǰ��ȡ�е�����˳�����Զ������12
    IF done THEN -- �ж��Ƿ����ѭ��
      LEAVE myLoop; -- ����ѭ��
    END IF;
    -- �Լ�Ҫ��������,�� sql ��ֱ��ʹ���Զ����������
	INSERT INTO SupplierRelationDepartment(ID,Dep_ID)VALUES(SID,DID);

  END LOOP myLoop; -- �����Զ���ѭ����
  CLOSE My_Cursor; -- �ر��α�
END $$
DELIMITER ;
CALL Procedure_SupplierRelationDepartmentConvert();  

DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN
IF EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'Supplier' AND column_name = 'DeptID') THEN

ALTER TABLE supplier
drop column DeptID;
END IF; 

END??
DELIMITER ;
CALL schema_change();

