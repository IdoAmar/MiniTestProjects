using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sender
{
    public class PersonSendInfo
    {
        private string _name { get; }
        private DateTime _Date { get; }
        private int _age { get; }
        private string _profession { get; }
        private ArrayList _infoList { get; }

        public PersonSendInfo(string name, DateTime date, int age, string profession)
        {
            _infoList = new ArrayList();
            _name = name;
            _Date = date;
            _age = age;
            _profession = profession;
            _infoList.Add(name);
            _infoList.Add(date);
            _infoList.Add(age);
            _infoList.Add(profession);

        }
        public ArrayList GetPersonList()
        {
            return _infoList;
        }
        
        public ArrayList GetPersonListWithoutAge()
        {
            ArrayList tempList = (ArrayList)_infoList.Clone();
            tempList.Remove(_age);
            return tempList;
        }
    }
}
