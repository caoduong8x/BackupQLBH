using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackupQLBH.MsgBox;
using System.Windows.Forms;

namespace BackupQLBH
{
    internal class Functions
    {
        public static void HienThongBaoLoi(string message)
        {
            MsgBox.Show(message, "Thông Báo", Buttons.OK, BieuTuong.Error);
        }
        public static void HienThongBao(string message)
        {
            MsgBox.Show(message, "Thông Báo", Buttons.OK, BieuTuong.Info);
        }
        public static void HienThongBao(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Buttons btns;
            BieuTuong bieuTuong;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    btns = Buttons.OK;
                    break;
                case MessageBoxButtons.YesNo:
                    btns = Buttons.YesNo;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btns = Buttons.YesNoCancel;
                    break;
                case MessageBoxButtons.OKCancel:
                    btns = Buttons.OKCancel;
                    break;
                case MessageBoxButtons.RetryCancel:
                    btns = Buttons.RetryCancel;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    btns = Buttons.AbortRetryIgnore;
                    break;
                default:
                    btns = Buttons.OK;
                    break;
            }
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    bieuTuong = BieuTuong.Info;
                    break;
                case MessageBoxIcon.Error:
                    bieuTuong = BieuTuong.Error;
                    break;
                case MessageBoxIcon.Warning:
                    bieuTuong = BieuTuong.Warning;
                    break;
                default:
                    bieuTuong = BieuTuong.Info;
                    break;
            }
            MsgBox.Show(message, title, btns, bieuTuong);
        }
        public static DialogResult HoiNguoiDung(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Buttons btns;
            BieuTuong bieuTuong;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    btns = Buttons.OK;
                    break;
                case MessageBoxButtons.YesNo:
                    btns = Buttons.YesNo;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btns = Buttons.YesNoCancel;
                    break;
                case MessageBoxButtons.OKCancel:
                    btns = Buttons.OKCancel;
                    break;
                case MessageBoxButtons.RetryCancel:
                    btns = Buttons.RetryCancel;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    btns = Buttons.AbortRetryIgnore;
                    break;
                default:
                    btns = Buttons.OK;
                    break;
            }
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    bieuTuong = BieuTuong.Info;
                    break;
                case MessageBoxIcon.Error:
                    bieuTuong = BieuTuong.Error;
                    break;
                case MessageBoxIcon.Warning:
                    bieuTuong = BieuTuong.Warning;
                    break;
                case MessageBoxIcon.Question:
                    bieuTuong = BieuTuong.Question;
                    break;
                default:
                    bieuTuong = BieuTuong.Info;
                    break;
            }
            return MsgBox.Show(message, title, btns, bieuTuong);
        }
    }
}
