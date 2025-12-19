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
using System.Diagnostics.Tracing;

namespace Dosya_isim_düzenleyici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string yol = "";
        string dsyad = "";
        
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = folderBrowserDialog1.SelectedPath;
                
                foreach (string dsyuzad in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    listBox1.Items.Add(dsyuzad.Substring(yol.Length + 1));
                }
            }
        }


        private string dsyuzanti(string dsyisim)
        {
            int nindex = 0;
            //Uzantıyı elde etmek için döngü

                for (int j = dsyisim.Length - 1; j >= 0; j--)
                {
                    if (dsyisim[j] == '.')
                    {
                        nindex = j;
                        break;
                    }
                }
                return dsyisim.Substring(nindex);
            }
            
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath!="")
            {
                if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true||radioButton5.Checked==true)
                {
                    listBox2.Items.Clear();
                    if (radioButton1.Checked == true)
                    {
                        int i = 1;
                        foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                        {
                            
                            File.Move(item, yol + "\\" + i.ToString() + dsyuzanti(item));
                            i++;
                        }
                    }
                    else if (radioButton2.Checked == true)
                    {

                        foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                        {
                            dsyad = item.Substring(yol.Length + 1);
                            File.Move(item, yol + "\\" + dsyad.ToUpper());
                        }
                    }
                    else if (radioButton3.Checked == true)
                    {
                        foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                        {
                            dsyad = item.Substring(yol.Length + 1);
                            File.Move(item, yol + "\\" + dsyad.ToLower());
                        }
                    }
                    else if (radioButton4.Checked == true)
                    {
                        foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                        {
                            dsyad = item.Substring(yol.Length + 1);
                            string[] words = { };
                            words = dsyad.Split(' ');
                            dsyad = "";


                            for (int i = 0; i <= words.Length-1; i++)
                            { 
                                string nword = words[i].ToLower();
                                nword = nword[0].ToString().ToUpper() + nword.Substring(1, nword.Length - 1);
                                words[i] = nword;
                            }
                            for (int i =0;i<=words.Length-1;i++)
                            {
                                dsyad += words[i];
                                if (i != words.Length - 1)
                                {
                                    dsyad += " ";
                                }
                            }

                            try
                            {
                                File.Move(item, yol + "\\" + dsyad);
                            }
                            catch (Exception) { }

                            
                        }
                    }
                    else if (radioButton5.Checked==true)
                    {
                        foreach (string dosya in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                        {
                            string dosyaadi = "";
                            string[] words = { };
                            words = dosya.Substring(yol.Length + 1).Split('.');
                            words[words.Length - 1] ="."+textBox1.Text;
                            for (int i = 0; i <= words.Length-1; i++)
                            {
                                dosyaadi += words[i].ToString();
                            }
                            try
                            {
                                File.Move(dosya, yol + "\\" + dosyaadi);
                            }
                            catch (Exception) { }

                        }
                    }
                    foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                    {
                            listBox2.Items.Add(item.Substring(yol.Length + 1));
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir eylem seçiniz");
                }
            }
            else
            {
                MessageBox.Show("Dosyaları al butonuna basarak dosya isimlerini işleyeceğiniz klasörü seçmelisiniz!");
            }
            
            
        }
    }
}
