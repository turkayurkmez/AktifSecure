using System;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public class AntiForgeryToken
{
    public static void Check(Page page, HiddenField hiddenField)
    {
        if (!page.IsPostBack)
        {
            Guid guid = Guid.NewGuid();
            hiddenField.Value = guid.ToString();
            page.Session["Token"] = guid;
        }
        else
        {
            Guid server = (Guid)page.Session["Token"];
            Guid client = new Guid(hiddenField.Value);

            if (client != server)
            {
                throw new SecurityException("CSRF Atağı algılandı!");
            }

        }
    }
}