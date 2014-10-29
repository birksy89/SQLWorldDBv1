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
using DotNetNuke.Entities.Users;
using Christoc.Modules.SQLWorldDBv1.Components;
using DotNetNuke.Services.Exceptions;

//Extras
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Christoc.Modules.SQLWorldDBv1
{
    /// -----------------------------------------------------------------------------
    /// <summary>   
    /// The Edit class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from SQLWorldDBv1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : SQLWorldDBv1ModuleBase
    {
        string conn = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                BindSubjectData();
            }
        }
        //call this method to bind gridview
        private void BindSubjectData()
        {
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM country";
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvSubDetails.DataSource = dt;
                    gvSubDetails.DataBind();
                    sqlCon.Close();
                }
            }


        }

        //Call This method to Pull the images through
        //private void BindImageData()
        //{
        //    using (SqlConnection sqlCon = new SqlConnection(conn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {

        //            string tempCCode = txtSubjectId.Text;

        //            cmd.CommandText = "SELECT * FROM countryImages WHERE CCode='" + tempCCode + "'";
        //            //cmd.Parameters.AddWithValue("@CCode", txtSubjectId.Text);
        //            cmd.Connection = sqlCon;
        //            sqlCon.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            gvImages.DataSource = dt;
        //            gvImages.DataBind();
        //            sqlCon.Close();
        //        }
        //    }
        //}

        //Insert click event to insert new record to database
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            string SubjectName = txtSubjectName.Text.Trim();
            int Marks = Convert.ToInt32(txtMarks.Text);
            string Grade = txtGrade.Text;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO SubjectDetails(SubjectName,Marks,Grade)
VALUES(@SubjectName,@Marks,@Grade)";
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                    cmd.Parameters.AddWithValue("@Marks", Marks);
                    cmd.Parameters.AddWithValue("@Grade", Grade);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                lblMsg.Text = "'" + SubjectName + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                BindSubjectData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();//to reset all form controls
        }

        //Update click event to update existing record from the gridview
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            string SubjectID = txtSubjectId.Text.Trim();
            string SubjectName = txtSubjectName.Text.Trim();
            string Marks = txtMarks.Text;
            decimal Grade = Convert.ToDecimal(txtGrade.Text);
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"UPDATE country SET Name=@Name,
Region=@Region,SurfaceArea=@SurfaceArea WHERE Code=@Code";
                    cmd.Parameters.AddWithValue("@Code", SubjectID);
                    cmd.Parameters.AddWithValue("@Name", SubjectName);
                    cmd.Parameters.AddWithValue("@Region", Marks);
                    cmd.Parameters.AddWithValue("@SurfaceArea", Grade);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + SubjectName + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvSubDetails.EditIndex = -1;
            BindSubjectData();
            ResetAll();//to reset all form controls
        }

        //Delete click event to delete selected record from the database
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsDeleted = false;
            int SubjectID = Convert.ToInt32(txtSubjectId.Text);
            string SubjectName = txtSubjectName.Text.Trim();
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM SubjectDetails WHERE SubjectId=@SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsDeleted = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsDeleted)
            {
                lblMsg.Text = "'" + SubjectName + "' subject details deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindSubjectData();
            }
            else
            {
                lblMsg.Text = "Error while deleting '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();//to reset all form controls
        }

        //Cancel click event to clear and reset all the textboxes


        protected void gvSubDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubjectId.Text =
            gvSubDetails.DataKeys[gvSubDetails.SelectedRow.RowIndex].Value.ToString();
            txtSubjectName.Text = (gvSubDetails.SelectedRow.FindControl("lblSubjectName")
            as Label).Text;
            txtMarks.Text = (gvSubDetails.SelectedRow.FindControl("lblMarks") as Label).Text;
            txtGrade.Text = (gvSubDetails.SelectedRow.FindControl("lblGrade") as Label).Text;
            //make invisible Insert button during update/delete
            btnInsert.Visible = false;

            //BindImageData();
        }

        //call to reset all form controls
        private void ResetAll()
        {
            btnInsert.Visible = true;
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
            txtMarks.Text = "";
            txtGrade.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll();//to reset all form controls
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

   

       
    }
}
/////////////////


