update budget set state='0';

alter table budget modify State int;

insert into rolepermission(RoleCode,Permission) values('YWY','BuggetManagement.ClosingAccountApply');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.RejectedAccount');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.FinancialArchiveApply');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.Archive');

alter table customer convert to character set utf8mb4 collate utf8mb4_bin

--���Ŀͻ�����ΪID2019-05-13

DELIMITER $$
DROP PROCEDURE IF EXISTS Procedure_BankSlipCustomerConvert$$
create procedure Procedure_BankSlipCustomerConvert() -- �����洢����
begin -- ��ʼ�洢����

declare customerID INT; -- �Զ������1
declare customerName varchar(300); -- �Զ������1
DECLARE done INT DEFAULT FALSE; -- �Զ�������α�ѭ������,Ĭ��false

DECLARE t_error INTEGER DEFAULT 0;
DECLARE My_Cursor CURSOR FOR (SELECT ID,`Name` from customer); -- �����α겢��������
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE; -- �󶨿��Ʊ������α�,�α�ѭ�������Զ�תtrue
OPEN My_Cursor; -- ���α�
  myLoop: LOOP -- ��ʼѭ����,myLoopΪ�Զ���ѭ����,����ѭ��ʱ�õ�
    FETCH My_Cursor into customerID,customerName; -- ���α굱ǰ��ȡ�е�����˳�����Զ������12
    IF done THEN -- �ж��Ƿ����ѭ��
      LEAVE myLoop; -- ����ѭ��
    END IF;
    -- �Լ�Ҫ��������,�� sql ��ֱ��ʹ���Զ����������
	UPDATE bankslip set Cus_ID=customerID WHERE Remitter like customerName;

  END LOOP myLoop; -- �����Զ���ѭ����
  CLOSE My_Cursor; -- �ر��α�
END $$
DELIMITER ;
CALL Procedure_BankSlipCustomerConvert();  

alter table BankSlip add constraint FK_Reference_BankSlip_Customer foreign key (Cus_ID)
      references Customer (ID) on delete restrict on update restrict;
