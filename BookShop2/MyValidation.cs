using System;
using static System.Net.Mime.MediaTypeNames;

namespace BookShop2
{
    class MyValidation
    {
        public static bool validLength(string txt, int min, int max)
        {
            bool ok = true;

            if (string.IsNullOrEmpty(txt))
                ok = false;

            else if (txt.Length < min || txt.Length > max)
                ok = false;

            return ok;
        }

        public static bool validChargePerDay(decimal value, decimal min, decimal max)
        {
            bool ok = true;

            if (value < min || value > max)
                ok = false;
            return ok;
        }


        public static bool validNumber(string txt)
        {
            bool ok = true;

            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsNumber(txt[x])))
                {
                    ok = false;
                }
            }
            return ok;
        }



        public static bool validLetter(string txt)  //allows alphabetic characters
        {
            bool ok = true;

            if (txt.Trim().Length == 0)     //Trim() removes all the whitespace from string
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterWhitespace(string txt)  //allows alphabetic characters and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }
        public static bool validLetterNumberWhitespace(string txt)  //allows alphanumeric and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterNumberHyphenApostropheWhitespace(string txt)  //allows alphanumeric, hyphen, apostrophe and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])) && !(txt[x].Equals('-'))
                        && !(txt[x].Equals('\'')))
                        ok = false;
                }
            }
            return ok;
        }



        public static bool validForename(string txt)  //allows alphabetic, dash and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validSurname(string txt)  //allows alphabetic, dash and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-'))
                        && !(txt[x].Equals('\'')))
                        ok = false;
                }
            }
            return ok;
        }

        public static String firstLetterEachWordToUpper(String word)//npt working
        {
            Char[] array = word.ToCharArray();

            if (Char.IsLower(array[0]))
            {
                array[0] = Char.ToUpper(array[0]);
            }
            //go through array and check for spaces. Make any lowercase letters after a space uppercase
            for (int x = 1; x < array.Length; x++)
            {
                if (array[x - 1] == ' '|| array[x - 1] == '\'')
                {
                    if (Char.IsLower(array[x]))
                    {
                        array[x] = Char.ToUpper(array[x]);
                    }
                }
                else
                    array[x] = Char.ToLower(array[x]);
            }
            return new String(array);
        }


        public static String EachLetterToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            for (int x = 0; x < array.Length; x++)
            {
                if (Char.IsLower(array[x]))
                {
                    array[x] = Char.ToUpper(array[x]);
                }
            }

            return new String(array);
        }

        public static bool validEmail(String email)
        {
            bool ok = true;
            if (string.IsNullOrEmpty(email))
                ok = false;

            if (email.Length < 3)
                ok = false;
            if(!email.Contains("@"))
                ok = false;
            return ok;
        }

        public static bool validBool(bool marketing)
        {
            return true;
        }




    }
}

