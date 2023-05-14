using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookShop2
{
    class MyEntity
    {
        private int idNo;
        private string street, town, county, postcode, telNo;

        public MyEntity()
        {
            this.street = ""; this.town = ""; this.county = ""; this.postcode = ""; this.telNo = "";
        }


        public MyEntity(int idNo, string street, string town, string county, string postcode, string telNo)
        {
            this.street = street; this.town = town; this.county = county; this.postcode = postcode; this.telNo = telNo;
        }

        public int IdNo
        {
            get { return idNo; }
            set { idNo = value; }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberHyphenApostropheWhitespace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-40 letters");
            }
        }


        public string Town
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validSurname(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-20 letters");
            }
        }

        public string County
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validSurname(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-20 letters");
            }
        }


        public string Postcode
        {
            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhitespace(value))
                {
                    postcode = MyValidation.EachLetterToUpper(value);
                }
                else
                    throw new MyException("Postcode must be 7-8 letters and alphanumeric only");
            }
        }

        public string TelNo
        {
            get { return telNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
                {
                    telNo = value;
                }
                else
                    throw new MyException("Telephone number must be 11-15 digits only.  No spaces or other characters please");
            }
        }
    }
}