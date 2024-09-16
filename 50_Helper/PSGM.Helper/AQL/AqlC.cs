namespace PSGM.Helper
{
    public partial class AQL
    {
        /// <summary>
        /// AQL Table based on ANSI/ASQ Standard Zq. – 2008
        /// </summary>
        /// <param name="lotSize"></param>
        /// <param name="aqlInspectionLevel"></param>
        /// <returns></returns>
        public SampleSizeLetter GetSampleSizeLetter(int lotSize, AqlInspectionLevel aqlInspectionLevel)
        {
            //  AQL Table 1 based on ANSI/ASQ Standard Zq. – 2008
            //                                                           I                   II                 III                  S1                  S2                  S3                 S4
            SampleSizeLetter[,] tmp = new SampleSizeLetter[,] { { SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.B, SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.A },
                                                                { SampleSizeLetter.A, SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.A },
                                                                { SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.A, SampleSizeLetter.A, SampleSizeLetter.B, SampleSizeLetter.B },

                                                                { SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.E, SampleSizeLetter.A, SampleSizeLetter.B, SampleSizeLetter.A, SampleSizeLetter.C },
                                                                { SampleSizeLetter.C, SampleSizeLetter.E, SampleSizeLetter.F, SampleSizeLetter.B, SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.C },
                                                                { SampleSizeLetter.D, SampleSizeLetter.F, SampleSizeLetter.G, SampleSizeLetter.B, SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.D },

                                                                { SampleSizeLetter.E, SampleSizeLetter.G, SampleSizeLetter.H, SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.E },
                                                                { SampleSizeLetter.F, SampleSizeLetter.H, SampleSizeLetter.J, SampleSizeLetter.B, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.E },
                                                                { SampleSizeLetter.G, SampleSizeLetter.J, SampleSizeLetter.K, SampleSizeLetter.C, SampleSizeLetter.C, SampleSizeLetter.E, SampleSizeLetter.F },

                                                                { SampleSizeLetter.H, SampleSizeLetter.K, SampleSizeLetter.L, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.E, SampleSizeLetter.G },
                                                                { SampleSizeLetter.J, SampleSizeLetter.L, SampleSizeLetter.M, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.F, SampleSizeLetter.G },
                                                                { SampleSizeLetter.K, SampleSizeLetter.M, SampleSizeLetter.N, SampleSizeLetter.C, SampleSizeLetter.D, SampleSizeLetter.F, SampleSizeLetter.H },

                                                                { SampleSizeLetter.L, SampleSizeLetter.N, SampleSizeLetter.P, SampleSizeLetter.D, SampleSizeLetter.E, SampleSizeLetter.G, SampleSizeLetter.J },
                                                                { SampleSizeLetter.M, SampleSizeLetter.P, SampleSizeLetter.Q, SampleSizeLetter.D, SampleSizeLetter.E, SampleSizeLetter.G, SampleSizeLetter.J },
                                                                { SampleSizeLetter.N, SampleSizeLetter.Q, SampleSizeLetter.R, SampleSizeLetter.D, SampleSizeLetter.E, SampleSizeLetter.H, SampleSizeLetter.K } };

            if (lotSize > 2 && lotSize < 8)
            {
                return tmp[0, (int)aqlInspectionLevel];
            }
            else if (lotSize > 9 && lotSize < 15)
            {
                return tmp[1, (int)aqlInspectionLevel];
            }
            else if (lotSize > 16 && lotSize < 25)
            {
                return tmp[2, (int)aqlInspectionLevel];
            }

            else if (lotSize > 26 && lotSize < 50)
            {
                return tmp[3, (int)aqlInspectionLevel];
            }
            else if (lotSize > 51 && lotSize < 90)
            {
                return tmp[4, (int)aqlInspectionLevel];
            }
            else if (lotSize > 91 && lotSize < 150)
            {
                return tmp[5, (int)aqlInspectionLevel];
            }

            else if (lotSize > 151 && lotSize < 280)
            {
                return tmp[6, (int)aqlInspectionLevel];
            }
            else if (lotSize > 281 && lotSize < 500)
            {
                return tmp[7, (int)aqlInspectionLevel];
            }
            else if (lotSize > 501 && lotSize < 1200)
            {
                return tmp[8, (int)aqlInspectionLevel];
            }

            else if (lotSize > 1201 && lotSize < 3200)
            {
                return tmp[9, (int)aqlInspectionLevel];
            }
            else if (lotSize > 3201 && lotSize < 10000)
            {
                return tmp[10, (int)aqlInspectionLevel];
            }
            else if (lotSize > 10001 && lotSize < 35000)
            {
                return tmp[11, (int)aqlInspectionLevel];
            }

            else if (lotSize > 35001 && lotSize < 150000)
            {
                return tmp[12, (int)aqlInspectionLevel];
            }
            else if (lotSize > 150001 && lotSize < 500000)
            {
                return tmp[13, (int)aqlInspectionLevel];
            }
            else if (lotSize > 500001)
            {
                return tmp[14, (int)aqlInspectionLevel];
            }

            else
            {
                return SampleSizeLetter.None;
            }
        }

        public int GetSampleSize(SampleSizeLetter sampleSizeLetter)
        {
            //  AQL Table 2 based on ANSI/ASQ Standard Zq. – 2008
            int[] sampleSize = new int[] { 2, 3, 5, 8, 13, 20, 32, 50, 0, 80, 125, 200, 315, 500, 0, 800, 1250, 2000, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (sampleSizeLetter == SampleSizeLetter.None)
            {
                return 0;
            }
            else
            {
                return sampleSize[(int)sampleSizeLetter];
            }
        }

        public int GetAcceptableFailNumber(SampleSizeLetter sampleSizeLetter, AcceptableQualityLevel acceptableQualityLevel)
        {
            int[,] acceptableFailNumber = new int[,] { { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  1 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  1,  1 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  1,  1,  2 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  1,  1,  2,  3 },
                                                       { 0, 0, 0,  0,  0,  0,  1,  1,  2,  3,  5 },
                                                       { 0, 0, 0,  0,  0,  1,  1,  2,  3,  5,  7 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  1,  1,  2,  3,  5,  7, 10 },
                                                       { 0, 0, 0,  1,  1,  2,  3,  5,  7, 10, 14 },
                                                       { 0, 0, 1,  1,  2,  3,  5,  7, 10, 14, 21 },
                                                       { 0, 1, 1,  2,  3,  5,  7, 10, 14, 21, 21 },
                                                       { 1, 1, 2,  3,  5,  7, 10, 14, 21, 21, 21 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 1, 2, 3,  5,  7, 10, 14, 21, 21, 21, 21 },
                                                       { 2, 3, 5,  7, 10, 14, 21, 21, 21, 21, 21 },
                                                       { 3, 5, 7, 10, 14, 21, 21, 21, 21, 21, 21 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 },
                                                       { 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0 }, };

            if (sampleSizeLetter == SampleSizeLetter.None)
            {
                return 0;
            }
            else
            {
                return acceptableFailNumber[(int)acceptableQualityLevel, (int)sampleSizeLetter];
            }
        }
    }
}
