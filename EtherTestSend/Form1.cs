using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace EtherTestSend
{
    public partial class Form1 : Form
    {
        ////受信設定
        private UdpClient udpClientRecv = null;
        private IAsyncResult recvState = null;
        private IPEndPoint mitCastPoint = new IPEndPoint(IPAddress.Parse("239.0.0.0"), 0);
        private byte[] recvBytes = new byte[3];
        ////送信設定
        private byte[] sendBytes = new byte[3] { 0x00, 0x25, 0xA2 };
        private UdpClient udpClientSend = null;
        private IPEndPoint semdEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.208"), 30000);

        private System.Threading.Timer timer;
        private bool recvBtnFlag = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void btn_SendStart_Click(object sender, EventArgs e)
        {
            if (recvBtnFlag)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                RecvBtnAction(false, "受信開始");
            }
            else
            {
                RecvBtnAction(true, "受信終了");

                //送信設定
                if (udpClientSend == null)
                {
                    udpClientSend = new UdpClient();
                    udpClientSend.JoinMulticastGroup(mitCastPoint.Address, 50);
                }
                //受信設定
                if (udpClientRecv == null)
                {
                    udpClientRecv = new UdpClient(30001);
                }

                timer = new System.Threading.Timer(TimerProc);
                timer.Change(0, 1000);
            }
        }
        private void TimerProc(object state)
        {
            //送信
            IAsyncResult sending = udpClientSend.BeginSend(sendBytes, sendBytes.Length, semdEndPoint, SendCallback, udpClientSend);

            //受信開始
            if (recvState == null)
            {
                recvState = udpClientRecv.BeginReceive(RecvCallback, udpClientRecv);
            }
        }
        private void RecvCallback(IAsyncResult ar)
        {
            recvState = null;   //受信解除
            UdpClient udp = (UdpClient)ar.AsyncState;
            IPEndPoint remoteEP = null;
            recvBytes = udp.EndReceive(ar, ref remoteEP);

            string recvText = "";
            for (int i = 0; i < recvBytes.Length; i++)
            {
                recvText += recvBytes[i] + ",";
            }
            tbx_RecvData.BeginInvoke(new Action<string>(RecvTextShow), recvText);
        }
        private void SendCallback(IAsyncResult ar)
        {
        }
        private void RecvTextShow(string str)
        {
            tbx_RecvData.Text = str + "\r\n" + tbx_RecvData.Text;
        }
        private void RecvBtnAction(bool flag, string text)
        {
            recvBtnFlag = flag;
            btn_SendStart.Text = text;
        }
    }
}
