using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Tools.TypeConverter
{
    public static class IntUshortConverter
    {
        public static void IntToUshortArray(int data, EEndian outputEndianType, out ushort[] result)
        {
            byte[] arrByte = BitConverter.GetBytes(data);

            if ((BitConverter.IsLittleEndian && outputEndianType == EEndian.BigEndian) ||
               (!BitConverter.IsLittleEndian && outputEndianType == EEndian.LittleEndian))
            {
                Array.Reverse(arrByte);
            }

            ushort[] res = new ushort[2];
            Buffer.BlockCopy(arrByte, 0, res, 0, 4);

            result = res;
        }

        public static void UshortArrayToInt(ushort[] data, EEndian inputEndianType, out int result)
        {
            if (data == null || data.Length < 2)
                throw new ArgumentException("Ushort array length not equal to 2 at UshortArrayToInt method");

            byte[] bytes = new byte[4];
            Buffer.BlockCopy(data, 0, bytes, 0, 4);

            if ((BitConverter.IsLittleEndian && inputEndianType == EEndian.BigEndian) ||
               (!BitConverter.IsLittleEndian && inputEndianType == EEndian.LittleEndian))
            {
                Array.Reverse(bytes);
            }

            int res = BitConverter.ToInt32(bytes, 0);
            result = res;
        }
    }
}
