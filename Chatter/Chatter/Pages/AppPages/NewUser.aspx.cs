using Chatter.Model;
using Chatter.Model.BLL;
using Chatter.App_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Chatter.Pages.AppPages
{
    public partial class NewUser : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void NewUserFormView_InsertItem(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.InsertUser(user);

                    Page.SetTempData("SuccessMessage", "Användaren lades till!");
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
                    ModelState.AddModelError(String.Empty, "ERRORPLATS:CODEBEHIND Ett fel inträffade när användaren skulle läggas till.");
                } 
            }
        }
    }
}