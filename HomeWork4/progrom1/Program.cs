using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrom1
{
    public delegate void AlarmClock(object sender);
    public class setClock
    {
        public string setHour;
        public string setMinute;
        public string setSecond;
    }

    public class onClock
    {
        public event AlarmClock Clock;
        public string hour;
        public string minute;
        public string second;

        public void show(string a,string b,string c)
        {
            setClock mySet = new setClock();
            mySet.setHour = a;
            mySet.setMinute = b;
            mySet.setSecond = c;
            while(true)
            {
                string dateNowHour = DateTime.Now.Hour.ToString();
                string dateNowMinute = DateTime.Now.Minute.ToString();
                string dateNowSecord = DateTime.Now.Second.ToString();

                if ((dateNowHour.Equals(a) && dateNowMinute.Equals(b))&&dateNowSecord.Equals(c))
                {
                    break;
                }
            }
            Clock(this);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            onClock myClock = new onClock();
            Console.WriteLine("请输入闹钟时间：");
            try
            {
                Console.WriteLine("几点：");
                myClock.hour = Console.ReadLine();
                Console.WriteLine("几分：");
                myClock.minute = Console.ReadLine(); ;
                Console.WriteLine("几秒：");
                myClock.second = Console.ReadLine(); ;
            }
            catch { }
            myClock.Clock += new AlarmClock(clockShow);
            myClock.show(myClock.hour, myClock.minute, myClock.second);
        }

        static void clockShow(object sender)
        {
            Console.WriteLine("闹钟时间到！");
        }
    }
}



