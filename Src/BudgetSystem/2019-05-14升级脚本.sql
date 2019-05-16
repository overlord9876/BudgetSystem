
/*==============================================================*/
/*  Ԥ�㵥�������鵵�������ں͹鵵������			                      */
/*==============================================================*/

ALTER TABLE Budget add COLUMN ArchiveApplyDate     datetime comment '�鵵��������';
ALTER TABLE Budget add COLUMN ArchiveDate          datetime comment '�鵵����';

-- ���״̬ö��ֵ 
UPDATE budget SET `State`=8 WHERE `State`=3;
UPDATE budget SET `State`=4 WHERE `State`=2;
UPDATE budget SET `State`=2 WHERE `State`=1;
UPDATE budget SET `State`=1 WHERE `State`=0;

--���Ŀͻ�����ΪID2019-05-16

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
