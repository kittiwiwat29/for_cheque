using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;


namespace TMS_Sample
{
    class ClassDBSql
    {
        private string Sq= null;
        public string Drivers = null;
        public string dateScan = null;
        public string MicRs = null;
        public string PicCheque = null;

        private static string TABLE = "SendCheque";
        private static string DB = "scancheque";
        public SqlConnection con = null;


        public ClassDBSql()
        {
            //this.con = new SqlConnection("Server=.\\sqlexpress, Authentication=Windows Authentication, Database=" + DB);


            this.con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog="+DB+";Integrated Security=true");
            //con.Open();

            try
            {
                this.con.Open();
               // MessageBox.Show("SQL SERVER ถูกเชื่อมต่อแล้ว !");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ขออภัย !! เชื่อมต่อ SQL SERVER ไม่ได้");
                Environment.Exit(0);
            }
        }

        public void dt_test1()
        {
            string datesC = this.dateScan;

            string sq = "insert into " + TABLE + "(DateScans)values('" + datesC + "')";
            this.cmd(sq, this.con);
            MessageBox.Show(sq);
        }


        public void InsertSQL()
        {
            string dri = this.Drivers;
            string datesC = this.dateScan;
            string Mic = this.MicRs;
            string Pic = this.PicCheque;

            if (dri != "")
            {
                string sq = "insert into " + TABLE + "(Drivers,DateScans,MicR,PicChequeFont)values('" + dri + "','" + datesC + "','" + Mic + "','" + Pic + "')";
               // MessageBox.Show(sq);
                this.cmd(sq, this.con);
            }
           
            
        }


        public String DeleteSQL()
        {
            string dri = this.Drivers;
            string datesC = this.dateScan;
            string Mic = this.MicRs;
            string Pic = this.PicCheque;

            string sq = "delete from " + TABLE + " where PicChequeFont='" + Pic + "'";
            this.cmd(sq, this.con);
            return sq;
        }


        public String UpdateSQL()
        {
            string dri = this.Drivers;
            string datesC = this.dateScan;
            string Mic = this.MicRs;
            string Pic = this.PicCheque;

            string sq = "update " + TABLE + " set Drivers='" + dri + "',DateScans='" + datesC + "',MicR='" + Mic + "',PicChequeFont='" + Pic + "'";
            this.cmd(sq, this.con);
            return sq;
        }

        public SqlCommand cmd(string TE, SqlConnection cn)
        {
            SqlCommand ts = new SqlCommand(TE, cn);
            ts.ExecuteNonQuery();
            return ts;
        }


    }
}
