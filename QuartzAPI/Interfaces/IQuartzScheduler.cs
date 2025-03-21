using Quartz;
using static QuartzAPI.Contracts.QuartzSchedullerContracts;
namespace QuartzAPI.Interfaces
{
    public interface IQuartzScheduler
    {
        Task Start();
        Task Stop();
        Task CreateJob(string jobName, string group , CronExpression cronExpression , Type t);
        IScheduler _scheduler { get; set; }
        Task<Q1.ServiceStateResponse> GetServiceState(); 
    }
}
