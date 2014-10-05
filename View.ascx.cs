/*
' Copyright (c) 2014  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Christoc.Modules.SQLWorldDBv1.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.IO;
using System.Web.UI;





namespace Christoc.Modules.SQLWorldDBv1
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from SQLWorldDBv1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : SQLWorldDBv1ModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (CountryCode != "")
                {
                    string templatePath = ControlPath + "Templates/Detail.cshtml";
                    var razorEngine = new DotNetNuke.Web.Razor.RazorEngine(templatePath, ModuleContext, LocalResourceFile);
                    var writer = new StringWriter();
                    razorEngine.Render(writer);
                    RazorDiv1.Controls.Add(new LiteralControl(Server.HtmlDecode(writer.ToString())));
                }
                else
                {
                    string templatePath = ControlPath + "Templates/List.cshtml";
                    var razorEngine = new DotNetNuke.Web.Razor.RazorEngine(templatePath, ModuleContext, LocalResourceFile);
                    var writer = new StringWriter();
                    razorEngine.Render(writer);
                    RazorDiv1.Controls.Add(new LiteralControl(Server.HtmlDecode(writer.ToString())));
                }


                
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnName_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Entities.Tabs.TabController.CurrentPage.FullUrl + "/SortBy/Name");
        }

        protected void btnArea_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Entities.Tabs.TabController.CurrentPage.FullUrl + "/SortBy/SurfaceArea");
        }


    }
}