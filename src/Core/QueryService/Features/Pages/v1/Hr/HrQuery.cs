
using QueryService.Features.Pages.v1.Hr.Account;
using QueryService.Features.Pages.v1.Hr.Attendance;
using QueryService.Features.Pages.v1.Hr.Bonus;
using QueryService.Features.Pages.v1.Hr.Component;
using QueryService.Features.Pages.v1.Hr.Department;
using QueryService.Features.Pages.v1.Hr.DesignToken;
using QueryService.Features.Pages.v1.Hr.Employee;
using QueryService.Features.Pages.v1.Hr.Insurance;
using QueryService.Features.Pages.v1.Hr.KPI;
using QueryService.Features.Pages.v1.Hr.Leave;
using QueryService.Features.Pages.v1.Hr.Payroll;
using QueryService.Features.Pages.v1.Hr.Penalty;
using QueryService.Features.Pages.v1.Hr.Performance;
using QueryService.Features.Pages.v1.Hr.Position;
using QueryService.Features.Pages.v1.Hr.Promotion;
using QueryService.Features.Pages.v1.Hr.Role;
using QueryService.Features.Pages.v1.Hr.Salary;
using QueryService.Features.Pages.v1.Hr.Tax;
using QueryService.Features.Pages.v1.Hr.Tenant;
using QueryService.Features.Pages.v1.Hr.Theme;
using QueryService.Features.Pages.v1.Hr.Training;
using Repositories.Repository;

namespace QueryService.Features.Pages.v1.Hr
{
    public class HrQuery(IQueryRepository? _queryRepository) : IHrQuery
    {
        public IAccountQuery AccountQuery => accountQuery ??= new AccountQuery(_queryRepository);
        IAccountQuery? accountQuery;
        public IAttendanceQuery AttendanceQuery => attendanceQuery ??= new AttendanceQuery(_queryRepository);
        IAttendanceQuery? attendanceQuery;
        public IBonusQuery BonusQuery => bonusQuery ??= new BonusQuery(_queryRepository);
        IBonusQuery? bonusQuery;
        public IComponentQuery ComponentQuery => componentQuery ??= new ComponentQuery(_queryRepository);
        IComponentQuery? componentQuery;
        public IDepartmentQuery DepartmentQuery => departmentQuery ??= new DepartmentQuery(_queryRepository);
        IDepartmentQuery? departmentQuery;
        public IDesignTokenQuery DesignTokenQuery => designTokenQuery ??= new DesignTokenQuery(_queryRepository);
        IDesignTokenQuery? designTokenQuery;
        public IEmployeeQuery EmployeeQuery => employeeQuery ??= new EmployeeQuery(_queryRepository);
        IEmployeeQuery? employeeQuery;
        public IInsuranceQuery InsuranceQuery => insuranceQuery ??= new InsuranceQuery(_queryRepository);
        IInsuranceQuery? insuranceQuery;
        public IKPIQuery KPIQuery => kpiQuery ??= new KPIQuery(_queryRepository);
        IKPIQuery? kpiQuery;
        public ILeaveQuery LeaveQuery => leaveQuery ??= new LeaveQuery(_queryRepository);
        ILeaveQuery? leaveQuery;
        public IPayrollQuery PayrollQuery => payrollQuery ??= new PayrollQuery(_queryRepository);
        IPayrollQuery? payrollQuery;
        public IPenaltyQuery PenaltyQuery => penaltyQuery ??= new PenaltyQuery(_queryRepository);
        IPenaltyQuery? penaltyQuery;
        public IPerformanceQuery PerformanceQuery => performanceQuery ??= new PerformanceQuery(_queryRepository);
        IPerformanceQuery? performanceQuery;
        public IPositionQuery PositionQuery => positionQuery ??= new PositionQuery(_queryRepository);
        IPositionQuery? positionQuery;

        public IPromotionQuery PromotionQuery => promotionQuery ??= new PromotionQuery(_queryRepository);
        IPromotionQuery? promotionQuery;
        public IRoleQuery RoleQuery => roleQuery ??= new RoleQuery(_queryRepository);
        IRoleQuery? roleQuery;
        public ISalaryQuery SalaryQuery => salaryQuery ??= new SalaryQuery(_queryRepository);
        ISalaryQuery? salaryQuery;
        public ITaxQuery TaxQuery => taxQuery ??= new TaxQuery(_queryRepository);
        ITaxQuery? taxQuery;
        public ITenantQuery TenantQuery => tenantQuery ??= new TenantQuery(_queryRepository);
        ITenantQuery? tenantQuery;
        public IThemeQuery ThemeQuery => themeQuery ??= new ThemeQuery(_queryRepository);
        IThemeQuery? themeQuery;
        public ITrainingQuery TrainingQuery => trainingQuery ??= new TrainingQuery(_queryRepository);
        ITrainingQuery? trainingQuery;
    }
}
