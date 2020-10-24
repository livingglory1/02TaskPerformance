using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02TaskPerformance
{
    public partial class CashierWindowQueue : Form
    {
        public CashierWindowQueue()
        {
            InitializeComponent();
        }
        private int _tick;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }
        public void DisplayCashierQueue (IEnumerable CashierList)
            {
                listCashierQueue.Items.Clear();
                foreach(object obj in CashierList)
                {
                    listCashierQueue.Items.Add(obj.ToString());
                }
            }

        private void CashierWindowQueue_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _tick++;
                lblTimer.Text = _tick.ToString();
                if (_tick == 15)
                {
                    timer1.Stop();
                    _tick = 0;
                    CustomerView f3 = new CustomerView();
                    f3.ShowDialog();
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                   
                }
            }

            catch (System.InvalidOperationException ex)
            {
                timer1.Stop();
                _tick = 0;
                this.Close();
            }
                
            }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void listCashierQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

