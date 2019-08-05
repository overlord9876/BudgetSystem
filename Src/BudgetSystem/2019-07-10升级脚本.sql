
/*===================================================================*/
/*  银行流水表增加拆分信息列                                         */
/*===================================================================*/
ALTER TABLE BankSlip add COLUMN  SplitInfo            varchar(1024) comment '拆分信息';  

insert into flow(NAME,VersionNumber,CreateUser,UpdateDate,remark,isenabled)
select '入账修改审批流程',VersionNumber,CreateUser,UpdateDate,remark,isenabled from flow where `Name`= '入账审修改批流程';

UPDATE flowinstance set FlowName='入账修改审批流程' where FlowName='入账审修改批流程';

UPDATE flownode set `Name`='入账修改审批流程'  where `Name`='入账审修改批流程';

DELETE FROM flow where  `Name`= '入账审修改批流程';