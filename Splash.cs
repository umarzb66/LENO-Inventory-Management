﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leno_Inventory_Management
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();


        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            myprogress.Value = startpoint;
            if (myprogress.Value ==100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void myprogress_onValueChange(object sender, EventArgs e)
        {

        }
    }
}
