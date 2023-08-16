using Caliburn.Micro;
using CyUSB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sam2usb.Models;
using System.IO;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Data.SqlTypes;

namespace sam2usb.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //public USBDeviceList usbDevices;
        //US
        //m usbDevs[0x04B4, 0x8613] as CyUSBDevice;

        private int i = 0;
        private string _srcFile = "file2send";
        private string _dstFile = "file4save";
        private readonly string[] _theUnitList = { "Byte", "KB", "MB" };
        private readonly int[] _chList = { 0, 1, 2 };
        
        private AUSB _selectUsb;
        private BindableCollection<AUSB> _usbDevices = new BindableCollection<AUSB>();
        
        private string _theSelectUnit;
        private BindableCollection<string> _unitList = new BindableCollection<string>();

        private AChannel _theSelectChannel;
        private BindableCollection<AChannel> _ch = new BindableCollection<AChannel>();

        public string SrcFile
        {
            get { return _srcFile; }
            set
            {
                _srcFile = value;
                NotifyOfPropertyChange(() => SrcFile);
            }
        }
        public string DstFile
        {
            get { return _dstFile; }
            set
            {
                _dstFile = value;
                NotifyOfPropertyChange(() => DstFile);
            }
        }

        public AUSB SelectUsb
        {
            get { return _selectUsb; }
            set
            {
                _selectUsb = value;
                NotifyOfPropertyChange(() => SelectUsb);
            }
        }
        public BindableCollection<AUSB> UsbDevices
        {
            get { return _usbDevices; }
            set
            {
                _usbDevices = value;
                NotifyOfPropertyChange(() => UsbDevices);
            }
        }

        public string TheSelectUnit
        {
            get { return _theSelectUnit; }
            set { _theSelectUnit = value; }
        }
        public BindableCollection<string> UnitList
        {
            get { return _unitList; }
            set
            {
                _unitList = value;
                NotifyOfPropertyChange(() => TheSelectUnit);
            }
        }

        public AChannel TheSelectChannel
        {
            get { return _theSelectChannel; }
            set
            {
                _theSelectChannel = value;
                NotifyOfPropertyChange(() => TheSelectChannel);
            }
        }
        public BindableCollection<AChannel> CH
        {
            get { return _ch; }
            set
            {
                _ch = value;
                NotifyOfPropertyChange(() => CH);
            }
        }

        private string SelectFile()
        {
            //var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //    var fileStream = openFileDialog.OpenFile();

                    //    StreamReader reader = new StreamReader(fileStream);
                    //    {
                    //        fileContent = reader.ReadToEnd();
                    //    }
                }
            }

            //if (fileContent != string.Empty)
            //    MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            return filePath;
        }

        public ShellViewModel()
        {
            //Trace.WriteLine("hello");

            //UsbDevices.Clear();
            //AUSB ausb = new AUSB(i)

            DeviceScan();
            //TheSelectUnit = "Byte";
            //TheSelectChannel = 1;

            foreach (var u in _theUnitList) 
            {
                _unitList.Add(u);
            }
            TheSelectUnit = _unitList[0];

            foreach (var ch in _chList)
            {
                AChannel c = new AChannel(ch);
                _ch.Add(c);
            }
            TheSelectChannel = _ch[0];
        }

        public bool CanDeviceScan()
        {
            return true;
        }
        public void DeviceScan()
        {


            UsbDevices.Clear();
            for (int j = 0; j < 5; j++)
            {
                AUSB ausb = new AUSB(j + i, (2 * j + i).ToString());
                UsbDevices.Add(ausb);
            }
            SelectUsb = UsbDevices[0];
            i++;
            if (i > 10) i = 0;



        }

        public void SelectDstFile()
        {
            SrcFile = "file2send";
            DstFile = SelectFile();
            if (string.IsNullOrEmpty(DstFile))
                DstFile = "file4save";
        }

        public void SelectSrcFile()
        {
            DstFile = "file4save";
            SrcFile = SelectFile();
            if (string.IsNullOrEmpty(SrcFile))
                SrcFile = "file2send";
        }

        public void MyDebug()
        {
            MessageBox.Show("The current channel is channel: " + TheSelectChannel.ChID.ToString());
            MessageBox.Show("The curent unit for data counter is " + TheSelectUnit);
        }

    }
}
