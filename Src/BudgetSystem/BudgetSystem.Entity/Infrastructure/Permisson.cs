using System;
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
                if (Operate == OperateTypes.None || Operate == OperateTypes.CommonQuery || Operate == OperateTypes.MyQuery)
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
                        new Permisson(BusinessModules.MyPendingFlowManagement, OperateTypes.View,"我的待审批流程-查看",520),

                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.None,"我提交的流程",600),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.Confirm,"我提交的流程-确认",610),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.Revoke,"我提交的流程-撤回",620),
                        new Permisson(BusinessModules.MySubmitFlowManagement, OperateTypes.View,"我提交的流程-查看",630),

                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.None,"预算单管理模块",700),

                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.New,"预算单管理-新增预算单",710),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Modify,"预算单管理-修改预算单",720),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Delete, "预算单管理-删除预算单",730),
                        //new Permisson(BusinessModules.BuggetManagement,OperateTypes.Close,"预算单管理-",740),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Revoke, "预算单管理-申请修改",750),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.View,"预算单管理-查看预算单",760),
                        //new Permisson(BusinessModules.BuggetManagement,OperateTypes.View, "预算单管理-查看审批状态",770),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.BudgetAccountBill,"预算单管理-查看收支情况",780),
                        //new Permisson(BusinessModules.BuggetManagement,OperateTypes.Print,"预算单管理-打印预算单",790),
                        new Permisson(BusinessModules.BuggetManagement,OperateTypes.Confirm,"预算单管理-提交审批流程",791),

                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.None,"收款管理模块",800),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.New, "收款管理-新增入账",810),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.Modify, "收款管理-分拆至合同",820),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.Delete, "收款管理-删除入账",830),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.SplitCost, "收款管理-费用拆分",840),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.View, "收款管理-查看详情",850),
                        new Permisson(BusinessModules.InMoneyManagement,OperateTypes.SplitRequest, "收款管理-费用拆分",860),
                       
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.None,"付款管理模块",900),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.New, "付款管理-付款申请",910),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Modify, "付款管理-修改付款申请",920),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Delete, "付款管理-删除付款申请",930),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Confirm, "付款管理-确认已付款",940),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.GiveUp, "付款管理-放弃付款",950),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.View, "付款管理-查看详情",960),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.View, "付款管理-查看审批记录",970),
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Print,"付款管理-打印",980), 
                        new Permisson(BusinessModules.OutMoneyManagement,OperateTypes.Confirm,"付款管理-确认已付款",980), 

                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.None,"开票管理模块",1000),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.New,"开票管理-新增开票记录",1010),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.Modify,"开票管理-修改开票记录",1020),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.ImportData, "开票管理-部门导入开票记录",1030),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.ImportData2, "开票管理-财务导入开票记录",1040),
                        new Permisson(BusinessModules.InvoiceManagement,OperateTypes.View, "开票管理-查看详情",1050),

                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.None,"付款凭证管理模块",1100),
                        //new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.New, "付款凭证管理-新增付款凭证",1110),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.ImportData, "付款凭证管理-导入付款凭证",1120),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.Delete, "付款凭证管理-删除付款凭证",1130),
                        new Permisson(BusinessModules.VoucherNotesManagement,OperateTypes.View, "付款凭证管理-查看付款凭证",1140),

                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.None,"客户管理模块",1200),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.New,"客户管理-新增客户",1210),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Modify,"客户管理-修改客户",1220),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Enabled,"客户管理-启用客户",1230),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Disabled,"客户管理-停用客户",1240),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.View,"客户管理-查看详情",1250),
                        new Permisson(BusinessModules.CustomerManagement,OperateTypes.Relate,"客户管理-业务员维护",1260),
            
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.None,"供应商管理模块",1300),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.New,"供应商管理-新增供应商",1310),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Modify,"供应商管理-修改供应商",1320),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Enabled,"供应商管理-启用供应商",1330),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.Disabled,"供应商管理-停用供应商",1340),
                        new Permisson(BusinessModules.SupplierManagement,OperateTypes.View,"供应商管理-查看详情",1350),
            
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
