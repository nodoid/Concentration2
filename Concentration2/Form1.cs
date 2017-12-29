using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Concentration2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int unknown;

        private void calculation(List<double> vals)
        {
            double sta = vals[0], cna = vals[1], vla = vals[2];
            double stb = vals[3], cnb = vals[4], vlb = vals[5];
            double known = 0, notknown = 0;
            if (unknown < 2)
                known = stb == 1 ? cnb * (vlb / 1000) : (cnb / stb) * (vlb / 1000);
            else
                known = sta == 1 ? cna * (vla / 1000) : (cna / sta) * (vla / 1000);
            switch (unknown)
            {
                // unknown [a]
                case 0 :
                    notknown = sta == 1 ? known*(1000/vla) : (known/sta)*(1000/vla);
                    ca.Value = Convert.ToDecimal(notknown);
                    break;
                // unknown Va
                case 1 :
                    notknown = sta == 1 ? (known * 1000)/cna : (known*1000)/ (cna/sta);
                    va.Value = Convert.ToDecimal(notknown);
                    break;
                // unknown [b]
                case 2 :
                    notknown = stb == 1 ? known*(1000/vlb) : (known/stb)*(1000/vlb);
                    cb.Value = Convert.ToDecimal(notknown);
                    break;
                // unknown Vb
                case 3:
                    notknown = stb == 1 ? (1000 * known)/cnb : (1000 * known)/(cnb/stb);
                    vb.Value = Convert.ToDecimal(notknown);
                    break;
            }

            //double nomolesKnown = sb == 1 ? concKnown * (volKnown / 1000) : (concKnown / sb) * (volKnown / 1000);
            //double nomolesUnknown = sa == 1 ? nomolesKnown * (1000 / volUnknown) : (nomolesKnown / sa) * (1000 / volUnknown);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> info = new List<double>();
            info.Add(Convert.ToDouble(sa.Value));
            info.Add(Convert.ToDouble(ca.Value));
            info.Add(Convert.ToDouble(va.Value));
            info.Add(Convert.ToDouble(sb.Value));
            info.Add(Convert.ToDouble(cb.Value));
            info.Add(Convert.ToDouble(vb.Value));
            calculation(info);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unknown = 0;
            ca.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ca.Value = 0;
            ca.Enabled = false;
            unset(0, 1, 1, 1);
            unknown = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            va.Value = 0;
            va.Enabled = false;
            unset(1, 0, 1, 1);
            unknown = 1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cb.Value = 0;
            cb.Enabled = false;
            unset(1, 1, 0, 1);
            unknown = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            vb.Value = 0;
            vb.Enabled = false;
            unset(1, 1, 1, 0);
            unknown = 3;
        }

        private void unset(int a, int b, int c, int d)
        {
            ca.Enabled = a == 0 ? false : true;
            va.Enabled = b == 0 ? false : true;
            cb.Enabled = c == 0 ? false : true;
            vb.Enabled = d == 0 ? false : true;
        }

    }
}
