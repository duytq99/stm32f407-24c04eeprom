using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace appver1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private StringBuilder initMap = new StringBuilder();
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Int32> baudrateList = new List<int>();
            baudrateList.Add(600);
            baudrateList.Add(1200);
            baudrateList.Add(2400);
            baudrateList.Add(4800);
            baudrateList.Add(9600);
            baudrateList.Add(14400);
            baudrateList.Add(19200);
            baudrateList.Add(38400);
            baudrateList.Add(56000);
            baudrateList.Add(57600);
            baudrateList.Add(112500);
            comboBoxBaudrate.DataSource = new BindingSource(baudrateList, null);
            richTextBoxOutputLogging.ReadOnly = true;
            richTextBoxMemMap.ReadOnly = true;

            for (int i=0; i<512; i++)
            {
                //initMap.AppendLine(String.Format("{ 0,-5} | { 1,-10}", "0x" + i.ToString("X"), 0x00.ToString("X")));
                initMap.AppendLine(String.Format("{0,-5} | {1,-5} | {2,-5}","0x"+i.ToString("X3"), "0x"+00.ToString("X2"), 0.ToString("D3")));
            }
            richTextBoxMemMap.Text = initMap.ToString();

        }
        private void btnFindPort_Click(object sender, EventArgs e)
        {
            comboBoxNamePort.DataSource = SerialPort.GetPortNames();
        }

        private void btnDelPort_Click(object sender, EventArgs e)
        {
            comboBoxNamePort.DataSource = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                labelStatusDisplay.Text = "Disconected";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Red;
            }
            else if (serialPort1.IsOpen)
            {
                labelStatusDisplay.Text = "Connected";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Green;
            }
        }
        private StringBuilder outputLogging = new StringBuilder();
        
        private String addressFrom, addressTo, content;
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!(textBoxAddressFrom.Text=="" | textBoxContent.Text==""))
                {
                    labelStatusDisplay.Text = "Connected - Sending";
                    labelStatusDisplay.ForeColor = System.Drawing.Color.Black;

                    addressFrom = textBoxAddressFrom.Text;
                    outputLogging.AppendLine("[W] Write from: " + addressFrom);
                    content = textBoxContent.Text;
                    outputLogging.AppendLine("[W] Content:" + content);

                    // flag for address
                    serialPort1.Write("w-");
                    serialPort1.Write(addressFrom + "-");
                    // flag for content
                    serialPort1.Write(content + "\n");

                    outputLogging.AppendLine("[W] Transmission done ");
                    richTextBoxOutputLogging.Text = outputLogging.ToString();

                    labelStatusDisplay.Text = "Connected - Sent";
                    labelStatusDisplay.ForeColor = System.Drawing.Color.Green;

                    System.Threading.Thread.Sleep(500); // hàm delay của C#
                    string s = serialPort1.ReadExisting(); // Đọc hết chuỗi được trả về
                    outputLogging.AppendLine(s);
                    richTextBoxOutputLogging.Text = outputLogging.ToString();

                }
                else
                {
                    MessageBox.Show("Please type address and content to write");
                }
            }
            else
            {
                MessageBox.Show("Connect Port first");
            }
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                if (comboBoxNamePort.Text=="")
                {
                    MessageBox.Show("Choose Port Name first");
                }
                else
                {
                    serialPort1.PortName = comboBoxNamePort.Text;
                    serialPort1.Parity = Parity.None;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.BaudRate = Int32.Parse(comboBoxBaudrate.Text);
                    serialPort1.Encoding = Encoding.GetEncoding(28591);
                    serialPort1.Open();
                    btnConnect.Text = "Disconnect";

                    
                }

            }
            else if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btnConnect.Text = "Connect";
            }
            
        }

        private void richTextBoxOutputLogging_TextChanged(object sender, EventArgs e)
        {
            richTextBoxOutputLogging.SelectionStart = richTextBoxOutputLogging.Text.Length;
            richTextBoxOutputLogging.ScrollToCaret();
        }

        private void btnClearAddress_Click(object sender, EventArgs e)
        {
            textBoxAddressFrom.Clear();
        }

        private void btnClearContent_Click(object sender, EventArgs e)
        {
            textBoxContent.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClearAddressTo_Click(object sender, EventArgs e)
        {
            textBoxAddressTo.Clear();
        }
        StringBuilder rxString = new StringBuilder();
        private void btnReadMem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!(textBoxAddressFrom.Text==""))
                {
                    if ((textBoxAddressTo.Text == "")) // doc 1 o
                    {
                        addressFrom = textBoxAddressFrom.Text;
                        outputLogging.AppendLine("[R] Read eeprom at 0x" + addressFrom);
                        
                        // flag for address
                        serialPort1.Write("r-1-");
                        serialPort1.Write(addressFrom);
                        // end of line command 
                        serialPort1.Write("\n");

                        outputLogging.AppendLine("[R] Transmission done ");
                        richTextBoxOutputLogging.Text = outputLogging.ToString();

                        labelStatusDisplay.Text = "Connected - Read";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Green;


                    }
                    else // doc nhieu o nho
                    {
                        addressFrom = textBoxAddressFrom.Text;
                        addressTo = textBoxAddressTo.Text;
                        outputLogging.AppendLine("[R] Read from 0x" + addressFrom);
                        outputLogging.AppendLine("[R] To 0x" + addressTo);

                        // flag for address
                        serialPort1.Write("r-n-");
                        serialPort1.Write(addressFrom + "-" + addressTo);
                        // flag for content
                        serialPort1.Write("\n");

                        outputLogging.AppendLine("[R] Transmission done ");
                        richTextBoxOutputLogging.Text = outputLogging.ToString();

                        labelStatusDisplay.Text = "Connected - Sent";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Green;
                    }
                    
                    System.Threading.Thread.Sleep(300); // hàm delay của C#
                    string s = serialPort1.ReadExisting(); // Đọc hết chuỗi được trả về

                    rxString.Clear();
                    rxString.Append("[R] Content: \n");
                    for (int i = 0; i < s.Length; i++)
                    {
                        if ((s[i] < 127) & (s[i] >= 20))
                            rxString.Append(s[i].ToString());
                        else
                            rxString.Append(" ");
                    }
                    outputLogging.AppendLine(rxString.ToString()+"\n");
                    richTextBoxOutputLogging.Text = outputLogging.ToString();



                }
                else
                {
                    MessageBox.Show("Please type begining address to read");
                }
            }
            else
            {
                MessageBox.Show("Connect Port first");
            }
        }

        private void textBoxAddressFrom_TextChanged(object sender, EventArgs e)
        {
            labelStatusDisplay.Text = "Connected - Typing...";
            labelStatusDisplay.ForeColor = System.Drawing.Color.Black;
            if (textBoxAddressFrom.Text.Length>3)
            {
                MessageBox.Show("Invalid address. Address range: 0x000 - 0x1FF");
                textBoxAddressFrom.Clear();
            }
            if (textBoxAddressFrom.Text.Length == 3)
            { 
                if (textBoxAddressFrom.Text[0] > '1')
                {
                    MessageBox.Show("Invalid address. Address range: 0x000 - 0x1FF");
                    textBoxAddressFrom.Clear();
                }

            }
            foreach (char c in textBoxAddressFrom.Text)
            {
                int asciiCode = c;
                if (!((asciiCode>=48 & asciiCode<=57) | (asciiCode>=65 & asciiCode<=70) | (asciiCode >= 97 & asciiCode <= 102)))
                {
                    MessageBox.Show("Invalid address. Please enter hexadecimal characters");
                    textBoxAddressFrom.Clear();
                }    
            }    
        }

        private void textBoxAddressTo_TextChanged(object sender, EventArgs e)
        {
            labelStatusDisplay.Text = "Connected - Typing...";
            labelStatusDisplay.ForeColor = System.Drawing.Color.Black;

            if (textBoxAddressTo.Text.Length > 3)
            {
                MessageBox.Show("Invalid address. Address range: 0x000 - 0x1FF");
                textBoxAddressTo.Clear();
            }
            if (textBoxAddressTo.Text.Length == 3)
            {
                if (textBoxAddressTo.Text[0] > '1')
                {
                    MessageBox.Show("Invalid address. Address range: 0x000 - 0x1FF");
                    textBoxAddressTo.Clear();
                }
            }

                foreach (char c in textBoxAddressTo.Text)
            {
                int asciiCode = c;
                if (!((asciiCode >= 48 & asciiCode <= 57) | (asciiCode >= 65 & asciiCode <= 70) | (asciiCode >= 97 & asciiCode <= 102)))
                {
                    MessageBox.Show("Invalid address. Please clear and retype");
                    textBoxAddressTo.Clear();
                }
            }
        }

        private void btnDelAll_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                labelStatusDisplay.Text = "Connected - Deleting";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Black;

                
                outputLogging.AppendLine("[D] Delete all");
                content = textBoxContent.Text;

                // flag for command
                serialPort1.Write("d-");
                // flag for type
                serialPort1.Write("a\n");

                outputLogging.AppendLine("[D] Deleted ");
                richTextBoxOutputLogging.Text = outputLogging.ToString();

                labelStatusDisplay.Text = "Connected - Deleted";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Green;

                System.Threading.Thread.Sleep(200); // hàm delay của C#
                string s = serialPort1.ReadExisting(); // Đọc hết chuỗi được trả về
                outputLogging.AppendLine(s);
                richTextBoxOutputLogging.Text = outputLogging.ToString();
            }
            else
            {
                MessageBox.Show("Connect Port first");
            }
        }

        private void textBoxContent_TextChanged(object sender, EventArgs e)
        {
            labelStatusDisplay.Text = "Connected - Typing...";
            labelStatusDisplay.ForeColor = System.Drawing.Color.Black;

            if (textBoxContent.TextLength>512)
            {
                MessageBox.Show("Out of eeprom memory. Only less or equal to 512 bytes-length string is available ");
                textBoxContent.Clear();
            }

            foreach (char c in textBoxContent.Text)
            {
                int asciiCode = c;
                if (!(asciiCode >= 1 & asciiCode <= 127))
                {
                    MessageBox.Show("Invalid content. Please enter ascii char");
                    textBoxContent.Clear();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClearWindow_Click(object sender, EventArgs e)
        {
            outputLogging.Clear();
            richTextBoxOutputLogging.Clear();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                
                labelStatusDisplay.Text = "Connected - Scanning";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Black;


                outputLogging.AppendLine("[S] Scanning memory map of EEPROM");

                // flag for command
                serialPort1.Write("s");
                serialPort1.Write("\n");
                //serialPort1.Write("_");

                outputLogging.AppendLine("[S] Transmission done ");
                richTextBoxOutputLogging.Text = outputLogging.ToString();

                serialPort1.Encoding = Encoding.GetEncoding(28591);

                System.Threading.Thread.Sleep(100); // hàm delay của C#
                string s = serialPort1.ReadExisting(); // Đọc hết chuỗi được trả về

                if (s.Length != 512)
                // if (false)
                {
                    MessageBox.Show("Invalid received memory map");
                    serialPort1.DiscardInBuffer();
                }
                else
                {
                    labelStatusDisplay.Text = s.Length.ToString();
                    displayMemMap(s);
                }
                labelStatusDisplay.Text = "Connected - Scanned";
                labelStatusDisplay.ForeColor = System.Drawing.Color.Green;
                
            }
            else
            {
                MessageBox.Show("Connect Port first");
            }
        }
        private StringBuilder memoryMap = new StringBuilder();
        private void displayMemMap(string s)
        {
            for (int i=0; i< 512; i++)
            {
                if ((s[i]<127) & (s[i] >=20))
                    memoryMap.AppendLine(String.Format("{0,-5} | {1,-5} | {2,-5} | {3,-5}", "0x" + i.ToString("X3"), "0x" + ((int)s[i]).ToString("X2"), ((int)s[i]).ToString("D3"), s[i].ToString()));
                else
                    memoryMap.AppendLine(String.Format("{0,-5} | {1,-5} | {2,-5} | ", "0x" + i.ToString("X3"), "0x" + ((int)s[i]).ToString("X2"), ((int)s[i]).ToString("D3")));

            }
            outputLogging.AppendLine("[S] Scanned "+ s.Length.ToString() + " bytes\n");
            richTextBoxOutputLogging.Text = outputLogging.ToString();
            richTextBoxMemMap.Clear();
            richTextBoxMemMap.Text = memoryMap.ToString();
            memoryMap.Clear();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if ((textBoxAddressFrom.Text == ""))
                {
                    MessageBox.Show("Please type address to be deleted");
                }
                else 
                {
                    if (!(textBoxAddressTo.Text =="")) // xoa tu o .. toi o ..
                    {
                        labelStatusDisplay.Text = "Connected - Deleting";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Black;


                        outputLogging.AppendLine("[D] Delete at 0x" + textBoxAddressFrom.Text + " to 0x" + textBoxAddressTo.Text);

                        // flag for command
                        serialPort1.Write("d-n-");
                        // flag for type
                        serialPort1.Write(textBoxAddressFrom.Text + "-" + textBoxAddressTo.Text + "\n");

                        outputLogging.AppendLine("[D] Deleted ");
                        richTextBoxOutputLogging.Text = outputLogging.ToString();

                        labelStatusDisplay.Text = "Connected - Deleted";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Green;

                        
                    }
                    else // xoa 1 o
                    {
                        labelStatusDisplay.Text = "Connected - Deleting";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Black;


                        outputLogging.AppendLine("[D] Delete at 0x" + textBoxAddressFrom.Text);
                        content = textBoxContent.Text;

                        // flag for command
                        serialPort1.Write("d-1-");
                        // flag for type
                        serialPort1.Write(textBoxAddressFrom.Text + "\n");

                        outputLogging.AppendLine("[D] Deleted ");
                        richTextBoxOutputLogging.Text = outputLogging.ToString();

                        labelStatusDisplay.Text = "Connected - Deleted";
                        labelStatusDisplay.ForeColor = System.Drawing.Color.Green;

                        
                    }
                    System.Threading.Thread.Sleep(200); // hàm delay của C#
                    string s = serialPort1.ReadExisting(); // Đọc hết chuỗi được trả về
                    outputLogging.AppendLine(s);
                    richTextBoxOutputLogging.Text = outputLogging.ToString();
                }
            }
            else
            {
                MessageBox.Show("Connect Port first");
            }
        }

        private void labelAddress_Click(object sender, EventArgs e)
        {

        }
    }
}
