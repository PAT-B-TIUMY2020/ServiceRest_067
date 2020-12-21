using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;


namespace ServiceRest_20180140067_Yusuf_Johan_Kelana
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "Gagal";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=\"TI UMY\";User ID=sa;Password=goldensilk2020");
            string query = string.Format("insert into dbo.Mahasiswa values ('{0}', '{1}', '{2}', '{3}')", mhs.nim, mhs.nama, mhs.prodi, mhs.angkatan);
            // NIM = '{0}', nim
            // string query = "insert into dbo.Mahasiswa values ('"+mhs.nim+"', '"+mhs.nama+"', '"+mhs.prodi+"', '"+mhs.angkatan+"')";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open(); // Membuka koneksi SQL Server
                Console.WriteLine(query);
                command.ExecuteNonQuery(); //mengeksekusi untuk memasukkan data
                connection.Close();
                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahasiswas = new List<Mahasiswa>();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=\"TI UMY\";User ID=sa;Password=goldensilk2020");
            string query = "select NIM, Nama, Prodi, Angkatan from dbo.Mahasiswa";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mahasiswa = new Mahasiswa();
                    mahasiswa.nim = reader.GetString(0); // 0 itu array pertama dan diambil dari ITI_UMY
                    mahasiswa.nama = reader.GetString(1);
                    mahasiswa.prodi = reader.GetString(2);
                    mahasiswa.angkatan = reader.GetString(3);

                    mahasiswas.Add(mahasiswa);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }

            return mahasiswas; // Output
        }

//        public string GetData(int value)
//        {
//            return string.Format("You entered: {0}", value);
//        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mahasiswa = new Mahasiswa();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=\"TI UMY\";User ID=sa;Password=goldensilk2020");
            string query = string.Format("select NIM, Nama, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    mahasiswa.nim = reader.GetString(0); // 0 itu array pertama dan diambil dari ITI_UMY
                    mahasiswa.nama = reader.GetString(1);
                    mahasiswa.prodi = reader.GetString(2);
                    mahasiswa.angkatan = reader.GetString(3);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }

            return mahasiswa; // Output
        }

        //        public CompositeType GetDataUsingDataContract(CompositeType composite)
        //        {
        //            if (composite == null)
        //            {
        //                throw new ArgumentNullException("composite");
        //            }
        //            if (composite.BoolValue)
        //            {
        //                composite.StringValue += "Suffix";
        //            }
        //            return composite;
        //        }
    }
}
