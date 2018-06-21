namespace StatusApp
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private const string PASSWORD = "123456";
        private const string USER = "dbi380752";
        private const string DB = "dbi380752";
        private const string HOST = "studmysql01.fhict.local";
        private string connectionString = $"server={HOST};database={DB};user id={USER};password={PASSWORD};connect timeout=30;SslMode=none";

        private SqlManager queryManager;
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                queryManager = new SqlManager();
                queryManager.connection = connection;
                this.UpdateFields(null, null);
                this.showLables();
                this.timer1.Tick += this.UpdateFields;
                this.timer1.Start();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect"))
                {
                    MessageBox.Show("Application unable to connect to the database");
                    this.Close();
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            this.timer1.Stop();
        }

        private void UpdateFields(object sender, EventArgs e)
        {
            this.lbUpdated.Text = DateTime.Now.ToString();

            this.lbTickets.Text = this.queryManager.TicketsPurchased();
            //this.lbAttendees.Text = this.queryManager.CurrentAttendees();
            this.lbPurchasedItem.Text = this.queryManager.MostPurchasedItem();
            this.lbPrefferedStore.Text = this.queryManager.MostPrefferedShop();
            //this.lbMoneyAtStores.Text = this.queryManager.MoneySpendOnShops();
            this.lbMoneyForLoaning.Text = this.queryManager.MoneySpentForLoaning();
            this.lbLoanedMaterial.Text = this.queryManager.MostLoanedMaterial();
            this.grAtendees.DataSource = this.queryManager.AtendeesByDays();
            this.grMoney.DataSource = this.queryManager.MoneyAtShopsByDay();
            this.grLostItems.DataSource = this.queryManager.NotReturnedItems();
        }

        private void showLables()
        {
            //lbAttendees.Visible = true;
            lbLoanedMaterial.Visible = true;
            //lbMoneyAtStores.Visible = true;
            lbMoneyForLoaning.Visible = true;
            lbPrefferedStore.Visible = true;
            lbPurchasedItem.Visible = true;
            lbTickets.Visible = true;
        }
    }
}
