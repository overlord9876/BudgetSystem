
/*==============================================================*/
/*					by zxj					                      */
/*==============================================================*/


DELIMITER ??
DROP PROCEDURE IF EXISTS schema_change??
CREATE PROCEDURE schema_change()
BEGIN
IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'BankSlip' AND column_name = 'OriginalCoin2') THEN
    ALTER TABLE BankSlip ADD COLUMN OriginalCoin2 DECIMAL null;
		ALTER TABLE BankSlip ADD COLUMN NatureOfMoney varchar(30) null;
END IF; 

IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'BudgetBill' AND column_name = 'Cus_ID') THEN
    ALTER TABLE BudgetBill ADD COLUMN Cus_ID INT null;

alter table BudgetBill add constraint FK_Reference_BudgetBill_Customer foreign key (Cus_ID)
      references Customer (ID) on delete restrict on update restrict;

END IF; 

END??
DELIMITER ;
CALL schema_change();
