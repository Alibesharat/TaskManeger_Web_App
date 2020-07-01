using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtention
    {
        /// <summary>
        /// تزریق کانتکست به برنامه
        /// </summary>
        /// <param name="services"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public static void AddTaskManagerContext(this IServiceCollection services,string ConnectionString)
        {

            services.AddDbContext<TaskManagerContext>(opt =>
            {
                opt.UseSqlite(ConnectionString);
            });
   
        }

       


    }
}
