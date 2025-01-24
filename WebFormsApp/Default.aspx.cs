using System;
using WebFormsApp;

namespace WebFormsApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var validator = new FormValidator();
            string name = txtName.Text;
            int age = int.TryParse(txtAge.Text, out var parsedAge) ? parsedAge : 0;

            if (validator.IsValidName(name) && validator.IsValidAge(age))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Datos válidos.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Datos no válidos.";
            }
        }
    }
}
