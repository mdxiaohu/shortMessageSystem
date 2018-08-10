using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace XASYU
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHello_Click(object sender, EventArgs e)
        {            Alert.Show("你好 FineUI！", MessageBoxIcon.Warning);
        }

    }
}