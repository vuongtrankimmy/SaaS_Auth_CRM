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

namespace QueryService.Features.Pages.v1.Hr
{
    public interface IHrQuery
    {
        IAccountQuery AccountQuery {  get; }
        IAttendanceQuery AttendanceQuery {  get; }
        IBonusQuery BonusQuery {  get; }
        IComponentQuery ComponentQuery {  get; }
        IDepartmentQuery DepartmentQuery {  get; }
        IDesignTokenQuery DesignTokenQuery {  get; }
        IEmployeeQuery EmployeeQuery {  get; }
        IInsuranceQuery InsuranceQuery {  get; }
        IKPIQuery KPIQuery {  get; }
        ILeaveQuery LeaveQuery {  get; }
        IPayrollQuery PayrollQuery {  get; }
        IPenaltyQuery PenaltyQuery {  get; }
        IPerformanceQuery PerformanceQuery {  get; }
        IPositionQuery PositionQuery {  get; }
        IPromotionQuery PromotionQuery {  get; }
        IRoleQuery RoleQuery {  get; }
        ISalaryQuery SalaryQuery {  get; }
        ITaxQuery TaxQuery {  get; }
        ITenantQuery TenantQuery {  get; }
        IThemeQuery ThemeQuery {  get; }
        ITrainingQuery TrainingQuery {  get; }
    }
}
