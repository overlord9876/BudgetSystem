drop table if exists PaymentAccountAdjustmentDetail;
drop table if exists PaymentAccountAdjustment;
drop table if exists ReciptAccountAdjustmentDetail;
drop table if exists ReciptAccountAdjustment;
drop table if exists InvoiceAccountAdjustmentDetail;
drop table if exists InvoiceAccountAdjustment;

/*==============================================================*/
/* Table: PaymentAccountAdjustment                              */
/*==============================================================*/
create table PaymentAccountAdjustment
(
   ID                   int not null auto_increment,
   Code                 varchar(20) not null,
   Type                 int,
   BudgetID             int,
   RelationID           int,
   ExchangeRate         decimal(14,6),
   Currency             varchar(20),
   State                int comment '   入账 = 0,
                    待拆分 = 1,
                    已拆分 = 2,
                    关联合同 = 3',
   SplitCNY             decimal(14,2),
   SplitOriginalCoin    decimal(14,2),
   AlreadySplitCNY      decimal(14,2),
   AlreadySplitOriginalCoin decimal(14,2),
   UpdateDate           datetime,
   UpdateUser           varchar(30),
   CreateDate           datetime,
   CreateUser           varchar(30),
   Remark               varchar(500),
   Role                 int comment '这里的角色指的是业务员/财务 0表示业务员，财务表示财务',
   primary key (ID)
);

alter table PaymentAccountAdjustment comment '付款调账管理';

alter table PaymentAccountAdjustment add constraint FK_Reference_PAA_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table PaymentAccountAdjustment add constraint FK_Reference_PAA_PaymentNotes foreign key (RelationID)
      references PaymentNotes (ID) on delete restrict on update restrict;

/*==============================================================*/
/* Table: PaymentAccountAdjustmentDetail                        */
/*==============================================================*/
create table PaymentAccountAdjustmentDetail
(
   ID                   int not null auto_increment,
   PID                  int,
   RelationID           int not null,
   BudgetID             int not null,
   Type                 int not null,
   OriginalCoin         decimal(14,2),
   ExchangeRate         decimal(14,6),
   CNY                  decimal not null,
   Operator             varchar(30) not null,
   IsDelete             tinyint(4) default 0,
   Confirmed            tinyint(4),
   OperatorDate         datetime,
   primary key (ID)
);

alter table PaymentAccountAdjustmentDetail comment '调账详情';

alter table PaymentAccountAdjustmentDetail add constraint FK_Reference_Detail_PaymentAccountAdjustment foreign key (PID)
      references PaymentAccountAdjustment (ID) on delete restrict on update restrict;

alter table PaymentAccountAdjustmentDetail add constraint FK_Reference_PAADetail_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table PaymentAccountAdjustmentDetail add constraint FK_Reference_PAADetail_PaymentNotes foreign key (RelationID)
      references PaymentNotes (ID) on delete restrict on update restrict;

/*==============================================================*/
/* Table: ReciptAccountAdjustment                               */
/*==============================================================*/
create table ReciptAccountAdjustment
(
   ID                   int not null auto_increment,
   Code                 varchar(20) not null,
   Type                 int,
   RelationID           int,
   BudgetID             int,
   ExchangeRate         decimal(14,6),
   Currency             varchar(20),
   State                int comment '   入账 = 0,
                    待拆分 = 1,
                    已拆分 = 2,
                    关联合同 = 3',
   SplitCNY             decimal(14,2),
   SplitOriginalCoin    decimal(14,2),
   AlreadySplitOriginalCoin decimal(14,2),
   AlreadySplitCNY      decimal(14,2),
   UpdateDate           datetime,
   UpdateUser           varchar(30),
   CreateDate           datetime,
   CreateUser           varchar(30),
   Remark               varchar(500),
   Role                 int comment '这里的角色指的是业务员/财务 0表示业务员，财务表示财务',
   primary key (ID)
);

alter table ReciptAccountAdjustment comment '收款调账管理';

alter table ReciptAccountAdjustment add constraint FK_Reference_RAA_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table ReciptAccountAdjustment add constraint FK_Reference_RAA_BudgetBill foreign key (RelationID)
      references BudgetBill (ID) on delete restrict on update restrict;

/*==============================================================*/
/* Table: ReciptAccountAdjustmentDetail                         */
/*==============================================================*/
create table ReciptAccountAdjustmentDetail
(
   ID                   int not null auto_increment,
   PID                  int,
   RelationID           int not null,
   BudgetID             int not null,
   Type                 int not null,
   OriginalCoin         decimal(14,2),
   ExchangeRate         decimal(14,6),
   CNY                  decimal not null,
   Operator             varchar(30) not null,
   IsDelete             tinyint(4) default 0,
   Confirmed            tinyint(4),
   OperatorDate         datetime,
   primary key (ID)
);

alter table ReciptAccountAdjustmentDetail comment '收款调账详情';

alter table ReciptAccountAdjustmentDetail add constraint FK_Reference_Detail_ReciptAccountAdjustment foreign key (PID)
      references ReciptAccountAdjustment (ID) on delete restrict on update restrict;

