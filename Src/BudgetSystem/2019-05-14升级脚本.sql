
/*==============================================================*/
/*  预算单表新增归档征求日期和归档日期列			                      */
/*==============================================================*/

ALTER TABLE Budget add COLUMN ArchiveApplyDate     datetime comment '归档征求日期';
ALTER TABLE Budget add COLUMN ArchiveDate          datetime comment '归档日期';

-- 变更状态枚举值 
UPDATE budget SET `State`=8 WHERE `State`=3;
UPDATE budget SET `State`=4 WHERE `State`=2;
UPDATE budget SET `State`=2 WHERE `State`=1;
UPDATE budget SET `State`=1 WHERE `State`=0;

--更改客户名称为ID2019-05-16

DELIMITER $$
DROP PROCEDURE IF EXISTS Procedure_BankSlipCustomerConvert$$
create procedure Procedure_BankSlipCustomerConvert() -- 创建存储过程
begin -- 开始存储过程

declare customerID INT; -- 自定义变量1
declare customerName varchar(300); -- 自定义变量1
DECLARE done INT DEFAULT FALSE; -- 自定义控制游标循环变量,默认false

DECLARE t_error INTEGER DEFAULT 0;
DECLARE My_Cursor CURSOR FOR (SELECT ID,`Name` from customer); -- 定义游标并输入结果集
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE; -- 绑定控制变量到游标,游标循环结束自动转true
OPEN My_Cursor; -- 打开游标
  myLoop: LOOP -- 开始循环体,myLoop为自定义循环名,结束循环时用到
    FETCH My_Cursor into customerID,customerName; -- 将游标当前读取行的数据顺序赋予自定义变量12
    IF done THEN -- 判断是否继续循环
      LEAVE myLoop; -- 结束循环
    END IF;
    -- 自己要做的事情,在 sql 中直接使用自定义变量即可
	UPDATE bankslip set Cus_ID=customerID WHERE Remitter like customerName;

  END LOOP myLoop; -- 结束自定义循环体
  CLOSE My_Cursor; -- 关闭游标
END $$
DELIMITER ;
CALL Procedure_BankSlipCustomerConvert();  

alter table BankSlip add constraint FK_Reference_BankSlip_Customer foreign key (Cus_ID)
      references Customer (ID) on delete restrict on update restrict;
