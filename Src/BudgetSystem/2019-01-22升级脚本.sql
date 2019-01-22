update budget set state='0';

alter table budget modify State int;

insert into rolepermission(RoleCode,Permission) values('YWY','BuggetManagement.ClosingAccountApply');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.RejectedAccount');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.FinancialArchiveApply');
insert into rolepermission(RoleCode,Permission) values('CW','BuggetManagement.Archive');