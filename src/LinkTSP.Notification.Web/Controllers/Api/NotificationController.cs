using LinkTSP.Notification.Data.Repositories;
using LinkTSP.Notification.ViewModels;
using LinkTSP.Notification.Web.App_Code;
using LinkTSP.Notification.Web.Models;
using Microsoft.AspNetCore.Http;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Linq;
using LinkTSP.Notification.Web.Resources;


namespace LinkTSP.Notification.Web.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController(ApplicationDbContext dbContext) : base(dbContext) { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Email.SendEmail("Test mail", "Test mail body", "Nabil.Mansour@linktsp.com");
                var model = UnitOfWork.Notification.Get().ToList();
                return Ok(new ResultViewModel { Success = true, Data = model, });
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel { Success = true, Message = Shared.ErrorMessage, });
            }
        }

        [HttpGet]
        public IActionResult GetPaged(int pageId = 1, int pageSize = 10, string searchPattern = null, string sortColumn = "Id", ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            try
            {
                var model = UnitOfWork.Notification.Get(pageId, pageSize, searchPattern, sortColumn, sortDirection).ToList();
                var count = UnitOfWork.Notification.Count();
                return Ok(new ResultViewModel { Success = true, Data = model, Count = count });
            }
            catch (Exception ex)
            {
                _ = ex;
                return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
            }
        }

        //[HttpPost]
        //public IActionResult Add(NotificationViewModel model)
        //{
        //    try
        //    {
        //        if (model.AllUsers)
        //        {
        //            model.Users = UnitOfWork.User.GetByRole(Roles.Client).Select(s => new UsersNotificationViewModel { UserId = s.Id }).ToList();
        //        }
        //        UnitOfWork.Notification.Add(model);
        //        UnitOfWork.Commit();

        //        foreach (var user in UnitOfWork.User.GetById(model.Users.Select(s => s.UserId)))
        //        {
        //            var message = new Message()
        //            {
        //                Notification = new FirebaseAdmin.Messaging.Notification
        //                {
        //                    Title = model.Subject,
        //                    Body = model.Message,
        //                },
        //                Token = user.DeviceToken
        //            };
        //            Firebase.Send(message);
        //        }
        //        return Ok(new ResultViewModel { Success = true, });
        //    }
        //    catch (Exception ex)
        //    {
        //        _ = ex;
        //        return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
        //    }
        //}

        [HttpPut]
        public IActionResult Edit(NotificationViewModel model)
        {
            try
            {
                UnitOfWork.Notification.Edit(model);
                UnitOfWork.Commit();
                return Ok(new ResultViewModel { Success = true, });
            }
            catch (Exception ex)
            {
                _ = ex;
                return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                UnitOfWork.Notification.Remove(id);
                UnitOfWork.Commit();
                return Ok(new ResultViewModel { Success = true, });
            }
            catch (Exception ex)
            {
                _ = ex;
                return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
            }
        }
    }
}
