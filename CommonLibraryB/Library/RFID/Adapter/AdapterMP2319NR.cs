using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NLog.Filters;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public partial class AdapterMP2319NR
    {
        enum EGetOperate
        {
            RFID
        }

        void getCmd(EGetOperate operate, RFIDPackage t)
        {
            switch(operate)
            {
                case EGetOperate.RFID:
                    cmdRFID(t);
                    break;
            }
        }

        void cmdRFID(RFIDPackage t)
        {
            List<byte> sub1 = new List<byte>()
            {
                0x00,
                0x70,
                0x08,
                0x77,
                0x00,
                0x00,
                0x01,
                0x00,
                0x01,
                0x01,
                0x11,
            };

            byte edc = getXorResult(sub1);

            sub1.Add(edc);

            t.cmd = sub1.ToArray();

        }
    }

    public partial class AdapterMP2319NR
    {
        void unpack(EGetOperate operate, RFIDPackage t)
        {
            switch(operate)
            {
                case EGetOperate.RFID:
                    upRFID(t);
                    break;
            }
        }

        void upRFID(RFIDPackage t)
        {
            if (t.rcmd[3] == 0x00 && t.rcmd[140] == 0x90 && t.rcmd[141] == 0x00)
            {
                byte[] data = t.rcmd.Skip(4).Take(136).ToArray();

                byte[] filter = data.Where(b => b != 0x00).ToArray();

                string result = Encoding.ASCII.GetString(filter);

                t.property.RFID = result;
            }
            else
            {
                t.property.RFID = string.Empty;
            }
        }
    }

    public partial class AdapterMP2319NR
    {
        enum ESetOperate
        {
            Buzzer
        }

        void getCmd(ESetOperate operate, RFIDPackage t, bool sw = false)
        {
            switch(operate)
            {
                case ESetOperate.Buzzer:
                    cmdBuzzer(t, sw);
                    break;
            }
        }

        void cmdBuzzer(RFIDPackage t, bool sw)
        {
            List<byte> sub1 = new List<byte>()
            {
                0x00,
                0x70,
                0x06,
                0x77,
                0x00,
                0x00,
                0xA2,
                0x00,
            };

            if (sw)
            {
                sub1.Add(0x01);
            }
            else
            {
                sub1.Add(0x00);
            }

            byte edc = getXorResult(sub1);

            sub1.Add(edc);

            t.cmd = sub1.ToArray();
        }
    }

    public partial class AdapterMP2319NR : IRFIDOperate<RFIDPackage>
    {
        public async Task<bool> GetRFIDAsync(RFIDPackage t)
        {
            try
            {
                getCmd(EGetOperate.RFID, t);

                t.port.Write(t.cmd, 0, t.cmd.Length);

                await Task.Delay(1000);

                t.rcmd = new byte[200];
                t.port.Read(t.rcmd, 0, t.rcmd.Length);

                unpack(EGetOperate.RFID, t);
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRFIDBuzzer(RFIDPackage t, bool sw)
        {
            try
            {
                getCmd(ESetOperate.Buzzer, t, sw);

                t.port.Write(t.cmd, 0, t.cmd.Length);

                await Task.Delay(1000);

                t.rcmd = new byte[100];
                t.port.Read(t.rcmd, 0, t.rcmd.Length);

                if (t.rcmd[3] == 0x00)
                {
                    return true;
                }
                else
                {
                    setException("Set buzzer fail");
                    return false;
                }
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }
    }

    public partial class AdapterMP2319NR
    {
        void setException(string msg)
        {
            throw new InvalidOperationException(msg);
        }

        byte getXorResult(List<byte> data)
        {
            return data.Aggregate((a, b) => (byte)(a ^ b));
        }
    }


}
