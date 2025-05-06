using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NModbus;

namespace CommonLibraryB.Manager.ModbusTcp.Master
{
    public class TcpMasterConfig
    {
        [Required]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)")]
        public string Ip { get; set; }

        [Required]
        [Range(0, 65535)]
        public int Port { get; set; }

        public string deviceName { get; set; }

        public TcpClient tcpClient { get; set; }

        public IModbusFactory modbusFactory { get; set; }

        public IModbusMaster master { get; set; }

        public TcpMasterConfig(string deviceName, string Ip = "127.0.0.1", int Port = 1883)
        {
            this.deviceName = deviceName;
            this.Ip = Ip;
            this.Port = Port;

            tcpClient = new TcpClient();
            modbusFactory = new ModbusFactory();
        }

        public async Task<bool> connectAsync()
        {
            try
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                    tcpClient = new TcpClient();
                }

                await tcpClient.ConnectAsync(Ip, Port);
                master = modbusFactory.CreateMaster(tcpClient);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool disConnect()
        {
            try
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
