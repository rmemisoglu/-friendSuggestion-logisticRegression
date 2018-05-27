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
using System.Collections;

namespace arkadasOnerme
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public bool ekle = true;
        arkadasOnerme oe = new arkadasOnerme();

       

        private void ogrenciNetworkEkle()
        {
            StreamReader sr = new StreamReader("ogrenciNetwork.txt");

            while (!sr.EndOfStream)
            {
                //string[] satir = new string[11];


                string[] satir2 = sr.ReadLine().Split(',');

                for (int i = 0; i < satir2.Length; i++)
                {
                    if (satir2[i] == "")
                    {
                        satir2[i] = "0";
                    }
                }
                ogrenciNetwork on = new ogrenciNetwork();
                on.ogrenciNo = Convert.ToInt64(satir2[0]);
                on.a1 = Convert.ToInt64(satir2[1]);
                on.a2 = Convert.ToInt64(satir2[2]);
                on.a3 = Convert.ToInt64(satir2[3]);
                on.a4 = Convert.ToInt64(satir2[4]);
                on.a5 = Convert.ToInt64(satir2[5]);
                on.a6 = Convert.ToInt64(satir2[6]);
                on.a7 = Convert.ToInt64(satir2[7]);
                on.a8 = Convert.ToInt64(satir2[8]);
                on.a9 = Convert.ToInt64(satir2[9]);
                on.a10 = Convert.ToInt64(satir2[10]);
                oe.ogrenciNetworks.Add(on);
                oe.SaveChanges();
            }
            MessageBox.Show("Ekleme başarılı. Değişiklikleri görmek için Tablolar sekmesine göz atın.");
            sr.Close();
        }

        private void ogrenciProfilEkle()
        {
            StreamReader sr = new StreamReader("ogrenciProfil.txt");


            while (!sr.EndOfStream)
            {
                string[] satir = sr.ReadLine().Split(',');

                ogrenciProfil op = new ogrenciProfil();
                op.ogrenciNo = Convert.ToInt64(satir[0]);
                op.sinema = Convert.ToInt32(satir[1]);
                op.yabanciDizi = Convert.ToInt32(satir[2]);
                op.yabanciMuzik = Convert.ToInt32(satir[3]);
                op.halkMuzik = Convert.ToInt32(satir[4]);
                op.metalMuzik = Convert.ToInt32(satir[5]);
                op.futbol = Convert.ToInt32(satir[6]);
                op.basketbol = Convert.ToInt32(satir[7]);
                op.romanOkuma = Convert.ToInt32(satir[8]);
                op.siirOkuma = Convert.ToInt32(satir[9]);
                op.bilgisayarOyunu = Convert.ToInt32(satir[10]);
                op.sosyalMedya = Convert.ToInt32(satir[11]);
                op.sansOyunu = Convert.ToInt32(satir[12]);
                op.siirYazma = Convert.ToInt32(satir[13]);
                op.zekaOyunu = Convert.ToInt32(satir[14]);
                op.enstrüman = Convert.ToInt32(satir[15]);
                oe.ogrenciProfils.Add(op);
                oe.SaveChanges();


            }
            //MessageBox.Show("Ekleme başarılı. Değişiklikleri görmek için Tablolar sekmesine göz atın.");
            // dataGridView1.DataSource = oe.ogrenciProfils.ToList();
            sr.Close();
            StreamReader sr2 = new StreamReader("ogrenciAd.txt", Encoding.GetEncoding("iso-8859-9"), false);

            while (!sr2.EndOfStream)
            {
                string[] satir2 = sr2.ReadLine().Split(',');
                ogrenciAd oa = new ogrenciAd();
                oa.ogrenciNo = Convert.ToInt64(satir2[0]);
                oa.ogrenciAd1 = satir2[1];
                oe.ogrenciAds.Add(oa);
                oe.SaveChanges();
            }
            MessageBox.Show("Ekleme başarılı. Değişiklikleri görmek için Tablolar sekmesine göz atın.");
            sr2.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
            try
            {
                long ogrno = Convert.ToInt64(metroTextBox1.Text);
                label4.Text = (from x in oe.ogrenciAds where x.ogrenciNo == ogrno select x.ogrenciAd1).First();
                listBox1.Items.Clear();
                ArrayList tumArkadasNo = new ArrayList();
                ogrenciNetwork on = (from x in oe.ogrenciNetworks where x.ogrenciNo == ogrno select x).FirstOrDefault();

                if (on.a1 != 0)
                {
                    tumArkadasNo.Add(on.a1);
                }
                if (on.a2 != 0)
                {
                    tumArkadasNo.Add(on.a2);
                }
                if (on.a3 != 0)
                {
                    tumArkadasNo.Add(on.a3);
                }
                if (on.a4 != 0)
                {
                    tumArkadasNo.Add(on.a4);
                }
                if (on.a5 != 0)
                {
                    tumArkadasNo.Add(on.a5);
                }
                if (on.a6 != 0)
                {
                    tumArkadasNo.Add(on.a6);
                }
                if (on.a7 != 0)
                {
                    tumArkadasNo.Add(on.a7);
                }
                if (on.a8 != 0)
                {
                    tumArkadasNo.Add(on.a8);
                }
                if (on.a9 != 0)
                {
                    tumArkadasNo.Add(on.a9);
                }
                if (on.a10 != 0)
                {
                    tumArkadasNo.Add(on.a10);
                }

                List<ogrenciProfil> tumArkadasProfil = new List<ogrenciProfil>();
                foreach (long i in tumArkadasNo)
                {
                    var ark = (from x in oe.ogrenciProfils where x.ogrenciNo == i select x).ToList();
                    tumArkadasProfil.AddRange(ark);

                }
                var tumOgrencilerNo = (from x in oe.ogrenciProfils select x.ogrenciNo).ToList();
                tumOgrencilerNo.Remove(Convert.ToInt64(metroTextBox1.Text));
                var arkadasOlmayanlarNo = tumOgrencilerNo;

                foreach (var i in tumArkadasNo)
                {
                    arkadasOlmayanlarNo.Remove(Convert.ToInt64(i));
                }

                List<ogrenciProfil> arkadasOlmayanlarProfil = new List<ogrenciProfil>();
                List<ogrenciProfil> dahilEdilmeyenProfil = new List<ogrenciProfil>();
                int sayac = 0;
                foreach (long i in arkadasOlmayanlarNo)
                {
                    if (sayac >= 40)
                    {
                        var ark3 = (from x in oe.ogrenciProfils where x.ogrenciNo == i select x).ToList();
                        dahilEdilmeyenProfil.AddRange(ark3);
                        sayac++;
                    }
                    else
                    {
                        var ark2 = (from x in oe.ogrenciProfils where x.ogrenciNo == i select x).ToList();
                        arkadasOlmayanlarProfil.AddRange(ark2);
                        sayac++;
                    }

                }

                var egitimSeti = tumArkadasProfil;
                egitimSeti.AddRange(arkadasOlmayanlarProfil);
                dataGridView1.DataSource = egitimSeti;

                for (int i = 0; i < egitimSeti.Count; i++)
                {
                    if (i < tumArkadasNo.Count)
                    {
                        dataGridView1.Rows[i].Cells[17].Value = 1;
                    }
                    else
                        dataGridView1.Rows[i].Cells[17].Value = 0;
                }

                dataGridView2.DataSource = dahilEdilmeyenProfil;
                label2.Show();
                label1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt yok! Tekrar dene");
            }   
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Tablolar f2 = new Tablolar();
            this.Hide();
            f2.Show();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView1.Show();
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[i].Width = 62;
            }
        }

        private void dataGridView2_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView2.Show();
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView2.Columns[0].Width = 50;
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[i].Width = 62;
            }
        }    

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var profil = oe.ogrenciProfils;
            var network = oe.ogrenciNetworks;
            var isim = oe.ogrenciAds;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroButton7.Enabled = false;
            dataGridView1.Hide();
            dataGridView2.Hide();
            if (ekle)
            {
               
                ekle = false;
            }
            label1.Hide();
            label2.Hide();
            metroButton7.Enabled = true;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int aktiviteSayisi = 15; // synthetic data
            int numRows = 90;
            int seed = 1;
            double[][] trainData = new double[dataGridView1.RowCount][];
            double[][] testData = new double[dataGridView2.RowCount][];

            //train datayı çekme
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                trainData[i] = new double[16];
                for(int j = 0; j < 16; j++)
                {
                    trainData[i][j] = Convert.ToDouble(dataGridView1[j+2,i].Value);
                }
            }
            //test datayı çekme
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                testData[i] = new double[16];
                for (int j = 0; j < 16; j++)
                {
                    testData[i][j] = Convert.ToDouble(dataGridView2[j + 2, i].Value);
                }
            }

            LogisticClassifier lc = new LogisticClassifier(aktiviteSayisi); //lc nesnesini aktivite sayısından üretme
    
            int maxIteration = 100; // maximum iterasyon
 
            double alpha = 0.001;  //değişim katsayısı
            
            double[] weights = lc.Train(trainData, maxIteration, alpha); //Train methodundan ağğırlıkları hesaplama
            //MessageBox.Show("Training complete");
            string wei = "";
            for(int i = 0; i < weights.Length; i++) // ağırlıkları ekrana yazdırma
            {
                wei += weights[i]+" ";
            }
            //MessageBox.Show(wei);
        
            
            int[] sequence= new int[dataGridView2.RowCount];
            double[] result = new double[dataGridView2.RowCount];
            string res = "";
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
               
                double[] test = testData[i];
               
                result[i] = lc.ComputeOutput(test, weights); // sonu olarak bulduğumuz öğrenci numaraları
                sequence[i] = i;                             // ve bunların sırası (numaradan isim bulmak için)
            }
            
            //numaradan isim bulma
            for(int i = 0; i < result.Length; i++)
            {
                for(int j = 0; j < result.Length; j++)
                {
                    if (result[j] < result[i])
                    {
                        double temp = result[i];
                        int temp2 = sequence[i];
                        result[i] = result[j];
                        sequence[i] = sequence[j];
                        result[j] = temp;
                        sequence[j] = temp2;
                    }
                }
            }
            List<double> hepsi = new List<double>(); // arkadaşlar numaraları
            for(int i = 0; i < 10; i++)
            {
                hepsi.Add(Convert.ToDouble(dataGridView2[1,sequence[i]].Value));
            }
            List<string> isimler = new List<string>(); // tüm isimler
            foreach(var es in hepsi)
            {
                var name = (from x in oe.ogrenciAds where x.ogrenciNo == es select x.ogrenciAd1).ToList();
                isimler.AddRange(name);
            }
            string s="";
            foreach(var i in isimler) // arkadaşlar isimleri
            {
                int z = 0;
                listBox1.Items.Add(i);
                z++;
            }
            
        }
        //<stos>
    } // Program

    public class LogisticClassifier
    {
        private int aktiviteSayisi; // number of x variables aka features
        private double[] weights; // b0 = constant

        public LogisticClassifier(int aktiviteSayisi)
        {
            this.aktiviteSayisi = aktiviteSayisi;
            this.weights = new double[aktiviteSayisi + 1]; // [0] = b0 constant
 
        }

        public double[] Train(double[][] trainData, int maxIteration, double alpha)
        {
            
            // alpha is the learning rate
            int Iterate = 0;
            int[] sequence = new int[trainData.Length]; // random order
            for (int i = 0; i < sequence.Length; ++i)
                sequence[i] = i;

            while (Iterate < maxIteration)
            {
                ++Iterate;
                
                // stochastic/online/incremental approach
                for (int ti = 0; ti < trainData.Length; ++ti)
                {
                    
                    int i = sequence[ti];
                    double computed = ComputeOutput(trainData[i], weights);
                    int N = trainData[i].Length;
                    int targetIndex = trainData[i].Length - 1;
                    double target = trainData[i][targetIndex];

          
                    weights[0] = weights[0] - (alpha * ((target - computed)/N));
                   
                    for (int j = 1; j < weights.Length; ++j)
                        weights[j] = weights[j] - (alpha * (((target - computed) * trainData[i][j - 1]))/N);
                  
                }

            } // while
            return this.weights; // by ref is somewhat risky
        } // Train

        public double ComputeOutput(double[] dataItem, double[] weights)
        {
            double z = 0.0;
            z += weights[0]; // the b0 constant
            for (int i = 0; i < weights.Length - 1; ++i) // data might include Y
                z += (weights[i + 1] * dataItem[i]); // skip first weight
            return 1.0 / (1.0 + Math.Exp(-z));
        }
    }
}

