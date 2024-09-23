using System;
using System.Windows.Forms;

namespace BMS_Tickets
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //Sets EndDatePicker control to current DateTime
            EndDatePicker.Value = DateTime.Now;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Create then show instance of LoginForm
            LoginForm form = new LoginForm();
            form.Show();
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            //Create instance of FolderBrowserDialog Class
            FolderBrowserDialog browser = new FolderBrowserDialog();

            //Show the FolderBrowser dialog
            DialogResult result = browser.ShowDialog();

            //Ensure chosen path is OK
            if (result == DialogResult.OK)
            {
                //Enter the selected path in the Textbox
                DirectoryChoiceTextbox.Text = browser.SelectedPath;
            }
        }

        private void DateSelectButton_Click(object sender, EventArgs e)
        {
            //Get Dates from DateTimePickers and convert to string
            String start = StartDatePicker.Value.ToString();
            String end = EndDatePicker.Value.ToString();

            //Convert DateTime strings into format "MM-DD-YYY"
            start = start.Split()[0].Replace('/', '-');
            end = end.Split()[0].Replace('/', '-');
            
            //API call
            Interface.GetPageCount(start, end);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            long OneMinute = 60 * 1000;

            String FileLocation = DirectoryChoiceTextbox.Text;

            Console.WriteLine(FileLocation);

            //Get Dates from DateTimePickers and convert to string
            String start = StartDatePicker.Value.ToString();
            String end = EndDatePicker.Value.ToString();

            //Convert DateTime strings into format "MM-DD-YYY"
            start = start.Split()[0].Replace('/', '-');
            end = end.Split()[0].Replace('/', '-');

            Interface.GetTickets(start, end, FileLocation);

            var CallTimer = new System.Timers.Timer(OneMinute);

            //API call
            CallTimer.Elapsed += (s, en) => Interface.GetTickets(start, end, FileLocation);
            CallTimer.AutoReset = true;
            CallTimer.Enabled = true;
            
            


        }
    }
}
