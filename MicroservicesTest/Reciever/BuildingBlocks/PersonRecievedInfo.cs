using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciever
{
    public class PersonRecievedInfo
    {
        private string _name { get;}
        private DateTime _Date { get;}
        private string _profession { get;}
        private ArrayList _infoList { get;}
        private string _pageId { get;}

        public PersonRecievedInfo(ArrayList infoList)
        {
            _infoList = (ArrayList) infoList.Clone();
            _name = (string) infoList[0];
            _Date = (DateTime) infoList[1];
            _profession = (string) infoList[2];
            _pageId = (string)infoList[3];

        }
    }
}
