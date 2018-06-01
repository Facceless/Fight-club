using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fight_club
{
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
    class Presenter
    {
        Player player;
        Player oponent;
        Form1 form;
        string name = "";
        string colums = "";
        ///string condition = "";
        public Presenter(Form1 form)
        {
            this.form = form;
            this.player = new Player();
            this.oponent = new Player();
            form.HitBody += Form_HitBody;
            form.HitHead += Form_HitHead;
            form.HitLegs += Form_HitLegs;
            form.BlockHead += Form_BlockHead;
            form.BlockBody += Form_BlockBody;
            form.BlockLegs += Form_BlockLegs;
            form.Refresh += Form_Refresh;
        }

        private void Form_Refresh(object sender, EventArgs e)
        {
            form.count = 0;
            this.player = new Player();
            this.oponent = new Player();
            form.progressBar1.Value = 100;
            form.progressBar2.Value = 100;
            form.textBox1.Text = "";
            ModifyProgressBarColor.SetState(form.progressBar1, 1);
            ModifyProgressBarColor.SetState(form.progressBar2, 1);
        }

        public void Finish()
        {
            form.textBox1.Text += Environment.NewLine + "Раундов было сыграно " + form.count;
            if (player.Hp < 0) player.Hp = 0;
            if (oponent.Hp < 0) oponent.Hp = 0;
            form.textBox1.Text += Environment.NewLine + "Очки здоровья соперника " + oponent.Hp;
            form.textBox1.Text += Environment.NewLine + "Ваши очки здоровья" + player.Hp;
            form.button1.Enabled = false;
            form.button2.Enabled = false;
            form.button3.Enabled = false;
        }

        private void Form_BlockLegs(object sender, EventArgs e)
        {
            player.SetBlock(2);
            oponent.GetHit(new Random().Next(0, 3));
            if (player.Block != oponent.Hit)
            {
                player.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine + "Вам нанесли удар в ноги \n";
            }
            else form.textBox1.Text += Environment.NewLine + "Удар заблокирован \n" ;
            if (player.Hp <= 0)
            {
                form.textBox1.Text = "К сожалению, вы проиграли\n";
                Finish();
                form.progressBar1.Value = 0;

            }
            else
            {
                form.progressBar1.Value = player.Hp;
                if (player.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar1, 2);
                else
                if (player.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar1, 3);

            }
        }

        private void Form_BlockBody(object sender, EventArgs e)
        {
            player.SetBlock(1);
            oponent.GetHit(new Random().Next(0, 3));
            if (player.Block != oponent.Hit)
            {
                player.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine + "Вам нанесли удар в корпус \n";
            }
            else form.textBox1.Text += Environment.NewLine + "Удар заблокирован \n";
            if (player.Hp <= 0)
            {
                form.textBox1.Text = "К сожалению, вы проиграли\n";
                Finish();
                form.progressBar1.Value = 0;
            }
            else
            {
                form.progressBar1.Value = player.Hp;
                if (player.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar1, 2);
                else
                if (player.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar1, 3);

            }
        }

        private void Form_BlockHead(object sender, EventArgs e)
        {
            player.SetBlock(0);
            oponent.GetHit(new Random().Next(0, 3));
            if (player.Block != oponent.Hit)
            {
                player.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine + "Вам нанесли удар в голову \n";
            }
            else form.textBox1.Text += Environment.NewLine + "Удар заблокирован \n";
            if (player.Hp <= 0)
            {
                form.progressBar1.Value = 0;
                form.textBox1.Text = "К сожалению, вы проиграли\n";
                Finish();
            }
            else
            {
                form.progressBar1.Value = player.Hp;
                if (player.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar1, 2);
                else
                if (player.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar1, 3);


            }
        }

        private void Form_HitLegs(object sender, EventArgs e)
        {
            player.GetHit(2);
            oponent.SetBlock(new Random().Next(0, 3));
            if (player.Hit != oponent.Block)
            {
                oponent.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine + "Вы попали в ногу \n";
            }
            else form.textBox1.Text += Environment.NewLine + "Удар заблокирован \n";
            if (oponent.Hp <= 0)
            {
                form.progressBar2.Value = 0;
                form.textBox1.Text = "Поздравляю, вы победили\n";
                Finish();
            }
            else
            {
                form.progressBar2.Value = oponent.Hp;
                if (oponent.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar2, 2);
                else
                if (oponent.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar2, 3);


            }
        }

        private void Form_HitHead(object sender, EventArgs e)
        {
            player.GetHit(0);
            oponent.SetBlock(new Random().Next(0, 3));
            if (player.Hit != oponent.Block)
            {
                oponent.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine + "Вы попали в голову \n";
            }
            else form.textBox1.Text += Environment.NewLine +  "Удар заблокирован \n";
            if (oponent.Hp <= 0)
            {
                form.progressBar2.Value = 0;
                form.textBox1.Text = "Поздравляю, вы победили\n";
                Finish();
            }
            else
            {
                form.progressBar2.Value = oponent.Hp;
                if (oponent.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar2, 2);
                else
                if (oponent.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar2, 3);

            }
        }

        private void Form_HitBody(object sender, EventArgs e)
        {
            player.GetHit(1);
            oponent.SetBlock(new Random().Next(0, 3));
            if (player.Hit != oponent.Block)
            {
                oponent.Hp -= new Random().Next(7, 10);
                form.textBox1.Text += Environment.NewLine +  "Вы попали в корпус \n";
            }
            else form.textBox1.Text += Environment.NewLine +  "Удар заблокирован \n";
            if (oponent.Hp <= 0)
            {
                form.progressBar2.Value = 0;
                form.textBox1.Text = "Поздравляю, вы победили\n";
                Finish();
            }
            else
            {
                form.progressBar2.Value = oponent.Hp;
                if (oponent.Hp < 25) ModifyProgressBarColor.SetState(form.progressBar2, 2);
                else
                if (oponent.Hp < 50) ModifyProgressBarColor.SetState(form.progressBar2, 3);

            }
        }
    }
}
