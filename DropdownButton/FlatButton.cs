using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DropdownButton
{
    public enum Styles
    {
        Default, //0
        Primary, //1
        Success, //2
        Info,    //3
        Warning, //4
        Danger,  //5
        Custom   //6
    }

    //Simple flat button based on Button
    public class FlatButton : Button
    {
        private Styles _style;

        [Browsable(true)]
        public Styles Style
        {
            get { return _style; }
            set
            {
                _style = value;
                if (Style != Styles.Custom)
                {
                    BackColor = GetColor();
                }
            }
        }

        //Color presets
        private readonly Color[] Colors =
        {
            Color.DarkGray,
            Color.DodgerBlue,
            Color.LimeGreen,
            Color.DeepSkyBlue,
            Color.Chocolate,
            Color.Crimson
        };

        public FlatButton()
        {
            MakeFlat(this);
            Style = Styles.Default;
        }

        protected void MakeFlat(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            button.BackColor = GetColor();
            button.ForeColor = Color.White;

            button.Size = new Size(85, 27);
        }

        private Color GetColor()
        {
            return Colors[(int)Style];
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            FlatAppearance.BorderColor = BackColor;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (!Colors.Contains(BackColor))
            {
                Style = Styles.Custom;
            }
            else
            {
                Style = (Styles)Array.IndexOf(Colors, BackColor);
            }
        }


    }
}
