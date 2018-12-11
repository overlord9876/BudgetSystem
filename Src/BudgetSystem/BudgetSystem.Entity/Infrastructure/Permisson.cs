﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetSystem.Entity
{
    public class Permisson
    {

        public Permisson()
        {

        }

        public Permisson(BusinessModules module, OperateTypes operate, string displayName, int displayOrder)
        {

            this.Module = module;
            this.Operate = operate;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
        }


        public BusinessModules Module
        {
            get;
            set;
        }

        public OperateTypes Operate
        {
            get;
            set;
        }


        public string DisplayName
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public string Code
        {
            get
            {
                if (Operate == OperateTypes.None || Operate == OperateTypes.CommonQuery || Operate == OperateTypes.MyQuery || Operate == OperateTypes.CustomQuery || Operate == OperateTypes.QueryManager)
                {
                    return this.Module.ToString();
                }
                else
                {
                    return this.Module + "." + this.Operate;
                }
            }
        }


        private static List<Permisson> allPermission = null;

        public static List<Permisson> Permissions
        {
            get
            {
                if (allPermission == null)
                {
                    allPermission = new List<Permisson>() 
                    { 
                        new Permisson(BusinessModules.UserManagement, OperateTypes.None,"用户管理模块",100),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.New,"用户管理-新增用户",110),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Modify,"用户管理-修改用户",120),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Enabled,"用户管理-启动用户",130),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.Disabled,"用户管理-停用用户",140),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.ReSetPassword,"用户管理-重置密码",150),
                        new Permisson(BusinessModules.UserManagement, OperateTypes.View,"用户管理-查看用户详情",160),

                        new Permisson(BusinessModules.RoleManagement, OperateTypes.None,"角色管理模块",200),
                        new Permisson(BusinessModules.RoleManagement, OperateTypes.DistributeRolePermission,"角色管理-分配权限",210),
                        new Permisson(BusinessModules.RoleManagement, OperateTypes.DistributeRoleUser,"角色管理-分配用户",220),
                
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.None,"部门管理模块",300),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.New,"部门管理-新增部门",310),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.Modify,"部门管理-修改部门",320),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.View,"部门管理-查看部门",330),
                        new Permisson(BusinessModules.DepartmentManagement, OperateTypes.DistributeDepartmentUser,"部门管理-分配部门用户",340),


                        new Permisson(BusinessModules.FlowManagement, OperateTypes.None,"流程管理模块",400),
                        new Permisson(BusinessModules.FlowManagement, OperateTypes.Modify,"流程管理-修改流程",410),
                        new Permisson(BusinessModules.FlowManagement, OperateTypes.View,"流程管理-查看流程",420),

                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.None,"我的待审批流程",500),
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.Approve,"我的待审批流程-审批",510),
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.BatchApprove,"我的待审批流程-批量审批",515),
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.View,"我的待审批流程-查看",520),

                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.None,"我提交的流程",600),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.Confirm,"我提交的流程-确认",610),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.Revoke,"我提交的流程-撤回",620),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.View,"我提交的流程-查看",630),

                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.None,"预算单管理模块",700),

                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.New,"预算单管理-新增预算单",710),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Modify,"预算单管理-修改预算单",720),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Delete, "预算单管理-删除预算单",730),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Close,"预算单管理-关闭预算单",740),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.DeleteApply,"预算单管理-申请删除",740),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.ModifyApply, "预算单管理-申请修改",750),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.View,"预算单管理-查看预算单",760),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.ViewApply, "预算单管理-查看审批状态",770),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.BudgetAccountBill,"预算单管理-查看收支情况",780),
                        //new Permisson(BusinessModules.BuggetManagement,OperateTypes.Print,"预算单管理-打印预算单",790),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.SubmitApply,"预算单管理-提交审批流程",791),

                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.None,"收款管理模块",800),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.New, "收款管理-新增银行水单",810),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.Modify, "收款管理-修改银行水单",820),
                        //new Permisson(BusinessModules.InMoneyManagement,OperateTypes.Delete, "收款管理-删除入账",830),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.SplitCost, "收款管理-费用拆分",840),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.View, "收款管理-查看详情",850),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.ModifyApply, "收款管理-申请修改费用拆分",860),    
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.Confirm, "收款管理-收汇确认",870),                        
                       
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.None,"付款管理模块",900),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.New, "付款管理-付款申请",910),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Modify, "付款管理-修改付款",920),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Delete, "付款管理-删除付款",930),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.ViewMoneyDetail, "付款管理-用款查询",940),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.SubmitApply, "付款管理-提交付款申请",950),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.View, "付款管理-查看详情",960),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Print,"付款管理-打印",970), 
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Confirm,"付款管理-确认付款",980), 

                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.None,"交单管理模块",1000),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.New,"交单管理-新增交单记录",1010),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.Modify,"交单管理-修改交单记录",1020),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.ImportData, "交单管理-部门导入交单记录",1030),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.ImportData2, "交单管理-财务导入认证记录",1040),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.View, "交单管理-查看详情",1050),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.ExportData, "交单管理-导出交单记录",1060),

                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.None,"报关单管理模块",1100),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.New, "报关单管理-新增报关单",1110),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.ImportData, "报关单管理-导入报关单",1120),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.Delete, "报关单管理-删除报关单",1130),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.View, "报关单管理-查看报关单",1140),

                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.None,"客户管理模块",1200),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.New,"客户管理-新增客户",1210),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Modify,"客户管理-修改客户",1220),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Enabled,"客户管理-启用客户",1230),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Disabled,"客户管理-停用客户",1240),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.View,"客户管理-查看详情",1250),
            
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.None,"供应商管理模块",1300),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.New,"供应商管理-新增供应商",1310),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Modify,"供应商管理-修改供应商",1320),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Enabled,"供应商管理-启用供应商",1330),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Disabled,"供应商管理-停用供应商",1340),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.View,"供应商管理-查看详情",1350),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.SubmitApply,"供应商管理-提交审批申请",1360),
            
                        new Permisson(BusinessModules.OptionManagement,OperateTypes.None,"选项管理模块",1400),
                        new Permisson(BusinessModules.OptionManagement,OperateTypes.Save,"选项管理-维护选项",1410),

                        new Permisson(BusinessModules.BudgetReport,OperateTypes.None,"预算单报表",1500),
                        new Permisson(BusinessModules.InMoneyReport,OperateTypes.None,"收款报表",1600),
                        new Permisson(BusinessModules.OutMoneyReport,OperateTypes.None,"付款报表",1700),
           
                    };
                }
                return allPermission;
            }

        }

        public static Permisson GetPermission(string permission)
        {
            foreach (var p in Permissions)
            {
                if (p.Code == permission)
                {
                    return p;
                }
            }
            return null;
        }
    }



}
