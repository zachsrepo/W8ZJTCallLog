using System.Runtime.ExceptionServices;

namespace CallLogTesting
{
    public class DataHandleing
    {
        public static string HandleFrequency(decimal? input)
        {
            string inputString = "";
            string newString = "";
            string determinLength = input.ToString();
            if (input < 10)
            {
                if (determinLength.Length == 6)
                {
                    newString = input.ToString() + "00";
                    inputString = newString.Insert(5, ".");
                }
                else if (determinLength.Length == 7)
                {
                    newString = input.ToString() + "0";
                    inputString = newString.Insert(5, ".");
                }
                else if (determinLength.Length == 8)
                {
                    newString = input.ToString() + "";
                    inputString = newString.Insert(5, ".");
                }
                else if(determinLength.Length == 3)
                {
                    inputString = input.ToString() + "00.000";
                }
                else if(determinLength.Length == 4)
                {
                    inputString = input.ToString() + "0.000";
                }
                else
                {
                    inputString = input.ToString() + ".000";
                }
            }
            else if (input >= 10 && input < 100)
            {
                if (determinLength.Length == 7)
                {
                    newString = input.ToString() + "00";
                    inputString = newString.Insert(6, ".");
                }
                else if (determinLength.Length == 8)
                {
                    newString = input.ToString() + "0";
                    inputString = newString.Insert(6, ".");
                }
                else if (determinLength.Length == 9)
                {
                    newString = input.ToString() + "";
                    inputString = newString.Insert(6, ".");
                }
                else if (determinLength.Length == 4)
                {
                    inputString = input.ToString() + "00.000";
                }
                else if(determinLength.Length == 5)
                {
                    inputString = input.ToString() + "0.000";
                }
                else
                {
                    inputString = input.ToString() + ".000";
                }
            }
            else if (input < 10000)
            {
                if (determinLength.Length == 6)
                {
                    newString = input.ToString() + "00";
                    inputString = newString.Insert(1, ".");
                }
                else if (determinLength.Length == 7)
                {
                    newString = input.ToString() + "0";
                    inputString = newString.Insert(1, ".");
                }
                else if (determinLength.Length == 8)
                {
                    newString = input.ToString() + "";
                    inputString = newString.Insert(1, ".");
                }
                else
                {
                    newString = input.ToString() + ".000";
                    inputString = newString.Insert(1, ".");
                }
            }
            else if (input >= 10000 && input < 30000000)
            {
                if (determinLength.Length == 6)
                {
                    newString = input.ToString() + "00";
                    inputString = newString.Insert(2, ".").Insert(6, ".");
                }
                else if (determinLength.Length == 7)
                {
                    newString = input.ToString() + "0";
                    inputString = newString.Insert(2, ".").Insert(6, ".");
                }
                else if(determinLength.Length == 8)
                {
                    newString = input.ToString() + "0";
                    inputString = newString.Insert(2, ".").Insert(6, ".");
                }
                else
                {
                    newString = input.ToString() + ".000";
                    inputString = newString.Insert(2, ".");
                }

            }
            return inputString;
        }
        public static int CalculateBand(string freq)
        {
            double freqencyCalc = 0;
            int band = 0;
            //string first3 = $"{freq[0]}" + "." + $"{freq[2]}";
            if (freq[1] == '.')   
            {
                freqencyCalc = Convert.ToDouble($"{freq[0]}" + "." + $"{freq[2]}");
                if(freqencyCalc == 0)
                {
                    band = 0;
                }
                else if(freqencyCalc >= 1.8 && freqencyCalc <= 2.0)
                {
                    band = 160;
                }
                else if(freqencyCalc >= 3.5 && freqencyCalc <= 4.0)
                {
                    band = 80;
                }
                else if(freqencyCalc >= 7.0 && freqencyCalc <= 7.3)
                {
                    band = 40;
                }
            }
            else if (freq[2] == '.')
            {
                freqencyCalc = Convert.ToDouble($"{freq[0]}" + $"{freq[1]}" + "." + $"{freq[3]}" + $"{freq[4]}" + $"{freq[5]}");
                if(freqencyCalc >= 10.1 && freqencyCalc <= 10.15)
                {
                    band = 30;
                }
                else if(freqencyCalc >= 14.0 && freqencyCalc <= 14.35)
                {
                    band = 20;
                }
                else if(freqencyCalc >= 18.068 && freqencyCalc <= 18.168)
                {
                    band = 17;
                }
                else if(freqencyCalc >= 21 && freqencyCalc <= 21.45)
                {
                    band = 15;
                }
                else if(freqencyCalc >= 24.89 && freqencyCalc <= 24.99)
                {
                    band = 12;
                }
                else if(freqencyCalc >= 28.0 && freqencyCalc <= 29.7)
                {
                    band = 10;
                }
                else if( freqencyCalc >= 50 && freqencyCalc <= 50.4)
                {
                    band = 6;
                }
            }
            return band;
        }
    }
}
