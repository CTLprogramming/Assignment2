using BookShop2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BookShop2
{
    class MyCustomer : MyEntity
    {
        private string title, surname, forename, email;
        private bool marketing;

        public MyCustomer() : base()    // Ask, Inherits cfrom MyEntity?
        {
            this.title = ""; this.surname = ""; this.forename = ""; this.email = ""; this.marketing = false;
        }
        public MyCustomer(int idNo, string title, string surname, string forename,
            string street, string town, string county, string postcode, string telNo, string email, bool marketing)
            : base(idNo, street, town, county, postcode, telNo)
        {
            this.title = title; this.surname = surname; this.forename = forename; this.email = email;  this.marketing = marketing;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.ToUpper() != "MR" && value.ToUpper() != "MRS" && value.ToUpper() != "MISS" && value.ToUpper() != "MS" && value.ToUpper() != "OTHER")
                    throw new MyException("Title must be Mr, Mrs, Miss, Ms, or Other");
                else
                    title = MyValidation.firstLetterEachWordToUpper(value);
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validSurname(value))
                {
                    surname = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Surname must be 2-15 letters");
            }
        }

        public string Forename
        {
            get { return forename; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validForename(value))
                {
                    forename = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Forename must be 2-15 letters");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (MyValidation.validEmail(value))
                {
                    email = value;
                }
                else
                    throw new MyException("Invalid email address");
            }
        }

        public bool Marketing
        {
            get { return marketing; }
            set
            {
                if (MyValidation.validBool(value))
                {
                    marketing = value;
                }
                else
                    throw new MyException("Must be No or Yes");
            }
        }


    }
}
