using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BettingGame
{
    public partial class frmBetting : Form
    {
        public frmBetting()
        {
            InitializeComponent();
            punterIntialisation();
            ResetBets();
        }

        Punter[] punters = new Punter[3];//taking 3 punters
        int _flag;//for radio button selection
        private bool _enableRaceBtn = false;
        
        
        public void punterIntialisation()
        {
            punters[0] = PunterFactory.AddPunter("Jessica");
            punters[1] = PunterFactory.AddPunter("John");
            punters[2] = PunterFactory.AddPunter("David");
            //Initiatlly 50 bucks given to all
                Punter1.Text = punters[0].Name + " has 50 bucks";

            Punter2.Text = punters[1].Name + " has 50 bucks";

            Punter3.Text = punters[2].Name + " has 50 bucks";


        }
      
        //on radiobuttonchanged flag changes
        private void Punter1_CheckedChanged(object sender, EventArgs e)
        {
            if (Punter1.Checked)
            {
                this._flag = 1;
                PunterName.Text = this.punters[0].Name;
            }
        }

        private void Punter2_CheckedChanged(object sender, EventArgs e)
        {
            if (Punter2.Checked)
            {
                this._flag = 2;
                PunterName.Text = this.punters[1].Name;
            }
        }

        private void Punter3_CheckedChanged(object sender, EventArgs e)
        {
            if (Punter3.Checked)
            {
                this._flag = 3;
                PunterName.Text = this.punters[2].Name;
            }
        }
        //bet placing 
        public void BetsBtnWorking()
        {            
            int bucksNumber = 0;
            int dogNumber = 0;

            if (!Punter1.Checked && !Punter2.Checked && !Punter3.Checked)
            {
                MessageBox.Show("You must choose atleast one guy to place bet.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bucksNumber = Convert.ToInt32(numBucks.Value);
            dogNumber = Convert.ToInt32(DogNo.Value);

          
            _enableRaceBtn = true; // if at least one bet is placed enable race button then

            GreyHound temp = new GreyHound();
           
            //setting dog to punters
            if (dogNumber == 1)
                temp.AddGreyhound(Dog1, "Dog1");
            else if (dogNumber == 2)
                temp.AddGreyhound(Dog2, "Dog2");
            else if (dogNumber == 3)
                temp.AddGreyhound(Dog3, "Dog3");
            else if (dogNumber == 4)
                temp.AddGreyhound(Dog4, "Dog4");
            else
                MessageBox.Show("Error!, please select valid dog");

            if (this._flag == 1)
            {
                if (this.punters[0].OutOfMoney)
                {
                    MessageBox.Show(punters[0].Name + " is out of money", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Punter1desc.Text = "Busted";
                }
                else
                {
                    this.punters[0].Bet = bucksNumber;
                    this.punters[0].greyhound = temp;
                    
                    this.Punter1desc.Text = punters[0].Name + " has placed "+ punters[0].Bet + " bucks on "+ this.punters[0].greyhound.Name;
                }
            }
            else if (this._flag == 2)
            {
                if (this.punters[1].OutOfMoney)
                {
                    MessageBox.Show(punters[1].Name + " is out of money", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Punter2desc.Text = "Busted";
                }
                else
                {
                    this.punters[1].Bet = bucksNumber;
                    this.punters[1].greyhound = temp;

                    this.Punter2desc.Text = punters[1].Name + " has placed " + punters[1].Bet + " bucks on " + temp.Name;
                }
            }
            else if (this._flag == 3)
            {
                if (this.punters[2].OutOfMoney)
                {
                    MessageBox.Show(punters[2].Name + " is out of money", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Punter3desc.Text = "Busted";
                }
                else
                {
                    this.punters[2].Bet = bucksNumber;
                    this.punters[2].greyhound = temp;

                    this.Punter3desc.Text = punters[2].Name + " has placed " + punters[2].Bet + " bucks on " + temp.Name;
                }
            }
            
        }

        private void betbtn_Click(object sender, EventArgs e)
        {
            try
            {
                BetsBtnWorking();

                if (this._enableRaceBtn)
                    btnRace.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



       
       
        //coding for a reset bets
        public void ResetBets()
        {
            for (int i = 0; i < 3; i++)
            {
                Punter1desc.Text = "Jessica hasn't placed any bets.";
                Punter2desc.Text = "John hasn't placed any bets.";
                Punter3desc.Text = "David hasn't placed any bets.";
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnRace_Click(object sender, EventArgs e)
        {
            GreyHound[] greyhound = new GreyHound[4];
            greyhound[0] = new GreyHound(Dog1, "Dog1");
            greyhound[1] = new GreyHound(Dog2, "Dog2");
            greyhound[2] = new GreyHound(Dog3, "Dog3");
            greyhound[3] = new GreyHound(Dog4, "Dog4");

            Point p0 = new Point(greyhound[0].Picture.Location.X, greyhound[0].Picture.Location.Y);
            Point p1 = new Point(greyhound[1].Picture.Location.X, greyhound[1].Picture.Location.Y);
            Point p2 = new Point(greyhound[2].Picture.Location.X, greyhound[2].Picture.Location.Y);
            Point p3 = new Point(greyhound[3].Picture.Location.X, greyhound[3].Picture.Location.Y);

            Point pp0 = new Point(greyhound[0].Picture.Location.X, greyhound[0].Picture.Location.Y);
            Point pp1 = new Point(greyhound[1].Picture.Location.X, greyhound[1].Picture.Location.Y);
            Point pp2 = new Point(greyhound[2].Picture.Location.X, greyhound[2].Picture.Location.Y);
            Point pp3 = new Point(greyhound[3].Picture.Location.X, greyhound[3].Picture.Location.Y);
            //changing position of pictures
            while (greyhound[0].Picture.Location.X < 362 || greyhound[1].Picture.Location.X < 362 || greyhound[2].Picture.Location.X < 362 || greyhound[3].Picture.Location.X < 362)

            {
                Random rnd = new Random();

                int random = rnd.Next(1, 3);
                p0.X += random;
                greyhound[0].Picture.Location = p0;

                random = rnd.Next(1, 3);
                p1.X += random;
                greyhound[1].Picture.Location = p1;

                random = rnd.Next(1, 3);
                p2.X += random;
                greyhound[2].Picture.Location = p2;

                random = rnd.Next(1, 3);
                p3.X += random;
                greyhound[3].Picture.Location = p3;
            }

            int max = greyhound[0].Picture.Location.X;
            int index = 0;
            for (int i = 1; i < 4; i++)
            {
                if (greyhound[i].Picture.Location.X > max)
                {
                    max = greyhound[i].Picture.Location.X;
                    index = i;
                }
            }

            MessageBox.Show("Dog"+(index+1) + " win");

            for (int j = 0; j < 3; j++)
            {
                Console.Out.WriteLine(index);
                Console.Out.WriteLine(punters[j].greyhound.Name + "  " + greyhound[index].Name);
                if (punters[j].greyhound.Name == greyhound[index].Name)
                {
                    punters[j].Cash = punters[j].Cash + punters[j].Bet;
                }
                else
                {
                    punters[j].Cash -= punters[j].Bet;
                    if (punters[j].Cash == 0)
                    {
                        punters[j].OutOfMoney = true;
                       
                    }
                }
            }
            Punter1.Text = punters[0].Name + " has "+punters[0].Cash+" bucks";

            Punter2.Text = punters[1].Name + " has " + punters[1].Cash + " bucks";

            Punter3.Text = punters[2].Name + " has " + punters[2].Cash + " bucks";

            greyhound[0].Picture.Location = pp0;
            greyhound[1].Picture.Location = pp1;
            greyhound[2].Picture.Location = pp2;
            greyhound[3].Picture.Location = pp3;
            //reset dogs 
            ResetBets();
        }

        private void Dog1_Click(object sender, EventArgs e)
        {

        }

        private void Dog2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
