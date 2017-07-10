using AutoMapper;
using Entities.Budgets;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.BudgetsServices;
using OryxWebApi.ViewModels.BudgetsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class NotificationController : BaseController
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        [Route("AddNotification")]
        public JsonResult AddCommentNotification([FromBody] NotificationViewModel notificationVm)
        {
            var notification = Mapper.Map<Notification>(notificationVm);

            _notificationService.AddCommentNotification(notificationVm.LineCommentId.ToString(), notificationVm.BudgetCode);
            _notificationService.SaveChanges();
            return Json(_notificationService.Get(notification.Id));
        }

        [HttpPost]
        [Route("UpdateNotification")]
        public JsonResult UpdateCommentNotification(string id)
        {
            _notificationService.UpdateNotification(new Guid(id));
            return Json("Notifcation Updated");
        }

        [HttpGet]
        [Route("GetAllNotifications")]
        public JsonResult GetAllNotifications()
        {
            var ret = _notificationService.GetAllNotifications();
            return Json(ret);
        }

        [HttpGet, Route("GetUnreadNotifications")]
        public JsonResult GetAllUnreadNotifications(string operatorId, string workProgram)
        {
            var ret = _notificationService.GetAllUnreadNotifications(operatorId, workProgram);
            return Json(ret);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public override JsonResult Get()
        {
            return Json(_notificationService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_notificationService.Get(ConvertToGuid(id)));
        }
    }
}
