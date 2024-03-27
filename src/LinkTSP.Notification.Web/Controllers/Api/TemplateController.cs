using LinkTSP.Notification.Data.Repositories;
using LinkTSP.Notification.ViewModels;
using LinkTSP.Notification.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Linq;
using LinkTSP.Notification.Web.Resources;

namespace LinkTSP.Notification.Web.Controllers
{
    public class TemplateController : BaseController
    {
        public TemplateController(ApplicationDbContext dbContext) : base(dbContext) { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var model = UnitOfWork.Template.Get().ToList();
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
                var model = UnitOfWork.Template.Get(pageId, pageSize, searchPattern, sortColumn, sortDirection).ToList();
                var count = UnitOfWork.Template.Count();
                return Ok(new ResultViewModel { Success = true, Data = model, Count = count });
            }
            catch (Exception ex)
            {
                _ = ex;
                return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
            }
        }

        [HttpPost]
        public IActionResult Add(TemplateViewModel model)
        {
            try
            {
                UnitOfWork.Template.Add(model);
                UnitOfWork.Commit();
                return Ok(new ResultViewModel { Success = true, });
            }
            catch (Exception ex)
            {
                _ = ex;
                return BadRequest(new ResultViewModel { Success = false, Message = Shared.ErrorMessage, });
            }
        }

        [HttpPut]
        public IActionResult Edit(TemplateViewModel model)
        {
            try
            {
                UnitOfWork.Template.Edit(model);
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
                UnitOfWork.Template.Remove(id);
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
