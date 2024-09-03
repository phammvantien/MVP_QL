using Demo_MVP_QL.Presenter.Banan_Presenter;
using Demo_MVP_QL.Presenter.Danhmuc_Presenter;
using Demo_MVP_QL.Presenter.MonAn_Presenter;
using Demo_MVP_QL.View;
using Demo_MVP_QL.View.Banan_View;
using Demo_MVP_QL.View.danhmuc;
using Demo_MVP_QL.View.Monan_View;
using Demo_MVP_QL.View.TrangChu_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo_MVP_QL.Presenter.TrangChu_Presenter;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace Demo_MVP_QL
{
    public partial class fTrangchu : Form,IView
    {
        
            private readonly TablePresenter _presenter;
        private int count;
   
        private int _selectedTableId;
        public fTrangchu()
        {
            InitializeComponent();
            _presenter = new TablePresenter(this);
            _presenter.LoadDataToView();
        
        }

        public void DisplayTableData(DataTable dataTable)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                System.Windows.Forms.Button button = new System.Windows.Forms.Button
                {
                    Width = 100,
                    Height = 100,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                    Margin = new Padding(10),
                    TextAlign = ContentAlignment.MiddleLeft,
                   // Text = $"  {row["name"].ToString()} \n {row["status"].ToString()}"
                      Text = $"  {row["name"].ToString()} "
                };
                button.Click += (sender, e) =>
                {
                  
                    int tableId = Convert.ToInt32(row["id"]);
                    _selectedTableId = tableId;
                    _presenter.DisplayFoodItemsForTable(tableId);
                  
                   
                };
                flowLayoutPanel1.Controls.Add(button);
            }
        }
        public void DisplayFoodCategories(DataTable dataTable)
        {
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = -1;
        }
        public void DisplayFoods(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                comboBox2.DataSource = dataTable;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";
                comboBox2.SelectedIndex = -1; // Đảm bảo không có mục nào được chọn mặc định
            }
            else
            {
                comboBox2.DataSource = null;
                comboBox2.Items.Clear();
            }
        }
        public void DisplayFoodItemsForTable(DataTable dataTable)
        {
           

            listView1.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {

                ListViewItem item = new ListViewItem(row["name"].ToString());
                item.SubItems.Add(row["count"].ToString());
                item.SubItems.Add(row["price"].ToString());
               
                listView1.Items.Add(item);
            }
         
        }
      
       
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog(); 
        }

        private void fTrangchu_Load(object sender, EventArgs e)
        {
           
          
         

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile ();
            f.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại món ăn và món ăn.");
                return;
            }

            int selectedFoodId = (int)comboBox2.SelectedValue;
            if (_selectedTableId <= 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn từ danh sách.");
                return;
            }
            if (count <= 0)
            {
                MessageBox.Show("số lượng không hợp lệ");
                return;
            }

            _presenter.AddFoodToTable(_selectedTableId, selectedFoodId,count);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedCategoryId))
            {
                _presenter.LoadFoodsByCategory(selectedCategoryId);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
             count = (int)numericUpDown1.Value;
          
        }
    }

       
    }