alter table ReciptAccountAdjustmentDetail add constraint FK_Reference_RAADetail_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table ReciptAccountAdjustmentDetail add constraint FK_Reference_RAADetail_BudgetBill foreign key (RelationID)
      references BudgetBill (ID) on delete restrict on update restrict;

/*==============================================================*/
/* Table: InvoiceAccountAdjustment                              */
/*==============================================================*/
create table InvoiceAccountAdjustment
(
   ID                   int not null auto_increment,
   Code                 varchar(20) not null,
   Type                 int,
   RelationID           int,
   BudgetID             int,
   ExchangeRate         decimal(14,6),
   Currency             varchar(20),
   State                int comment '   入账 = 0,
                    待拆分 = 1,
                    已拆分 = 2,
                    关联合同 = 3',
   SplitCNY             decimal(14,2),
   SplitOriginalCoin    decimal(14,2),
   AlreadySplitOriginalCoin decimal(14,2),
   AlreadySplitCNY      decimal(14,2),
   AlreadySplitFeedMoney decimal(14,2),
   AlreadySplitPayment  decimal(14,2),
   AlreadySplitTaxAmount decimal(14,2),
   UpdateDate           datetime,
   UpdateUser           varchar(30),
   CreateDate           datetime,
   CreateUser           varchar(30),
   Remark               varchar(500),
   Role                 int comment '这里的角色指的是业务员/财务 0表示业务员，财务表示财务',
   primary key (ID)
);

alter table InvoiceAccountAdjustment comment '交单调账管理';

alter table InvoiceAccountAdjustment add constraint FK_Reference_IAA_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table InvoiceAccountAdjustment add constraint FK_Reference_IAA_Invoice foreign key (RelationID)
      references Invoice (ID) on delete restrict on update restrict;
/*==============================================================*/
/* Table: InvoiceAccountAdjustmentDetail                        */
/*==============================================================*/
create table InvoiceAccountAdjustmentDetail
(
   ID                   int not null auto_increment,
   PID                  int,
   RelationID           int not null,
   BudgetID             int not null,
   Type                 int not null,
   OriginalCoin         decimal(14,2),
   ExchangeRate         decimal(14,6),
   CNY                  decimal not null,
   FeedMoney            decimal(14,2),
   Payment              decimal(14,2),
   Amount               decimal(14,2),
   Operator             varchar(30) not null,
   IsDelete             tinyint(4) default 0,
   Confirmed            tinyint(4),
   OperatorDate         datetime,
   primary key (ID)
);

alter table InvoiceAccountAdjustmentDetail comment '交单调账详情';

alter table InvoiceAccountAdjustmentDetail add constraint FK_Reference_IAADetail_Budget foreign key (BudgetID)
      references Budget (ID) on delete restrict on update restrict;

alter table InvoiceAccountAdjustmentDetail add constraint FK_Reference_IAADetail_IAA foreign key (PID)
      references InvoiceAccountAdjustment (ID) on delete restrict on update restrict;

alter table InvoiceAccountAdjustmentDetail add constraint FK_Reference_IAADetail_Invoice foreign key (RelationID)
      references Invoice (ID) on delete restrict on update restrict;

ALTER TABLE PaymentAccountAdjustment ADD Role int ;
ALTER TABLE ReciptAccountAdjustment ADD Role int ;
ALTER TABLE InvoiceAccountAdjustment ADD Role int ;

UPDATE PaymentAccountAdjustment
SET Role=0;
UPDATE ReciptAccountAdjustment
SET Role=0;
UPDATE InvoiceAccountAdjustment
SET Role=0;

ALTER TABLE flowinstance MODIFY COLUMN  FlowName   varchar(20);
ALTER TABLE flownode MODIFY COLUMN  Name   varchar(20);
ALTER TABLE flow MODIFY COLUMN  Name   varchar(20);

set @Name='调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','业务员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'%StartUserDepartment%','部门经理','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,3,0,'0248','财务人员','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,4,1,'4','财务部经理','');

set @Name='修改调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','业务员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'%StartUserDepartment%','部门经理','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,3,0,'0248','财务人员','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,4,1,'4','财务部经理','');


set @Name='删除调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','业务员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'%StartUserDepartment%','部门经理','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,3,0,'0248','财务人员','');
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,4,1,'4','财务部经理','');


set @Name='财务调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','财务人员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'4','财务部经理','');

set @Name='财务修改调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','财务人员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'4','财务部经理','');


set @Name='财务删除调账审批流程';
DELETE FROM flowrunpoint WHERE InstanceID in (SELECT ID from flowinstance WHERE FlowName=@Name);
DELETE FROM flowinstance WHERE `FlowName`=@Name;
DELETE FROM flownode WHERE `Name`=@Name;
DELETE FROM flow WHERE `Name`=@Name;
INSERT INTO Flow(`Name`,`VersionNumber`,`CreateUser`,`UpdateDate`,`IsEnabled`) VALUES(@Name,1,'admin',NOW(),1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`,IsStartNode)
            VALUES(@Name,1,1,0,'%StartUser%','财务人员','',1);
INSERT INTO flownode(`Name`,`VersionNumber`,`OrderNo`,`NodeConfig`,`NodeValue`,`NodeValueRemark`,`NodeExtEvent`)
            VALUES(@Name,1,2,1,'4','财务部经理','');
