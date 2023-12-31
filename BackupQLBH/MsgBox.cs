﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupQLBH
{
    public partial class MsgBox : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        private static MsgBox _msgBox;

        // Header, Footer và Icon
        private Panel _plHeader = new Panel();
        private Label _lblTitle;
        private Panel _plFooter = new Panel();
        private Panel _plIcon = new Panel();
        private PictureBox _picIcon = new PictureBox();

        // THông điệp
        private Label _lblMessage;

        // Panel
        private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();

        // List các button
        private List<Button> _buttonCollection = new List<Button>();

        // Kết quả
        private static DialogResult _buttonResult = new DialogResult();

        // Timer hiệu ứng
        private static Timer _timer;

        // Phát tiếng Beep
        /*[DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);*/
        public MsgBox()
        {
            //InitializeComponent();
            //this.Icon = ((System.Drawing.Icon)(QuanLyBanHang.Properties.Resources.icons8_paper_money));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(43, 161, 74);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Width = 400;

            // Header
            _lblTitle = new Label();
            _lblTitle.ForeColor = Color.White;
            _lblTitle.Font = new System.Drawing.Font("Segoe UI", 16);
            _lblTitle.Dock = DockStyle.Top;
            _lblTitle.Height = 36;

            // Thông điệp
            _lblMessage = new Label();
            _lblMessage.ForeColor = Color.White;
            _lblMessage.Font = new System.Drawing.Font("Segoe UI", 13);
            _lblMessage.Dock = DockStyle.Fill;

            _flpButtons.FlowDirection = FlowDirection.RightToLeft;
            _flpButtons.Dock = DockStyle.Fill;

            _plHeader.Dock = DockStyle.Fill;
            _plHeader.Padding = new Padding(2);
            _plHeader.Controls.Add(_lblMessage);
            _plHeader.Controls.Add(_lblTitle);

            _plFooter.Dock = DockStyle.Bottom;
            _plFooter.Padding = new Padding(8);
            //_plFooter.BackColor = Color.FromArgb(37, 37, 38);
            _plFooter.BackColor = Color.DarkGreen;
            //_plFooter.BackColor = Color.FromArgb(43, 161, 74);
            _plFooter.Height = 52;
            _plFooter.Controls.Add(_flpButtons);

            _picIcon.Width = 32;
            _picIcon.Height = 32;
            _picIcon.Location = new Point(10, 36);

            _plIcon.Dock = DockStyle.Left;
            _plIcon.Padding = new Padding(20);
            _plIcon.Width = 42;
            _plIcon.Controls.Add(_picIcon);

            // Add controls vào form
            this.Controls.Add(_plHeader);
            this.Controls.Add(_plIcon);
            this.Controls.Add(_plFooter);
        }

        // Các button sẽ hiển thị lên Msg
        public enum Buttons
        {
            AbortRetryIgnore = 1,
            OK = 2,
            OKCancel = 3,
            RetryCancel = 4,
            YesNo = 5,
            YesNoCancel = 6
        }

        // Các icon thể hiện nội dung của Msg
        public enum BieuTuong
        {
            Application = 1,
            Exclamation = 2,
            Error = 3,
            Warning = 4,
            Info = 5,
            Question = 6,
            Shield = 7,
            Search = 8
        }
        // Hiệu ứng Show Msg
        public enum AnimateStyle
        {
            SlideDown = 1,
            FadeIn = 2,
            ZoomIn = 3
        }
        private static void InitButtons(Buttons buttons)
        {
            switch (buttons)
            {
                case MsgBox.Buttons.AbortRetryIgnore:
                    _msgBox.InitAbortRetryIgnoreButtons();
                    break;

                case MsgBox.Buttons.OK:
                    _msgBox.InitOKButton();
                    break;

                case MsgBox.Buttons.OKCancel:
                    _msgBox.InitOKCancelButtons();
                    break;

                case MsgBox.Buttons.RetryCancel:
                    _msgBox.InitRetryCancelButtons();
                    break;

                case MsgBox.Buttons.YesNo:
                    _msgBox.InitYesNoButtons();
                    break;

                case MsgBox.Buttons.YesNoCancel:
                    _msgBox.InitYesNoCancelButtons();
                    break;
            }

            foreach (Button btn in _msgBox._buttonCollection)
            {
                //btn.ForeColor = Color.FromArgb(170, 170, 170);
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10);
                //btn.Padding = new Padding(2);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 30;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                //btn.FlatAppearance.BorderColor = Color.FromArgb(99, 99, 98);
                btn.FlatAppearance.BorderColor = Color.White;

                _msgBox._flpButtons.Controls.Add(btn);
            }
        }

        private static void InitIcon(BieuTuong icon)
        {
            switch (icon)
            {
                case MsgBox.BieuTuong.Application:
                    _msgBox._picIcon.Image = SystemIcons.Application.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Exclamation:
                    _msgBox._picIcon.Image = SystemIcons.Exclamation.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Error:
                    _msgBox._picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Info:
                    _msgBox._picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Question:
                    _msgBox._picIcon.Image = SystemIcons.Question.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Shield:
                    _msgBox._picIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;

                case MsgBox.BieuTuong.Warning:
                    _msgBox._picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        private void InitAbortRetryIgnoreButtons()
        {
            Button btnAbort = new Button();
            btnAbort.Text = "Abort";
            btnAbort.Click += ButtonClick;

            Button btnRetry = new Button();
            btnRetry.Text = "Retry";
            btnRetry.Click += ButtonClick;

            Button btnIgnore = new Button();
            btnIgnore.Text = "Ignore";
            btnIgnore.Click += ButtonClick;

            this._buttonCollection.Add(btnAbort);
            this._buttonCollection.Add(btnRetry);
            this._buttonCollection.Add(btnIgnore);
        }

        private void InitOKButton()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            this._buttonCollection.Add(btnOK);
        }

        private void InitOKCancelButtons()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;

            this._buttonCollection.Add(btnCancel);
            this._buttonCollection.Add(btnOK);
        }

        private void InitRetryCancelButtons()
        {
            Button btnRetry = new Button();
            btnRetry.Text = "Retry";
            btnRetry.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;

            this._buttonCollection.Add(btnCancel);
            this._buttonCollection.Add(btnRetry);
        }

        private void InitYesNoButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Yes";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "No";
            btnNo.Click += ButtonClick;

            this._buttonCollection.Add(btnNo);
            this._buttonCollection.Add(btnYes);
        }

        private void InitYesNoCancelButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Yes";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "No";
            btnNo.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;

            this._buttonCollection.Add(btnCancel);
            this._buttonCollection.Add(btnNo);
            this._buttonCollection.Add(btnYes);

        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Abort":
                    _buttonResult = DialogResult.Abort;
                    break;

                case "Retry":
                    _buttonResult = DialogResult.Retry;
                    break;

                case "Ignore":
                    _buttonResult = DialogResult.Ignore;
                    break;

                case "OK":
                    _buttonResult = DialogResult.OK;
                    break;

                case "Cancel":
                    _buttonResult = DialogResult.Cancel;
                    break;

                case "Yes":
                    _buttonResult = DialogResult.Yes;
                    break;

                case "No":
                    _buttonResult = DialogResult.No;
                    break;
            }

            _msgBox.Dispose();
            //_msgBox.Close();
        }

        private static Size MessageSize(string message)
        {
            Graphics g = _msgBox.CreateGraphics();
            int width = 350;
            int height = 100;
            int lines = 0;
            //int height = 210;
            Font Segoe13 = new Font("Segoe UI", 13);
            SizeF size = g.MeasureString(message, Segoe13);
            int messWidth = (int)size.Width;

            if (message.Contains('\n'))
            {
                if (message.Length < 150)
                {
                    if (messWidth > 350)
                    {
                        if (messWidth > Screen.PrimaryScreen.WorkingArea.Width)
                            width = 800;
                        else
                            width = messWidth + 62;
                    }
                    width = 350;
                }
                else
                {
                    width = 800;
                }
                string[] dong = message.Split('\n');
                int WidthI;
                for (int i = 0; i < dong.Length; i++)
                {
                    WidthI = (int)g.MeasureString(dong[i], Segoe13).Width;
                    if (WidthI > (width - 62))
                    {
                        lines += WidthI / (width - 62) + 1;
                    }
                    else
                    {
                        lines++;
                    }
                }
            }
            else
            {
                if (message.Length < 150)
                {
                    width = messWidth + 68;
                    //if (messWidth < 300)
                    //{
                    //    width = 350;                        
                    //}
                    //else
                    //{
                    //    width = 800;
                    //}                    
                }
                else
                {
                    width = 800;
                }
                lines = messWidth / (width - 62) + 1;
            }
            height += lines * 36;
            //int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            //if (message.Length < 150)
            //{
            //    height = 210;
            //    if (messWidth > 350)
            //    {
            //        if (messWidth > Screen.PrimaryScreen.WorkingArea.Width)
            //            width = 700;
            //        else
            //            width = (int)size.Width;
            //    }
            //}
            //else
            //{
            //    //string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
            //    ////int lines;
            //    //lines = groups.Length;

            //    //if (groups.Length <= 2)
            //    //{
            //    //    lines = groups.Length + 3;
            //    //}
            //    //else
            //    //{
            //    //    lines = groups.Length + 1;
            //    //}                
            //    //width = 700;
            //    //height += 25 * lines;
            //    //height = (int)(size.Height + 5) * lines + 110;
            //}
            if (height > Screen.PrimaryScreen.WorkingArea.Height)
                return new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            return new Size(width, height);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Color.FromArgb(0, 151, 251));

            g.DrawRectangle(pen, rect);
        }
        static void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            AnimateMsgBox animate = (AnimateMsgBox)timer.Tag;

            switch (animate.Style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    if (_msgBox.Height < animate.FormSize.Height)
                    {
                        _msgBox.Height += 17;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;

                case MsgBox.AnimateStyle.FadeIn:
                    if (_msgBox.Opacity < 1)
                    {
                        _msgBox.Opacity += 0.1;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;

                case MsgBox.AnimateStyle.ZoomIn:
                    if (_msgBox.Width > animate.FormSize.Width)
                    {
                        _msgBox.Width -= 17;
                        _msgBox.Invalidate();
                    }
                    if (_msgBox.Height > animate.FormSize.Height)
                    {
                        _msgBox.Height -= 17;
                        _msgBox.Invalidate();
                    }
                    break;
            }
        }
        public static void Show(string message)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.ShowDialog();
            //MessageBeep(0);
        }

        public static void Show(string message, string title)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox.Size = MsgBox.MessageSize(message);
            _msgBox.ShowDialog();
            //MessageBeep(0);
        }

        public static DialogResult Show(string message, string title, Buttons buttons)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox._plIcon.Hide();

            MsgBox.InitButtons(buttons);

            _msgBox.Size = MsgBox.MessageSize(message);
            _msgBox.ShowDialog();
            //MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, BieuTuong icon)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);
            if (icon == BieuTuong.Error)
            {
                _msgBox._plHeader.BackColor = Color.Red;
                _msgBox._plIcon.BackColor = Color.Red;
            }
            _msgBox.Size = MsgBox.MessageSize(message);
            _msgBox.ShowDialog();
            //MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, BieuTuong icon, AnimateStyle style)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox.Height = 0;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);
            if (icon == BieuTuong.Error)
            {
                _msgBox._plHeader.BackColor = Color.Red;
                _msgBox._plIcon.BackColor = Color.Red;
            }

            _timer = new Timer();
            Size formSize = MsgBox.MessageSize(message);

            switch (style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case MsgBox.AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case MsgBox.AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
            }

            _timer.Tick += timer_Tick;
            _timer.Start();

            _msgBox.ShowDialog();
            //MessageBeep(0);
            return _buttonResult;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            MessageBox.Show(this.Size.Height.ToString());
        }
    }
    class AnimateMsgBox
    {
        public Size FormSize;
        public MsgBox.AnimateStyle Style;

        public AnimateMsgBox(Size formSize, MsgBox.AnimateStyle style)
        {
            this.FormSize = formSize;
            this.Style = style;
        }
    }
}
