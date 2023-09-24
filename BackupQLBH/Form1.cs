using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BackupQLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void CopyFile(string TenFile, string TenFolder)
        {
            try
            {
                string text = this.txtDes.Text + "\\" + TenFolder;
                FileInfo _source = new FileInfo(TenFile);
                FileInfo _destination = new FileInfo(text + "\\" + TenFile);
                bool exists = _destination.Exists;
                if (exists)
                {
                    _destination.Delete();
                }
                bool flag = !Directory.Exists(text);
                if (flag)
                {
                    Directory.CreateDirectory(text);
                }
                Task.Run(delegate ()
                {
                    _source.CopyTo(_destination, delegate (int x)
                    {
                        this.progressBar1.BeginInvoke(new Action(delegate ()
                        {
                            this.progressBar1.Value = x;
                            this.lblPercent.Text = x.ToString() + "%";
                        }));
                    });
                }).GetAwaiter().OnCompleted(delegate
                {
                    this.progressBar1.BeginInvoke(new Action(delegate ()
                    {
                        this.progressBar1.Value = 100;
                        this.lblPercent.Text = "100%";
                    }));
                });
            }
            catch (Exception ex)
            {
                Functions.HienThongBao(ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            lblSaoLuu.Visible = true;
            btnSaoLuu.Enabled = false;
            btnClose.Enabled = false;
            this.Update();
        Start:
            if (this.txtDes.Text.Trim() == "")
            {
                lblSaoLuu.Visible = false;
                Functions.HienThongBao("Bạn phải chọn nơi sao lưu dữ liệu trước khi sao lưu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
                selectDes();
                btnSaoLuu.Enabled = true;
                btnClose.Enabled = true;
                return;
            }
            string dataFileName = "Quanlybanhang.mdf";
            string logFileName = "Quanlybanhang_log.ldf";
            if (!File.Exists(dataFileName))
            {
                Functions.HienThongBao("Không tìm thấy File Quanlybanhang.mdf trong thư mục: " + Directory.GetCurrentDirectory().ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (!File.Exists(logFileName))
            {
                Functions.HienThongBao("Không tìm thấy File Quanlybanhang_log.ldf!" + Directory.GetCurrentDirectory().ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            string dateTimeStr = getDateTimeString();
            
            this.CopyFile(dataFileName, dateTimeStr);
            this.progressBar1.Value = 0;
            this.lblPercent.Text = "";
            this.CopyFile(logFileName, dateTimeStr);
            string fileName = this.txtDes.Text + "\\" + dateTimeStr;
            string fileData = fileName + "\\" + dataFileName;
            string fileLog = fileName + "\\" + logFileName;

            Thread.Sleep(500);
            if (File.Exists(fileData) && File.Exists(fileLog))
            {
                if (chkSendMail.Checked)
                {
                    string zipFileName = fileName + "\\" + dateTimeStr + ".zip";
                Zip:
                    CompressDirectory(fileName, zipFileName, 9);
                    if (File.Exists(zipFileName))
                    {
                        MailMessage mail = new MailMessage();
                        string to = "caoduong.it8x@gmail.com";
                        string from = "caongan.it8x@gmail.com";
                        string pass = "hthj utkq hmsq wnmj";

                        string subject = "Backup Database " + dateTimeStr;
                        mail.To.Add(to);
                        mail.From = new MailAddress(from);
                        mail.Subject = subject;
                        mail.Body = subject;

                        mail.Attachments.Add(new Attachment(zipFileName));

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);

                        try
                        {
                            smtp.Send(mail);
                            Functions.HienThongBao("Sao Lưu Và Gửi Email (caoduong.it8x@gmail.com) Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        catch (Exception ex)
                        {
                            Functions.HienThongBao(ex.ToString());
                        }
                    }
                    else
                    {
                        if (Functions.HoiNguoiDung("Nén File Thất Bại! Bạn Có Muốn Nén File Lại Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            goto Zip;
                        }
                    }
                }
                else
                {
                    Functions.HienThongBao("Sao Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else
            {
                if (Functions.HoiNguoiDung("Sao Lưu Thất Bại! Bạn Có Muốn Sao Lưu Lại Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    goto Start;
                }
            }

            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                Functions.HienThongBao(ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            Application.Exit();
        }

        private string getDateTimeString()
        {
            DateTime now = DateTime.Now;
            string hour, minute, second, day, month;

            if (now.Hour < 10)
            {
                hour = "0" + now.Hour.ToString();
            }
            else
            {
                hour = now.Hour.ToString();
            }

            if (now.Minute < 10)
            {
                minute = "0" + now.Minute.ToString();
            }
            else
            {
                minute = now.Minute.ToString();
            }

            if (now.Second < 10)
            {
                second = "0" + now.Second.ToString();
            }
            else
            {
                second = now.Second.ToString();
            }

            if (now.Day < 10)
            {
                day = "0" + now.Day.ToString();
            }
            else
            {
                day = now.Day.ToString();
            }
            if (now.Month < 10)
            {
                month = "0" + now.Month.ToString();
            }
            else
            {
                month = now.Month.ToString();
            }

            return string.Concat(new string[]
            {
                now.Year.ToString(),
                month,
                day,
                "_",
                hour,
                minute,
                second
            });            
        }

        private void CompressDirectory(string DirectoryPath, string OutputFilePath, int CompressionLevel = 9)
        {
            try
            {
                string[] filenames = Directory.GetFiles(DirectoryPath);
                using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
                {
                    OutputStream.SetLevel(CompressionLevel);
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        OutputStream.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;

                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                OutputStream.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    OutputStream.Finish();
                    OutputStream.Close();
                    Console.WriteLine("Files successfully compressed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
            }
        }

        private void btnSelectDes_Click(object sender, EventArgs e)
        {
            selectDes();
        }
        private void selectDes()
        {
            this.folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult dialogResult = this.folderBrowserDialog1.ShowDialog();
            bool flag = dialogResult == DialogResult.OK;
            if (flag)
            {
                this.txtDes.Text = this.folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder rootFolder = this.folderBrowserDialog1.RootFolder;
                XmlTextWriter xmlTextWriter = new XmlTextWriter("location.xml", null);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteElementString("text", this.folderBrowserDialog1.SelectedPath);
                xmlTextWriter.WriteEndDocument();
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string url = "location.xml";
                XmlTextReader xmlTextReader = new XmlTextReader(url);
                while (xmlTextReader.Read())
                {
                    bool flag = xmlTextReader.NodeType == XmlNodeType.Text;
                    if (flag)
                    {
                        this.txtDes.Text = xmlTextReader.Value;
                        xmlTextReader.Close();
                    }
                }
                xmlTextReader.Close();
            }
            catch
            {
                Functions.HienThongBao("Bạn chưa chọn nơi sao lưu dữ liệu.","Hệ Thống", MessageBoxButtons.OK,MessageBoxIcon.Information);
                selectDes();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
