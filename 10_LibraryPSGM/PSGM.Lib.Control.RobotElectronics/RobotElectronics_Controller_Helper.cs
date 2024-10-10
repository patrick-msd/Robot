using System.Collections;

namespace PSGM.Lib.Control.RobotElectronics
{
    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }

    public partial class RobotElectronics_Controller
    {
        double ByteArrayToDouble(byte[] bytes)
        {
            //System.Diagnostics.Debug.Assert(bytes.Length == 4);
            uint result = (uint)bytes[1] + ((uint)bytes[0] << 8);

            return Convert.ToDouble(result);
        }

        /// <summary>
        /// Convert Byte Array To Bool Array
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static bool[] ConvertByteArrayToBoolArray(byte[] bytes)
        {
            //BitArray b = new BitArray(bytes);
            //bool[] bitValues = new bool[b.Count];
            //b.CopyTo(bitValues, 0);
            //Array.Reverse(bitValues);
            //return bitValues;

            BitArray b;

            bool[] b1 = new bool[8];
            bool[] b2 = new bool[8];
            bool[] b3 = new bool[8];
            bool[] b4 = new bool[8];

            bool[] bitValues = new bool[32];

            b = new BitArray(new byte[] { bytes[3] });
            b.CopyTo(b1, 0);
            //Array.Reverse(b1);
            b1.CopyTo(bitValues, 0);

            b = new BitArray(new byte[] { bytes[2] });
            b.CopyTo(b2, 0);
            //Array.Reverse(b2);
            b2.CopyTo(bitValues, 8);

            b = new BitArray(new byte[] { bytes[1] });
            b.CopyTo(b3, 0);
            //Array.Reverse(b3);
            b3.CopyTo(bitValues, 16);

            b = new BitArray(new byte[] { bytes[0] });
            b.CopyTo(b4, 0);
            //Array.Reverse(b4);
            b4.CopyTo(bitValues, 24);

            return bitValues;
        }

        /// <summary>
        /// Packs a bit array into bytes, most significant bit first
        /// </summary>
        /// <param name="boolArr"></param>
        /// <returns></returns>
        public static byte[] ConvertBoolArrayToByteArray(bool[] boolArr)
        {
            int byteArraySize = (boolArr.Length + 7) / 8;
            byte[] byteArr = new byte[byteArraySize];

            for (int i = 0; i < byteArraySize; i++)
            {
                bool[] tmp = boolArr.SubArray(i * 8, 8);
                Array.Reverse(tmp);
                byteArr[i] = ConvertBoolArrayToByte(tmp);
            }

            return byteArr;
        }

        private static byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            int index = 8 - source.Length;

            // Loop through the array
            foreach (bool b in source)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }












        public static uint[] ConvertByteArrayToCounter(byte[] bytes)
        {
            uint result1 = (uint)bytes[3] + ((uint)bytes[2] << 8) + ((uint)bytes[1] << 16) + ((uint)bytes[0] << 24);
            uint result2 = (uint)bytes[7] + ((uint)bytes[6] << 8) + ((uint)bytes[5] << 16) + ((uint)bytes[4] << 24); ;

            //BitArray b;

            //bool[] b1 = new bool[8];
            //bool[] b2 = new bool[8];
            //bool[] b3 = new bool[8];
            //bool[] b4 = new bool[8];

            //bool[] b5 = new bool[8];
            //bool[] b6 = new bool[8];
            //bool[] b7 = new bool[8];
            //bool[] b8 = new bool[8];

            //bool[] bitValues1 = new bool[32];
            //bool[] bitValues2 = new bool[32];

            //b = new BitArray(new byte[] { bytes[3] });
            //b.CopyTo(b1, 0);
            ////Array.Reverse(b1);
            //b1.CopyTo(bitValues1, 0);

            //b = new BitArray(new byte[] { bytes[2] });
            //b.CopyTo(b2, 0);
            ////Array.Reverse(b2);
            //b2.CopyTo(bitValues1, 8);

            //b = new BitArray(new byte[] { bytes[1] });
            //b.CopyTo(b3, 0);
            ////Array.Reverse(b3);
            //b3.CopyTo(bitValues1, 16);

            //b = new BitArray(new byte[] { bytes[0] });
            //b.CopyTo(b4, 0);
            ////Array.Reverse(b4);
            //b4.CopyTo(bitValues1, 24);


            //b = new BitArray(new byte[] { bytes[7] });
            //b.CopyTo(b5, 0);
            ////Array.Reverse(b1);
            //b5.CopyTo(bitValues2, 0);

            //b = new BitArray(new byte[] { bytes[6] });
            //b.CopyTo(b6, 0);
            ////Array.Reverse(b2);
            //b6.CopyTo(bitValues2, 8);

            //b = new BitArray(new byte[] { bytes[6] });
            //b.CopyTo(b7, 0);
            ////Array.Reverse(b3);
            //b7.CopyTo(bitValues2, 16);

            //b = new BitArray(new byte[] { bytes[4] });
            //b.CopyTo(b8, 0);
            ////Array.Reverse(b4);
            //b8.CopyTo(bitValues2, 24);

            return new uint[] { result1, result2 };
        }
    }
}
