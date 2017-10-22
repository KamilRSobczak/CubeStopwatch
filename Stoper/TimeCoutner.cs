using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stoper
{
   
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        int  min, sec, mSek = 0;
        string[] algorytmy = { " U ", " U2 ", " U' ", " D ", " D2 ", " D' ", " R ", " R2 ", " R' ", " L ", " L2 ", " L' " };

        //_____________________________________________________________Moduł do odliczania i wyświetlania czasu.
        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer.Text = String.Format("{0:00}", min) + String.Format("{0::00}", sec)+ String.Format("{0::00}", mSek);
            
            if(mSek > 8)
            {
                sec++;
                mSek = 0;

                if (sec > 59)
                {
                    min++;
                    sec = 0;

                    if (min == 60)
                    {                       
                        timer1.Stop();
                        
                        Timer.Text = "60:00:00";
                    }
                } 
            }
            else
            {
                mSek++;
                
            }            
        }

        //_____________________________________________________________Operacje na przyciskach (Start/Stop/Reset)
        
        private void StopButton(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ResetButton(object sender, EventArgs e)
        {
            timer1.Stop();

            sec = 0;
            mSek = 0;
            Timer.Text = String.Format("{0:00}", min) + String.Format("{0::00}", sec) + String.Format("{0::00}", mSek);

            
            Random random = new Random();
            string rng = " ";
            for (int i = 0; i < 15; i++)
            {
                rng = rng + algorytmy[random.Next(0, 12)];
            }
            Scramble.Text = "Scramble: " + rng;
        }

        private void StartButton(object sender, EventArgs e)
        {
            timer1.Start();            
        }
        
        //_____________________________________________________________
        private void Scramble_Click(object sender, EventArgs e)
        {
           
        }
        private void Timer_Numbers(object sender, EventArgs e)
        {

        }

    }
    
}
