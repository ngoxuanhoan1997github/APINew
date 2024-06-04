using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppAPI.Class;
using Newtonsoft.Json;

namespace AppAPI
{
    public partial class Form1 : Form
    {
        string linkapi = "http://apipos.bitis-corp.com";
        string linkapi2 = "https://apiscs.bitisgroup.vn";
        string linkapi3 = "http://192.168.24.108:8501";
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateDataTable()
        {
            dt.Columns.Add("SoCTu");
            dt.Columns.Add("MaSite");
            dt.Columns.Add("Ng_Ctu");
            dt.Columns.Add("MaKH");
            dt.Columns.Add("MaNTe");
            dt.Columns.Add("Thucthu");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("TienKhachTra");
            dt.Columns.Add("DienThoai");
            dt.Columns.Add("Status");
            dt.AcceptChanges();
        }
        private void btnLayAPI_Click(object sender, EventArgs e)
        {   
            using (var client = new WebClient())
            {
                string mach = txtmasite.Text;
                string ngayht = txtngay.Text;
                List<BienNhan> requestdata = new List<BienNhan>();
                BienNhan bn = new BienNhan();

                client.Headers.Add("content-type", "application/json" ) ;
                client.Headers.Add("APIKey", "Th8hjfgtr@475862@FHak73@hfgidj") ;


                var url = linkapi + $"/api/BienNhan/GetBN/" + mach + "/" + ngayht;
                //var url = $"http://apipos.bitis-corp.com/api/BienNhan/GetBN/"+ mach+"/"+ ngayht;

                string response = client.DownloadString(url);
                requestdata = JsonConvert.DeserializeObject<List<BienNhan>>(response);
                //string abc = requestdata[0].SoCTu.ToString();
                if (requestdata != null)
                {
                    if(dataGridView1.DataSource == null)
                    {
                        CreateDataTable();
                        for (int i = 0; i < requestdata.Count; i++)
                        {
                            dt.Rows.Add(requestdata[i].SoCTu, requestdata[i].MaSite, requestdata[i].Ng_Ctu, requestdata[i].MaKH, requestdata[i].MaNTe, requestdata[i].Thucthu, requestdata[i].MaNV, requestdata[i].TienKhachTra, requestdata[i].DienThoai, requestdata[i].Status);
                        }
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Cửa hàng có " + requestdata.Count + " đơn hàng");
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dt.Clear();
                        for (int i = 0; i < requestdata.Count; i++)
                        {
                            dt.Rows.Add(requestdata[i].SoCTu, requestdata[i].MaSite, requestdata[i].Ng_Ctu, requestdata[i].MaKH, requestdata[i].MaNTe, requestdata[i].Thucthu, requestdata[i].MaNV, requestdata[i].TienKhachTra, requestdata[i].DienThoai, requestdata[i].Status);
                        }
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Cửa hàng có " + requestdata.Count + " đơn hàng");
                    }
                }
                else
                    MessageBox.Show("Không có dữ liệu");
            }
        }

        private void btnAPI2_Click(object sender, EventArgs e)
        {
            using(var client = new WebClient())
            {
                string a1 = "BFW003688DEN37";
                string a2 = "1601";
                string a3 = "admin";

                List<TonKho> requestdata = new List<TonKho>();
                TonKho tonkho = new TonKho();

                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("APIKey", "ISFGvawyliuksFGVLiQUWYLGFBKASJfgKJZDGf<k>HGLAISDUKJYFGBLAI");

                var url = linkapi2 + $"/api/data/inventory?S_MATNR=" + a1 + "&S_WERKS=" + a2 + "&S_TEXT=" + a3;
                string response = client.DownloadString(url);
                requestdata = JsonConvert.DeserializeObject<List<TonKho>>(response);
            }
        }
    }
}
