
/*===================================================================*/
/*  审批表增加发起流程描述字段     */
/*===================================================================*/
ALTER TABLE FlowInstance add COLUMN  `Description`       text comment '发起流程备注';

/*===================================================================*/
/*  修改预算单状态为0的数据      */
/*===================================================================*/
UPDATE  Budget SET `State`=1 WHERE `State`=0;
UPDATE  Budget SET Validity=NULL WHERE `Validity`='0001-01-01 00:00:00';


/*===================================================================*/
/*  供应商表删除是否存在代理协议字段，新增代理类型字段               */
/*===================================================================*/
DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN
IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'Supplier' AND column_name = 'AgentType') THEN
    ALTER TABLE Supplier ADD COLUMN  AgentType            smallint default 0 comment '代理类型';
		UPDATE  Supplier  SET AgentType=1 WHERE ExistsAgentAgreement=1;
    ALTER TABLE supplier DROP COLUMN ExistsAgentAgreement;
END IF; 

END??
DELIMITER ;
CALL schema_change();



