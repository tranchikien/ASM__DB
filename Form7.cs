using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1__DB
{
    public partial class Form7 : Form
    {
        private SqlConnection connectionString = new SqlConnection (@"Data Source=LAPTOP-8078I30L\SQLEXPRESS;Initial Catalog=QuanLyBanHang1;Integrated Security=True;TrustServerCertificate=True");

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Sales Report")
            {
                LoadSalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Daily Sales Report")
            {
                LoadDailySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Monthly Sales Report")
            {
                LoadMonthlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Yearly Sales Report")
            {
                LoadYearlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Profit Report")
            {
                LoadProfitReport();
            }
        }

        // Hàm tải dữ liệu cho Sales Report (tất cả giao dịch bán)
        private void LoadSalesReport()
        {
            try
            {
                string query = @"
                    SELECT 
                        S.SaleID AS [ID],
                        P.ProductName AS [Product Name],
                        S.QuantitySold AS [Sales Quantity],
                        CONVERT(VARCHAR, S.SaleDate, 103) AS [Sale Date],
                        (S.QuantitySold * P.SellingPrice) AS [Total Mony]
                    FROM 
                        Sales S
                    INNER JOIN 
                        Product P ON S.ProductID = P.ProductID";

                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Sales Report: " + ex.Message);
            }
        }


        private void btnCreateReport2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Sales Report")
            {
                LoadSalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Daily Sales Report")
            {
                LoadDailySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Monthly Sales Report")
            {
                LoadMonthlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Yearly Sales Report")
            {
                LoadYearlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Profit Report")
            {
                LoadProfitReport();
            }
        }

        //Truy vấn để lấy báo cáo doanh thu theo ngày bán
        private void LoadDailySalesReport()
        {
            try
            {
                string query = @"
            SELECT 
                CONVERT(DATE, S.SaleDate) AS [Sale Date],
                SUM(S.QuantitySold * P.SellingPrice) AS [Total Revenue]
            FROM 
                Sales S
            INNER JOIN 
                Product P ON S.ProductID = P.ProductID
            GROUP BY 
                CONVERT(DATE, S.SaleDate)";

                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView2.DataSource = table; // Thay đổi với DataGridView tương ứng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading daily sales report: " + ex.Message);
            }
        }

        
        private void btnCreateReport3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Sales Report")
            {
                LoadSalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Daily Sales Report")
            {
                LoadDailySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Monthly Sales Report")
            {
                LoadMonthlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Yearly Sales Report")
            {
                LoadYearlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Profit Report")
            {
                LoadProfitReport();
            }
        }


        //Truy vấn để lấy báo cáo doanh thu theo tháng và năm
        private void LoadMonthlySalesReport()
        {
            try
            {
                string query = @"
            SELECT 
                YEAR(S.SaleDate) AS [Year],
                MONTH(S.SaleDate) AS [Month],
                SUM(S.QuantitySold * P.SellingPrice) AS [Total Revenue]
            FROM 
                Sales S
            INNER JOIN 
                Product P ON S.ProductID = P.ProductID
            GROUP BY 
                YEAR(S.SaleDate), MONTH(S.SaleDate)";

                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView3.DataSource = table; // Thay đổi với DataGridView tương ứng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading monthly sales report: " + ex.Message);
            }
        }



        private void btnCreaterReport5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Sales Report")
            {
                LoadSalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Daily Sales Report")
            {
                LoadDailySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Monthly Sales Report")
            {
                LoadMonthlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Yearly Sales Report")
            {
                LoadYearlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Profit Report")
            {
                LoadProfitReport();
            }
        }


       //Truy vấn để lấy báo cáo lợi nhuận theo nhân viên và sản phẩm
        private void LoadProfitReport()
        {
            try
            {
                string query = @"
            SELECT 
                P.ProductName AS [Product Name], 
                E.EmployeeName AS [Employee Name], 
                SUM((P.SellingPrice - P.ProductCost) * S.QuantitySold) AS [Total Profit]
            FROM 
                Sales S
            INNER JOIN 
                Product P ON S.ProductID = P.ProductID
            INNER JOIN 
                Employee E ON S.EmployeeID = E.EmployeeID
            GROUP BY 
                P.ProductName, E.EmployeeName";

                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView5.DataSource = table; // Thay đổi với DataGridView tương ứng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profit report: " + ex.Message);
            }
        }

        private void btnCreaterReport4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Sales Report")
            {
                LoadSalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Daily Sales Report")
            {
                LoadDailySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Monthly Sales Report")
            {
                LoadMonthlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Yearly Sales Report")
            {
                LoadYearlySalesReport();
            }
            else if (tabControl1.SelectedTab.Text == "Profit Report")
            {
                LoadProfitReport();
            }
        }


        
         //Truy vấn để lấy báo cáo doanh thu theo năm
        private void LoadYearlySalesReport()
        {
            try
            {
                string query = @"
            SELECT 
                YEAR(S.SaleDate) AS [Year],
                SUM(S.QuantitySold * P.SellingPrice) AS [Total Revenue]
            FROM 
                Sales S
            INNER JOIN 
                Product P ON S.ProductID = P.ProductID
            GROUP BY 
                YEAR(S.SaleDate)";

         



                SqlCommand command = new SqlCommand(query, connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView4.DataSource = table; // Thay đổi với DataGridView tương ứng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading yearly sales report: " + ex.Message);
            }
        }

    }
}

