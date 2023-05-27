using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeriYapıÖdev1
{
    // Samet Ersoyoğlu - 213908354

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class tekDugum
        {
            public String ad;
            public String soyad;
            public int no;
            public tekDugum next;
        }
        tekDugum ilk = null;
        tekDugum son = null;

        private void btnSonEkle_Click(object sender, EventArgs e)
        {
            tekDugum tekdugum = new tekDugum();

            if (txtAd.Text == "" || txtSoyad.Text == "" || txtNo.Text == "")
            {
                MessageBox.Show("Lütfen Eklemek İstediğiniz Kişinin Bilgilerini Giriniz, Boş Geçilemez !");

            }
            else
            {
                tekdugum.ad = txtAd.Text;
                tekdugum.soyad = txtSoyad.Text;
                tekdugum.no = Convert.ToInt32(txtNo.Text);
                txtAd.Clear();
                txtSoyad.Clear();
                txtNo.Clear();

                if (ilk == null)
                {
                    ilk = tekdugum;
                    son = ilk;
                    son.next = null;
                }
                else
                {
                    son.next = tekdugum;
                    tekdugum.next = null;
                    son = tekdugum;
                }
            }
        }

        private void btnAraEkle_Click(object sender, EventArgs e)
        {
            tekDugum tekdugum = new tekDugum();
            tekDugum gecici = new tekDugum();


            if (txtAd.Text == "" || txtSoyad.Text == "" || txtNo.Text == "")
            {
                MessageBox.Show("Lütfen Araya Eklemek İstediğiniz Kişinin Bilgilerini Giriniz, Boş Geçilemez !");

            }
            else
            {
                tekdugum.ad = txtAd.Text;
                tekdugum.soyad = txtSoyad.Text;
                tekdugum.no = Convert.ToInt32(txtNo.Text);
                gecici = ilk;

                if (ilk != null)
                {
                    while (gecici.no < tekdugum.no)
                    {
                        if (gecici.next.no > tekdugum.no)
                        {
                            break;
                        }
                        gecici = gecici.next;
                    }
                    tekdugum.next = gecici.next;
                    gecici.next = tekdugum;
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //noSil silinecek numara
            //gecSil silinecek numaranın bir önceki numara
            tekDugum noSil = new tekDugum();
            tekDugum gecsil = new tekDugum();

            if (txtNo.Text == "")
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kişinin Numarasını Giriniz. Boş Geçilemez");

            }
            else
            {
                int no = Convert.ToInt32(txtNo.Text);
                noSil = ilk;
                txtNo.Clear();

                if (ilk.no == no)
                {
                    // ilk numara silinme
                    ilk = ilk.next;
                }

                else
                {
                    while (noSil.no != no)
                    {
                        gecsil = noSil;
                        noSil= noSil.next;
                    }

                    gecsil.next = noSil.next;

                }

            }

        }

        public void listeYaz()
        {
            dataGridView1.Rows.Clear();
            tekDugum bulSil = ilk;
            while (bulSil != null)
            {
                dataGridView1.Rows.Add(bulSil.ad, bulSil.soyad, bulSil.no);
                bulSil = bulSil.next;
            }

        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            listeYaz();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }
    }
}
