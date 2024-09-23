using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace BMS_Tickets
{
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Assign each entered credential into appropriate variable
            String username = usernameTextbox.Text;
            String password = passwordTextbox.Text;
            String company = companyTextbox.Text;

            //Ensure no textbox was left empty
            if (username == "" || password == "" || company == "")
            {
                //Error message then close
                //#FIXME Find a better way to restart the authentication process
                MessageBox.Show("Please complete all fields and try again!!");
                this.Close();
            }        
            
            //Add credentials to a List of KeyValuePairs
            List <KeyValuePair<String, String>> requestData = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<string, string>("grantType", "password"),
                new KeyValuePair<string, string>("userName", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("tenant", company)
            };

            //Convert list into FormUrlEncodedContent for use in authentication API call
            var content = new FormUrlEncodedContent(requestData);

            //Auth API call
            Interface.GetAccess(content);


            username = "";
            password = "";
            company = "";

            this.Close();
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
