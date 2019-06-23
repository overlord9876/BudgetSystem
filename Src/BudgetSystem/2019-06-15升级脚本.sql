
/*===================================================================*/
/*  ���������ӷ������������ֶ�     */
/*===================================================================*/
ALTER TABLE FlowInstance add COLUMN  `Description`       text comment '�������̱�ע';

/*===================================================================*/
/*  �޸�Ԥ�㵥״̬Ϊ0������      */
/*===================================================================*/
UPDATE  Budget SET `State`=1 WHERE `State`=0;
UPDATE  Budget SET Validity=NULL WHERE `Validity`='0001-01-01 00:00:00';


/*===================================================================*/
/*  ��Ӧ�̱�ɾ���Ƿ���ڴ���Э���ֶΣ��������������ֶ�               */
/*===================================================================*/
DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN
IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'Supplier' AND column_name = 'AgentType') THEN
    ALTER TABLE Supplier ADD COLUMN  AgentType            smallint default 0 comment '��������';
		UPDATE  Supplier  SET AgentType=1 WHERE ExistsAgentAgreement=1;
    ALTER TABLE supplier DROP COLUMN ExistsAgentAgreement;
END IF; 

END??
DELIMITER ;
CALL schema_change();



