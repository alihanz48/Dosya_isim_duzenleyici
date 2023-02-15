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
            dsyuzanti();
        }


        string uzanti = "";
        private void dsyuzanti()
        {
            int nindex = 0;
            //Uzantıyı elde etmek için döngü
            foreach (String dsyisim in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
            {
                for (int j = dsyisim.Length - 1; j >= 0; j--)
                {
                    if (dsyisim[j] == '.')
                    {
                        nindex = j;
                        break;
                    }
                }
                uzanti = dsyisim.Substring(nindex);
                break;
            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true|| radioButton2.Checked == true|| radioButton3.Checked == true|| radioButton4.Checked == true|| radioButton5.Checked == true)
            {
                listBox2.Items.Clear();
                if (radioButton1.Checked == true)
                {
                    int i = 1;
                    foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                    {
                        dsyuzanti();
                        File.Move(item, yol + "\\" + i.ToString() + uzanti);
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

                        for (int i = 0; i < dsyad.Length; i++)
                        {
                            if (i == 0)
                            {
                                string ihrf = dsyad[0].ToString().ToUpper();
                                dsyad = dsyad.Remove(0, 1);
                                dsyad = ihrf + dsyad;
                            }
                            if (dsyad[i] == ' ')
                            {
                                string byk = dsyad[i + 1].ToString().ToUpper();
                                dsyad = dsyad.Remove(i + 1, 1);
                                dsyad = dsyad.Insert(i + 1, byk);
                            }
                        }
                        File.Move(item, yol + "\\" + dsyad);
                    }
                }
                else if (radioButton5.Checked == true)
                {
                    foreach (string item in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                    {
                        dsyuzanti();
                        dsyad = item.Substring(yol.Length + 1);
                        dsyad = dsyad.Substring(0, dsyad.Length - uzanti.Length);
                        dsyad = dsyad + "." + textBox1.Text;
                        File.Move(item, yol + "\\" + dsyad);
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
    }
}
