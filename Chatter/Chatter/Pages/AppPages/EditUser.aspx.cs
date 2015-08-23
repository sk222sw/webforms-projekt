using Chatter.Model;
using Chatter.Model.BLL;
using Chatter.App_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatter.Pages.AppPages
{
    public partial class EditUser : System.Web.UI.Page
    {

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public UserInfo EditUserFormView_GetItem([RouteData] int id)
        {
            return Service.GetUserInfoByUserId(id);
        }

        //public UserInfo GetUserInfoByUserId(int userId)
        //{
        //    return Service.GetUserInfoByUserId(userId);
        //}

        // The id parameter name should match the DataKeyNames value set on the control
        public void UserFormView_UpdateItem(int userInfoId)
        {
            var userInfo = Service.GetUserInfoById(userInfoId);

            if (TryUpdateModel(userInfo))
            {
                Service.UpdateUserInfo(userInfo);

                Page.SetTempData("SuccessMessage", "Användaren uppdaterades!");
                Response.RedirectToRoute("UserList");
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        public User GetUser(int id)
        {
            return Service.GetUserById(id);
        }

        public void UserInfoFormView_InsertItem(UserInfo userInfo)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    userInfo.UserId = Convert.ToInt32(RouteData.Values["id"]);

                    Service.InsertUserInfo(userInfo);

                    Page.SetTempData("SuccessMessage", "Användaren uppdaterades!");
                    Response.RedirectToRoute("UserList");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (AggregateException ex)
                {
                    foreach (var vr in ex.InnerExceptions)
                    {
                        ModelState.AddModelError(String.Empty, vr.Message);
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "CODEBEHIND Ett fel inträffade när posten skulle läggas till.");
                } 
                
            }
        }

    }
}