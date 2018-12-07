
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

IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'Customer' AND column_name = 'Code') THEN
    ALTER TABLE Customer ADD COLUMN `Code` varchar(30)  null; 
    ALTER TABLE Customer ADD COLUMN  Email                varchar(50)  null;
    ALTER TABLE Customer ADD COLUMN  Address              varchar(256) null;
    ALTER TABLE Customer ADD COLUMN  `Port`                 varchar(128) null;
    ALTER TABLE Customer ADD COLUMN  Contacts        varchar(50) null;
END IF; 


IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'Budget' AND column_name = 'VATRate') THEN
    ALTER TABLE Budget ADD COLUMN VATRate  decimal(10,2) default 16;
END IF;

IF NOT EXISTS (SELECT * FROM information_schema.columns WHERE table_schema = DATABASE()  AND table_name = 'PaymentNotes' AND column_name = 'BankName') THEN
    ALTER TABLE PaymentNotes ADD COLUMN  BankName             varchar(100) default '';
	ALTER TABLE PaymentNotes  ADD COLUMN  BankNO               varchar(30) default '';
END IF;

ALTER TABLE 	bankslip	 modify  COLUMN 	OriginalCoin	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	bankslip	 modify  COLUMN 	CNY	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	bankslip	 modify  COLUMN 	ExchangeRate     float(8,6) DEFAULT 0;
ALTER TABLE 	bankslip	 modify  COLUMN 	CNY2	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	bankslip	 modify  COLUMN 	OriginalCoin2	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	USDTotalAmount	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	TotalAmount	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	AdvancePayment	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	Commission	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	Premium	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	BankCharges	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	DirectCosts	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	FeedMoney	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	TaxRebate	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	PurchasePrice	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	Profit	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	ProfitLevel1	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	ProfitLevel2	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budget	 modify  COLUMN 	VATRate	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budgetbill	 modify  COLUMN 	OriginalCoin	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	budgetbill	 modify  COLUMN 	CNY	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	declarationform	 modify  COLUMN 	ExportAmount	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	invoice	 modify  COLUMN 	OriginalCoin	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	invoice	 modify  COLUMN 	Commission	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	invoice	 modify  COLUMN 	FeedMoney	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	invoice	 modify  COLUMN 	Payment	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	invoice	 modify  COLUMN 	TaxAmount	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	paymentnotes	 modify  COLUMN 	OriginalCoin	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	paymentnotes	 modify  COLUMN 	ExchangeRate     float(8,6) DEFAULT 0;
ALTER TABLE 	paymentnotes	 modify  COLUMN 	CNY	 decimal(14,2) DEFAULT 0;
ALTER TABLE 	paymentnotes	 modify  COLUMN 	VatOption	 decimal(14,2) DEFAULT 0;
REPLACE Into `SystemConfig` (`Name`, `Value`) VALUES ('年利率', 4.8);
REPLACE Into `SystemConfig` (`Name`, `Value`) VALUES ('退税率', 16); 

END??
DELIMITER ;
CALL schema_change();
