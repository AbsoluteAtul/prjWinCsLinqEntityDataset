using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsLinqEntityDataset
{
    public partial class frmLinq2Collections : Form
    {
        public frmLinq2Collections()
        {
            InitializeComponent();
        }
        int[] tabGrades = { 35, 85, 57, 90, 12, 67, 89, 44, 80, 30, 20 };

        List<clsStudent> colStudents = new List<clsStudent>();

        private void frmLinq2Collections_Load(object sender, EventArgs e)
        {
            // display the contents of the array in the listbox
            // Loop Version
            //foreach(int grad in tabGrades)
            //{
            //    lstGrades.Items.Add(grad);
            //}


            // Data Biding

            lstGrades.DataSource = tabGrades;
            //Create students and fill the collections with them
            clsStudent st1 = new clsStudent("st11", "Ali Reza", 1,2,2000,90);
            colStudents.Add(st1);
            colStudents.Add(new clsStudent("st22", "Bill Gates", 11, 8, 1900, 50));
            colStudents.Add(new clsStudent("st33", "Sophie Marceau", 4, 12, 2001, 10));
            colStudents.Add(new clsStudent("st44", "Emie Kaur", 13, 5, 2003, 87));
            colStudents.Add(new clsStudent("st55", "Marco polo", 23, 9, 2002, 70));
            colStudents.Add(new clsStudent("st66", "Tode foure", 17, 10, 1980, 60));

            // Databind the data with the gridview
            gridStudents.DataSource = colStudents;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int[] bestgrades = new int[10];
            // LOop Version to search
            //int i = 0;
            //foreach(int grad in tabGrades)
            //{
            //    if (grad >= 60)
            //    {
            //        bestgrades[i] = grad;
            //        i++;
            //    }

            // DataBinding
          //  lstResult.DataSource = bestgrades;

            //Linq Version
            //Build Linq

            var gradesToFind = from grad in tabGrades
                               where grad >=60
                               select grad;


            lstResult.DataSource = gradesToFind.ToList();
        }

        private void btnFindCollection_Click(object sender, EventArgs e)
        {
            var beststudents =  from student in colStudents
                                  where student.Grade >= 60
                                //select student;
                                select new { grades = student.Grade, Name = student.Name }; // select specific columns

          dataGridView1.DataSource = beststudents.ToList(); 

        }
    }
    }

