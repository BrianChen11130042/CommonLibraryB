using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NModbus;

namespace CommonLibraryB.Manager.ModbusTcp.Master
{
    public class ModbusTcpMasterConfig
    {
        [Required]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)")]
        public string Ip { get; set; } = "127.0.0.1";

        [Required]
        [Range(0, 65535)]
        public int Port { get; set; } = 502;

        public string deviceName { get; set; }

        [JsonIgnore]
        public TcpClient tcpClient { get; set; }

        [JsonIgnore]
        public IModbusFactory modbusFactory { get; set; }

        [JsonIgnore]
        public IModbusMaster modbusTcpMaster { get; set; }

        public async Task<bool> connectAsync()
        {
            try
            {
                if (tcpClient == null)
                    tcpClient = new TcpClient();

                if (modbusFactory == null)
                    modbusFactory = new ModbusFactory();

                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                    tcpClient = new TcpClient();
                }

                await tcpClient.ConnectAsync(Ip, Port);
                modbusTcpMaster = modbusFactory.CreateMaster(tcpClient);
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
