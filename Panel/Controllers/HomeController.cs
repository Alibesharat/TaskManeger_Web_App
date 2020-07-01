using DAL;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskManagerContext _context;

        public HomeController(TaskManagerContext context)
        {
            _context = context;
           

        }

        /// <summary>
        /// دریافت لیست تسک ها
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult GetTasks()
        {
            var s = User;
            var data = _context.TaskItems.ToList();
            return View(data);
        }


        /// <summary>
        /// دریافت لیست ساب تسک ها
        /// </summary>
        /// <param name="TaskItemId"></param>
        /// <returns></returns>
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult GetSubTasks(int TaskItemId)
        {
            var data = _context.SubTasks.Where(c => c.TaskItemId == TaskItemId).ToList();
            ViewBag.TaskItemId = TaskItemId;
            return View(data);
        }




        [HttpGet]
        [Authorize(Roles = nameof(Rol.Manager))]

        public IActionResult AddTask()
        {
            return View();
        }


        /// <summary>
        /// افزودن یک تسک
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns></returns>
        [Authorize(Roles = nameof(Rol.Manager))]
        [HttpPost]
        public IActionResult AddTask([Bind("Id,Description,Statuse")] TaskItem taskItem)
        {
            try
            {
                _context.TaskItems.Add(taskItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetTasks));
            }
            catch (Exception ex)
            {
                //TODO :Log ex
                return View();
            }

        }




        [HttpGet]
        [Authorize(Roles = nameof(Rol.Employee))]

        public IActionResult AddSubTask(int TaskItemId)
        {
            ViewBag.TaskItemId = TaskItemId;
            return View();
        }
        /// <summary>
        /// افزدون یک ساب تسک
        /// </summary>
        /// <param name="subTask"></param>
        /// <returns></returns>
        [Authorize(Roles = nameof(Rol.Employee))]
        public IActionResult AddSubTask([Bind("Id,Description,Statuse,TaskItemId")] SubTask subTask)
        {
            try
            {
                _context.SubTasks.Add(subTask);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetSubTasks),new { TaskItemId = subTask.TaskItemId });
            }
            catch (Exception ex)
            {
                //TODO :Log ex
                return View();
            }

        }




        [HttpGet]
        [Authorize(Roles = nameof(Rol.Manager))]

        public IActionResult Updatetask(int TaskItemId)
        {
            var data = _context.TaskItems.Find(TaskItemId);
            if (data == null) return NotFound();
            return View(data);
        }
        /// <summary>
        /// بروز رسانی وضعیت یک تسک
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns></returns>
        [Authorize(Roles = nameof(Rol.Manager))]
        public IActionResult Updatetask(int id, Statuse statuse)
        {
            try
            {
                var taskitem = _context.TaskItems.Find(id);
                if (taskitem != null)
                {
                    taskitem.Statuse = statuse;
                    _context.TaskItems.Update(taskitem);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(GetTasks));
                }
                return View();
            }
            catch (Exception ex)
            {
                //TODO :Log ex
                return View();
            }

        }




        [HttpGet]
        [Authorize(Roles = nameof(Rol.Employee))]

        public IActionResult UpdateSubtask(int SubtaskId)
        {
            var data = _context.SubTasks.Find(SubtaskId);
            if (data == null) return NotFound();
            return View(data);
        }
        /// <summary>
        /// بروز رسانی وضعیت یک ساب تسک
        /// </summary>
        /// <param name="subTask"></param>
        /// <returns></returns>
        [Authorize(Roles = nameof(Rol.Employee))]
        public IActionResult UpdateSubtask(int id, Statuse statuse)
        {
            try
            {
                var subtask = _context.SubTasks.Find(id);
                if (subtask != null)
                {
                    subtask.Statuse = statuse;
                    _context.SubTasks.Update(subtask);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(GetTasks));
                }
                return View();

            }
            catch (Exception ex)
            {
                //TODO :Log ex
                return View();

            }

        }
    }
}
