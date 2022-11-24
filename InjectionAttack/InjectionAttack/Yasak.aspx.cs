using System;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            LabelResult.Text = "Bu sayfaya erişemezsiniz!";

        }

        AntiForgeryToken.Check(this, HiddenField1);

    }

    protected void ButtonAddComment_Click(object sender, EventArgs e)
    {
        LabelResult.Text = TextBoxComment.Text;
    }
}