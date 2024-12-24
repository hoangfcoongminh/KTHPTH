using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadComboBox();
        }

        public void LoadDataGridView()
        {
            string link = "http://localhost/testrestful/api/sanpham";

            HttpWebRequest request = WebRequest.CreateHttp(link);
            
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));

            object data = js.ReadObject(response.GetResponseStream());

            SanPham[] arr = data as SanPham[];

            dgvOutput.DataSource = arr;
        }

        public void LoadComboBox()
        {
            string link = "http://localhost/testrestful/api/danhmuc";

            HttpWebRequest request = WebRequest.CreateHttp(link);

            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));

            object data = js.ReadObject(response.GetResponseStream());

            DanhMuc[] arr = data as DanhMuc[];

            cbbDanhMuc.DataSource = arr;
            cbbDanhMuc.ValueMember = "MaDM";
            cbbDanhMuc.DisplayMember = "TenDM";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?masp={0}&tensp={1}&madm={2}", txtMaSP.Text, txtTenSP.Text, cbbDanhMuc.SelectedValue);
            string link = "http://localhost/testrestful/api/sanpham/" + postString;

            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "POST";

            Stream dataStream = request.GetRequestStream();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));

            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if(kq)
            {
                LoadDataGridView();
                MessageBox.Show("Thêm thành công!");
            } else
            {
                MessageBox.Show("Thêm không thành công!");
            }
        }

        private void dgvOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaSP.Text = dgvOutput.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dgvOutput.Rows[i].Cells[1].Value.ToString();
            cbbDanhMuc.Text = dgvOutput.Rows[i].Cells[2].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?masp={0}&tensp={1}&madm={2}", txtMaSP.Text, txtTenSP.Text, cbbDanhMuc.SelectedValue);
            string link = "http://localhost/testrestful/api/sanpham/" + postString;

            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "PUT";

            Stream dataStream = request.GetRequestStream();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));

            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa không thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?masp={0}", txtMaSP.Text);
            string link = "http://localhost/testrestful/api/sanpham/" + postString;

            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "DELETE";

            Stream dataStream = request.GetRequestStream();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));

            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?masp={0}", txtMaSP.Text);
            string link = "http://localhost/testrestful/api/sanpham/" + postString;

            HttpWebRequest request = WebRequest.CreateHttp(link);

            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));

            object data = js.ReadObject(response.GetResponseStream());

            SanPham[] arr = data as SanPham[];


            if (arr.Length > 0)
            {
                dgvOutput.DataSource = arr;
                
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
        }
    }
}
