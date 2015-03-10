using System;
using System.Drawing;
using System.Windows.Forms;

namespace DropdownButton
{
    public class DropdownButton : FlatButton
    {
        readonly Button _arrowButton;
        ContextMenuStrip _dropdownMenu;
        bool _hideArrow;

        public ContextMenuStrip Menu
        {
            get { return _dropdownMenu; }
            set { _dropdownMenu = value; }
        }

        public bool HideArrow
        {
            get { return _hideArrow; }
            set
            {
                _hideArrow = value;

                if (_hideArrow)
                {
                    _arrowButton.Visible = false;
                    _arrowButton.Click -= arrowButton_Click;
                    base.Click += arrowButton_Click;
                }
                else
                {
                    _arrowButton.Visible = true;
                    _arrowButton.Click += arrowButton_Click;
                    base.Click -= arrowButton_Click;
                }
            }
        }

        public DropdownButton()
        {
            base.TextAlign = ContentAlignment.MiddleLeft;

            _arrowButton = new FlatButton
            {
                Width = 19,
                Image = Properties.Resources.arrow,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            //_arrowButton.Click += arrowButton_Click;
            Controls.Add(_arrowButton);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _arrowButton.Left = Width - _arrowButton.Width;
            _arrowButton.Height = Height;
            _arrowButton.BackColor = BackColor;
        }

        private void arrowButton_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Click");

            if (_dropdownMenu == null) return;

            Point screenPoint = PointToScreen(new Point(Left, Bottom));

            if (screenPoint.Y + _dropdownMenu.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                _dropdownMenu.Show(this, new Point(0, -(_dropdownMenu.Size.Height + 1)));
            }
            else
            {
                _dropdownMenu.Show(this, new Point(0, Height + 1));
            }
        }

    }
}
