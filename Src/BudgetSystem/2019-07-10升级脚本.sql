
/*===================================================================*/
/*  ������ˮ�����Ӳ����Ϣ��                                         */
/*===================================================================*/
ALTER TABLE BankSlip add COLUMN  SplitInfo            varchar(1024) comment '�����Ϣ';  

insert into flow(NAME,VersionNumber,CreateUser,UpdateDate,remark,isenabled)
select '�����޸���������',VersionNumber,CreateUser,UpdateDate,remark,isenabled from flow where `Name`= '�������޸�������';

UPDATE flowinstance set FlowName='�����޸���������' where FlowName='�������޸�������';

UPDATE flownode set `Name`='�����޸���������'  where `Name`='�������޸�������';

DELETE FROM flow where  `Name`= '�������޸�������';