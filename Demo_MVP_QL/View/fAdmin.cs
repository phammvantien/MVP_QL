using Demo_MVP_QL.Presenter;
using Demo_MVP_QL.Presenter.Banan_Presenter;
using Demo_MVP_QL.Presenter.Danhmuc_Presenter;
using Demo_MVP_QL.Presenter.MonAn;
using Demo_MVP_QL.Presenter.MonAn_Presenter;
using Demo_MVP_QL.View.Banan_View;
using Demo_MVP_QL.View.danhmuc;
using Demo_MVP_QL.View.Monan_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Demo_MVP_QL.View
{
    public partial class fAdmin : Form, IAddDanhmuc, IUpdateDanhmuc, IshowDanhmuc, ISelectDanhmuc,IaddMonan,Ishowmonan,Iselect_Monan,Iupdate_monan,IDelete_Monan,IDeleteDanhmuc,IAddBanan,IShowBanan,IDodulieuBanan,IUpdateBanan,IDeleteBanan,IShearch_Monan
    {
        string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;Trust Server Certificate=True";




        public int MonAnId
        {
            get { return int.Parse(txtidmon.Text); }
            set { txtidmon.Text = value.ToString(); }
        }

        public string MonAnName
        {
            get { return txtnamemon.Text; }
            set { txtnamemon.Text = value; }
        }

        public float MonAnPrice
        {
            get { return float.Parse(txtgia.Text); }
            set { txtgia.Text = value.ToString(); }
        }

        public int IdCategory
        {
            get { return int.Parse(txtiddanhmuc.Text); }
            set { txtiddanhmuc.Text = value.ToString(); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                MessageBox.Show(_message);
            }
        }
        public void clearTT()
        {
            // Clear the text fields
            txtid_danhmuc.Text = "";
            txt_name_danhmuc.Text = "";
            txt_search_monan.Text = "";
            txtidmon.Text = "";
            txtnamemon.Text = "";
            txtiddanhmuc.Text = "";
            txtgia.Text = "";
            txtidban.Text = "";
            txttenban.Text = "";
            txttrangthaiban.Text = "";


            txt_name_danhmuc.Text = "";
        }
        public string DanhmucId
        {
            get => txtid_danhmuc.Text;
            set => txtid_danhmuc.Text = value;
        }

        public string DanhmucName
        {
            get => txt_name_danhmuc.Text;
            set => txt_name_danhmuc.Text = value;
        }

        public DataGridView DataGridViewDanhmuc => dataGridViewdanhmuc;
        public DataTable DanhmucData
        {
            get => (DataTable)dataGridViewdanhmuc.DataSource;
            set => dataGridViewdanhmuc.DataSource = value;
        }
        public void HienThi()
        {
            dataGridViewdanhmuc.DataSource = DanhmucData;
        }
        //public DataTable MonanData;
        //public DataGridView DtgvFood => dtgvFood;
        public int SelectedRowIndexmonan => dtgvFood.CurrentRow?.Index ?? -1;
        public int SelectedRowIndex => dataGridViewdanhmuc.CurrentRow?.Index ?? -1;
        public int SelectedRowIndexBanan=>dataGridViewBanan.CurrentRow?.Index ?? -1;




        public DataGridView DataGridViewMonan => dtgvFood;



        public DataTable MonanData{ 
            get => (DataTable)dtgvFood.DataSource; 
            set => dtgvFood.DataSource=value;
        }
        public void HienThimonan()
        {
            dtgvFood.DataSource = MonanData;
        }



        public int danhmucID
        {
            //get => throw new NotImplementedException();
            //set => throw new NotImplementedException();
            get
            {
                // Convert the string to an int
                if (int.TryParse(txtid_danhmuc.Text, out int result))
                {
                    return result;
                }
                else
                {
                    // Handle the case where the conversion fails
                    return 0; // Or throw an exception, depending on your needs
                }
            }
            set
            {
                // Convert the int to a string
                txtid_danhmuc.Text = value.ToString();
            }
        }
        public string danhmucName
        {
            //get => throw new NotImplementedException();
            //set => throw new NotImplementedException();
            get
            {
                // Chuyển đổi trực tiếp từ string sang int
                return txt_name_danhmuc.Text;
            }
            set
            {
                // Chuyển đổi từ int sang string
                txt_name_danhmuc.Text = value;
            }
        }
      
        public string IdCategoryy
        {
            get { return txtiddanhmuc.Text; } // Sử dụng Text từ TextBox
            set { txtiddanhmuc.Text = value; } // Cập nhật TextBox
        }

        public int BananId
        {
            get
            {
                // Chuyển đổi giá trị từ string sang int
                if (int.TryParse(txtidban.Text, out int result))
                {
                    return result;
                }
                else
                {
                    // Trả về giá trị mặc định nếu không thể chuyển đổi
                    return 0; // Hoặc throw một ngoại lệ nếu cần thiết
                }
            }
            set
            {
                // Chuyển đổi giá trị từ int sang string
                txtidban.Text = value.ToString();
            }
        }

        public string BananName { get => txttenban.Text; set => txttenban.Text = value; }
        public bool BananStatus { get => txttrangthaiban.Text == "Có người"; set => txttrangthaiban.Text = value ? "Có người" : "Trống"; }
   



        //public DataGridView DataGridViewDanhmuc => throw new NotImplementedException();



        public fAdmin()
        {
            InitializeComponent();
        }

        private void dateTimePickerBill_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMonan_Presenter ma = new DeleteMonan_Presenter(this);
            ma.xoamonan();
            ma.HienThiMonan();
            clearTT();
             



          
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri_monan_Presenter vt = new vitri_monan_Presenter(this);
            txtidmon.ReadOnly = true;
            vt.HienThiChiTietmonan();
            monan_add.Enabled = false;
            monan_delete.Enabled = true;
            monan_update.Enabled = true;
         
            
        }

        private void tcFood_Click(object sender, EventArgs e)
        {

        }

        private void dtgvFood_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that an item is selected
            //Showdanhmuc sh = new Showdanhmuc(this);
            //sh.HienThiTenDanhmuc(txtiddanhmuc);
            //if (txtiddanhmuc.SelectedIndex != -1)
            //{
            //    // Retrieve the selected category's name and ID
            //    string selectedCategoryName = txtiddanhmuc.Text; // Gets the displayed name
            //    int selectedCategoryId = Convert.ToInt32(txtiddanhmuc.SelectedValue); // Gets the corresponding ID

            //    // Display or use the selected category's ID and name
            //    MessageBox.Show($"Selected Category: {selectedCategoryName}, ID: {selectedCategoryId}");

            //    // You can also update other fields or perform additional logic here
            //}
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tcTableFood_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_name_danhmuc.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;

            }
            AddDanhmuc_Precenter pre = new AddDanhmuc_Precenter(this);
            pre.adddanhmuc();
            pre.HienThiDanhmuc();
            clearTT();
          
        }
        public DataGridView DataGridViewBanan { get => dataGridViewBanan; set => dataGridViewBanan = value; } // Kết nối DataGridView với giao diện
        public DataTable MonAnData {
            get => (DataTable)dtgvFood.DataSource;
            set => dtgvFood.DataSource = value;
        }

        private void InitializeComboBox()
        {
            txttrangthaiban.Items.Clear();
            txttrangthaiban.Items.Add("Có người");
            txttrangthaiban.Items.Add("Trống");
            txttrangthaiban.SelectedIndex = 0; // Set default value
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            InitializeComboBox();

            txtid_danhmuc.ReadOnly = true;
            txtidban.ReadOnly = true;
            txtidmon.ReadOnly = true;   
             Showdanhmuc presenter = new Showdanhmuc(this);
            presenter.HienThiDanhmuc();
            presenter.HienThiTenDanhmuc(txtiddanhmuc);

            ShowmonAn_Presenter pre = new ShowmonAn_Presenter(this);
            pre.HienThiMonan();
            ShowBanAn_Presenter bn = new ShowBanAn_Presenter(this);
            bn.ShowBanan();


        }

        private void dataGridViewdanhmuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            vitridanhmuc_presenter presenter = new vitridanhmuc_presenter(this);
            presenter.HienThiChiTietDanhmuc();
            txtidmon.ReadOnly = true;
            button9.Enabled = false ;
            button8.Enabled = true ;
            btnxoadanhmuc.Enabled = true;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtidban.ReadOnly = true;
            if (string.IsNullOrEmpty(txt_name_danhmuc.Text)  )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa!");
                return;

            }
            UpdateDanhmuc_Precenter dm = new UpdateDanhmuc_Precenter (this);
            dm.suadanhmuc(); 
            dm.HienThiDanhmuc();
            clearTT();
       
         
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void monan_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnamemon.Text) || string.IsNullOrEmpty(txtgia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;
            }

            AddMonan_Presenter pr = new AddMonan_Presenter(this);
           
                pr.addMonan();
            
            //ShowmonAn_Presenter ma = new ShowmonAn_Presenter(this);
           pr.HienThiMonan();
            clearTT();
        }

        private void monan_update_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtnamemon.Text) || string.IsNullOrEmpty(txtgia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;

            }
           
            UpdateMonan_Presenter pr = new UpdateMonan_Presenter(this);
            pr.Updatemonan();
         pr.HienThiMonan();
            clearTT();

           
          
        }

        private void btnxoadanhmuc_Click(object sender, EventArgs e)
        {
            DeleteDanhmuc_Precenter pr = new DeleteDanhmuc_Precenter(this);
            pr.xoadanhmuc();
            pr.HienThiDanhmuc();
            clearTT();
          
      



        }

        private void xoathongtin_Click(object sender, EventArgs e)
        { txtidmon.ReadOnly = true;
            clearTT();
            button9.Enabled = true;

            button8.Enabled=false;
            btnxoadanhmuc.Enabled = false;

        }

        private void xoathongtinmonan_Click(object sender, EventArgs e)
        {
            clearTT();
            monan_add.Enabled = true;
            monan_delete.Enabled = false;
            monan_update.Enabled = false;
        }

        private void xoathongtinmonan_MouseClick(object sender, MouseEventArgs e)
        {
            clearTT();
            monan_add.Enabled = true;
            monan_delete.Enabled = false;
            monan_update.Enabled = false;
        }

        private void themban_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txttenban.Text) || string.IsNullOrEmpty(txttrangthaiban.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;

            }
           txtidban.ReadOnly = true;
            AddBanan_Presenter pr = new AddBanan_Presenter(this);
            pr.AddBanan();
            pr.ShowBanan();
            clearTT();
        }

        private void dataGridViewBanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DodlBanan_Presenter pr = new DodlBanan_Presenter(this);
            pr.HienThiChiTietBanan();
            themban.Enabled = false;
            suaban.Enabled = true;
            xoaban.Enabled = true;
        

        }

        private void xoathongtinban_Click(object sender, EventArgs e)
        {
            clearTT();
            themban.Enabled = true;
            suaban.Enabled = false;
            xoaban.Enabled = false;

        }

        private void txttrangthaiban_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu ComboBox có giá trị được chọn
          
            
        }

        private void suaban_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidban.Text) || string.IsNullOrEmpty(txttenban.Text) || string.IsNullOrEmpty(txttrangthaiban.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;

            }
            UpdateBanan_Presenter pr = new UpdateBanan_Presenter(this);
            pr.UpdateBanan();
           
            pr.ShowBanan();
            clearTT();

        }

        private void xoaban_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidban.Text) || string.IsNullOrEmpty(txttenban.Text) || string.IsNullOrEmpty(txttrangthaiban.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!");
                return;

            }
            DeleteBanan_Presenter pr = new DeleteBanan_Presenter(this);
            pr.DeleteBanan();
       
            pr.ShowBanan();
            clearTT();

        }

        private void btnTimmonan_Click(object sender, EventArgs e)
        {
            SearchMonan_Presenter pr = new SearchMonan_Presenter(this);
            string searchTerm = txt_search_monan.Text; // Get the search term from the TextBox
            pr.Timkiemmonan(searchTerm);

        }

        public void HienThiMonan()
        {
            dtgvFood.DataSource = MonanData;
           // Refresh the DataGridView
        }

        private void txt_search_monan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
