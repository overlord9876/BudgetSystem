
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

alter table SupplierRelationDepartment comment '供应商关联部门';

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
create procedure Procedure_SupplierRelationDepartmentConvert() -- 创建存储过程
begin -- 开始存储过程

declare SID INT; -- 供应商ID
declare DID INT; -- 部门ID
DECLARE done INT DEFAULT FALSE; -- 自定义控制游标循环变量,默认false

DECLARE t_error INTEGER DEFAULT 0;
DECLARE My_Cursor CURSOR FOR (SELECT ID,DeptID from supplier WHERE ID not in (SELECT ID from SupplierRelationDepartment )); -- 定义游标并输入结果集
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE; -- 绑定控制变量到游标,游标循环结束自动转true
OPEN My_Cursor; -- 打开游标
  myLoop: LOOP -- 开始循环体,myLoop为自定义循环名,结束循环时用到
    FETCH My_Cursor into SID,DID; -- 将游标当前读取行的数据顺序赋予自定义变量12
    IF done THEN -- 判断是否继续循环
      LEAVE myLoop; -- 结束循环
    END IF;
    -- 自己要做的事情,在 sql 中直接使用自定义变量即可
	INSERT INTO SupplierRelationDepartment(ID,Dep_ID)VALUES(SID,DID);

  END LOOP myLoop; -- 结束自定义循环体
  CLOSE My_Cursor; -- 关闭游标
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

