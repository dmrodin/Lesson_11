using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_2
{
    class Passport
    {
        private int serial;
        private int number;
        private string issued;
        private DateTime issuedDate;

        public bool IsActive { get; set; }
        public int Serial 
        {   get
            {
                return serial;
            } 
            set
            {
                if (value < 1000 || value > 9999) throw new Exception("Серия паспорта должна состоять из четырех цифр");
                else serial = value;
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 100000 || value > 999999) throw new Exception("Номер паспорта должен состоять из 6 цифр");
                else number = value;
            }
        }
        public string Issued
        {
            get { return issued; }
            set
            {
                if (value == string.Empty) throw new Exception("Поле должно быть заполнено");
                else issued = value;
            }
        }
        public DateTime IssuedDate
        {
            get { return issuedDate; }
            set
            {
                if (value < new DateTime(1991, 12, 25) || value > DateTime.Now) throw new Exception("Не правильная дата");
                else issuedDate = value;
            }
        }

        public Passport(int serial, int number, string issued, DateTime issuedDate, bool isActive = false)
        {
            Serial = serial;
            Number = number;
            Issued = issued;
            IssuedDate = issuedDate;
            IsActive = isActive;
        }

        public Passport()
        {
            IsActive = false;
        }

        public override string ToString()
        {
            return $"{Serial} {Number} {Issued} дата выдачи: {IssuedDate.ToShortDateString()}, паспорт {(IsActive ? "действует" : "не действует")}";
        }
    }
}
