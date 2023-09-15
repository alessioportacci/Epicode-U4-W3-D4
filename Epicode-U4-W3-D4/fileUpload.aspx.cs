using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Epicode_U4_W3_D4
{
    public partial class fileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if(FileUpload1.HasFile)
            {
                fileName = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath($"/Content/img/{fileName}"));
            }
        }
    }
}