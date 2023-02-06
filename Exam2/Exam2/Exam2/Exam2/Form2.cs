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

namespace Exam2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseTools.DisplayData(dataGridView1, "Select Orders.CustomerNum, Orders.OrderDate, Orders.OrderNum, OrderLine.NumOrdered, OrderLine.QuotedPrice, Part.PartNum, Part.[Description] from Orders inner join OrderLine on Orders.OrderNum = OrderLine.OrderNum inner join Part on Part.PartNum = OrderLine.PartNum");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show()
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DatabaseTools.GetConn();
                con.Open();
                SqlDataAdapter dataADAPT = new SqlDataAdapter();

                dataADAPT.InsertCommand = new SqlCommand("insert into Orders(OrderNum, OrderDate, CustomerNum),Part(PartNum, Description, OnHand, Class, Warehouse, Price),OrderLine(NumOrdered,QuotedPrice) Values @ordernum,@orderdate,@custonum,@numordered,@quoteprice,@partnum,@partdesc,@onhand,@class,@warehouse,@price");
                dataADAPT.InsertCommand.Parameters.AddWithValue("@ordernum", textBox1.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@orderdate", textBox2.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@custonum", textBox3.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@numordered",Decimal.Parse(textBox4.Text));
                dataADAPT.InsertCommand.Parameters.AddWithValue("@quotedprice",Decimal.Parse(textBox5.Text));
                dataADAPT.InsertCommand.Parameters.AddWithValue("@partnum", textBox6.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@onhand",Decimal.Parse(textBox7.Text));
                dataADAPT.InsertCommand.Parameters.AddWithValue("@class", textBox8.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@warehouse", textBox9.Text);
                dataADAPT.InsertCommand.Parameters.AddWithValue("@price", Decimal.Parse(textBox10.Text));
                dataADAPT.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DatabaseTools.DisplayData(dataGridView1, "select * from Orders,OrderLine,Part");
        }
    }
}
