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
        //受信設定
        private UdpClient udpClientRecv = null;
        private IAsyncResult recvState = null;
        //送信設定
        private UdpClient udpClientSend = null;
        private int remotePort = 30001;
        private string remoteHost = "192.168.1.208";

        private System.Threading.Timer timer;
        private bool sendBtnFlag = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void btn_RecvStart_Click(object sender, EventArgs e)
        {
            if (sendBtnFlag)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                SendBtnAction(false, "送信開始");
            }
            else
            {
                SendBtnAction(true, "送信終了");

                if (udpClientRecv == null)
                {
                    udpClientRecv = new UdpClient(30000);
                }

                timer = new System.Threading.Timer(TimerProc);
                timer.Change(0, 1000);
            }
        }
        private void TimerProc(object state)
        {
            if (recvState == null)
            {
                recvState = udpClientRecv.BeginReceive(RecvCallback, udpClientRecv);
            }
        }
        private void RecvCallback(IAsyncResult ar)
        {
            recvState = null;
            UdpClient udp = (UdpClient)ar.AsyncState;
            IPEndPoint remoteEP = null;
            byte[] recvBytes = udp.EndReceive(ar, ref remoteEP);
            string recvText = "";
            for(int i=0; i< recvBytes.Length; i++)
            {
                recvText += recvBytes[i];
            }

            tbx_RecvData.BeginInvoke(new Action<string>(RecvTextShow), recvText);

            if(udpClientSend == null)
            {
                udpClientSend = new UdpClient();
            }
            udpClientSend.BeginSend(recvBytes, recvBytes.Length, remoteHost, remotePort, SendCallback, udpClientSend);
        }
        private void SendCallback(IAsyncResult ar)
        {
        }
        private void RecvTextShow(string str)
        {
            tbx_RecvData.Text = str + "\r\n" + tbx_RecvData.Text;
        }
        private void SendBtnAction(bool flag, string text)
        {
            sendBtnFlag = flag;
            btn_RecvStart.Text = text;
        }
    }
}
