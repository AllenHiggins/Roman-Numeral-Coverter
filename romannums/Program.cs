using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace romannums
{
    class Program
    {
        public static int Solution(string roman)
        {
            int n = 0;
            roman = roman.ToUpper();
            for(int i = 0; i <= roman.Length-1; i++)
            {
                switch(roman[i])
                {
                    case 'I':
                        //only has X (IX = 9) and V (IV = 4) next to it
                        try{
                            if (roman[i + 1] == 'X') { n += 9; i++; }
                            else if (roman[i + 1] == 'V') { n += 4; i++; }
                            else { n += 1; }
                        }catch(System.IndexOutOfRangeException){
                            n += 1;
                        }
                        break;
                    case 'X':
                        //only has X (XC = 90) and L (XL = 40) next to it
                        try{
                            if (roman[i + 1] == 'C') { n += 90; i++; }
                            else if (roman[i + 1] == 'L') { n += 40; i++; }
                            else { n += 10; }
                        }catch(System.IndexOutOfRangeException){
                            n += 10;
                        }
                        break;
                    case 'C':
                        //only has C (CD = 400) and V (CM = 900) next to it
                        try{
                            if (roman[i + 1] == 'D') { n += 400; i++; }
                            else if (roman[i + 1] == 'M') { n += 900; i++; }
                            else { n += 100; }
                        }catch(System.IndexOutOfRangeException){
                            n += 100;
                        }
                        break;
                    case 'M':
                        //only has M (MD = 1500) next to it
                        try{

                            if (roman[i + 1] == 'D') { n += 1500; i++; }
                            else { n += 1000; }
                        } catch (System.IndexOutOfRangeException){
                            n += 1000;
                        }
                        break;
                    case 'D':n += 500;break;
                    case 'L': n += 50;break;
                    case 'V':n += 5;break;
                    default: return -1;
                }
            }
            return n;
        }
        static void Main(string[] args)
        {
            //1990 is rendered "MCMXC" (1000 = M, 900 = CM, 90 = XC)
            //2008 is rendered "MMVIII" (2000 = MM, 8 = VIII)
            //1666, "MDCLXVI", uses each letter in descending order.

            string roman;
            Console.Write("Enter a Roman Numeral to convert --> ");
            roman = Console.ReadLine();
            if (Solution(roman) == -1)
            {
                Console.WriteLine(roman + " is not a Roman Numeral");
            }
            else
            {
                Console.Write(Solution(roman));
            }
            Console.Read();
        }
    }
}
