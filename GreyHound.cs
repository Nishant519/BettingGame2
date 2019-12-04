using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BettingGame
{
    public class GreyHound
    {
        public PictureBox Picture { get; set; }
        public string Name { get; set; }

        public GreyHound()
        {

        }

        public GreyHound(PictureBox picture, string name)
        {
            Picture = picture;
            Name = name;
        }

        public void AddGreyhound(PictureBox picture, string name)
        {
            Picture = picture;
            Name = name;
        }
    }
}
