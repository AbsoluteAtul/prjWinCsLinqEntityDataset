using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjWinCsLinqEntityDataset
{
    public partial class frmLinqtoDataset : Form
    {
        DataSet mySet;
        DataTable tabCompany;
        DataTable tabEmployee;
        public frmLinqtoDataset()
        {
            InitializeComponent();
        }

        private void frmLinqtoDataset_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            SqlConnection myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
            myConn.Open();
            SqlDataAdapter adpComp = new SqlDataAdapter("SELECT * FROM Companies", myConn);
            adpComp.Fill(mySet, "Companies");
            SqlDataAdapter adpEmp = new SqlDataAdapter("SELECT * FROM Employees", myConn);
            adpEmp.Fill(mySet, "Employees");
            tabCompany = mySet.Tables["Companies"];
            tabEmployee = mySet.Tables["Employee"];

            // Databind Verion with Datatable

            lstCompanies.DataSource = tabCompany;
            lstCompanies.DisplayMember = "ComapanyName";
            lstCompanies.ValueMember = "RefCompany";


            //Linq Version
            //var allcompanies = from company in tabCompany.AsEnumerable()
            //                       //select new {CompanyName = company.Field<string>("CompanyName") };
            //                   select new { CompanyName = company.Field<string>("CompanyName") };

            //lstCompanies.DataSource = allcompanies.ToList();

            //gridResult.DataSource = tabCompany;

            //LOOP VERSION

            //foreach (DataRow myrow in tabCompany.Rows)
            //{
            //    lstCompanies.Items.Add(myrow["CompanyName"].ToString());
            //}


        }

        private void lstCompanies_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lstCompanies.Text + " - " + lstCompanies.SelectedValue);
        }
    }
}
