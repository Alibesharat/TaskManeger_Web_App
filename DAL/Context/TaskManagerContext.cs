using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seed Data
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = 1,
                    UserName = "Manager",
                    Rols = nameof(Rol.Manager)
                },
                new AppUser()
                {
                    Id = 2,
                    UserName = "Employee",
                    Rols = nameof(Rol.Employee)
                }
                );


            modelBuilder.Entity<TaskItem>().HasData(
              new TaskItem()
              {
                  Id = 1,
                  Description = "task1",
                  
              },
              new TaskItem()
              {
                  Id = 2,
                  Description = "task2",
              }
              );

            modelBuilder.Entity<SubTask>().HasData(
            new SubTask()
            {
                Id = 1,
                TaskItemId=1,
                Description = "subtask1",

            },
            new SubTask()
            {
                Id = 2,
                TaskItemId=2,
                Description = "subtask2",
            }
            );
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }


       

    }
}
