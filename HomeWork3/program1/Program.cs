using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class student
    {
        private String studentNum;
        private String classNum;
        private String studentName;
        private String studentSex;
        private int studentAge = 0;

        static void Main(string[] args)
        {
            student newstudent = new student();
            newstudent.studentNum = getStudentNum();
            newstudent.classNum = getClassNum();
            newstudent.studentName = getStudentName();
            newstudent.studentSex = getStudentSex();
            newstudent.studentAge = getStudentAge();

            Console.WriteLine("修改年纪为：");
            int age = Convert.ToInt32(Console.ReadLine());
            newstudent.studentAge = setStudentAge(age);

            Console.WriteLine("学号：" + newstudent.studentNum + "  班级号：" + newstudent.classNum + "  姓名：" + newstudent.studentName + "  性别：" + newstudent.studentSex + "  年纪：" + newstudent.studentAge);
        }

        static String getStudentNum()
        {
            Console.WriteLine("请输入学号：");
            String studentNum = Console.ReadLine();
            return studentNum;
        }

        static String getClassNum()
        {
            Console.WriteLine("请输入班级号：");
            String classNum = Console.ReadLine();
            return classNum;
        }

        static String getStudentName()
        {
            Console.WriteLine("请输入学生姓名：");
            String studentName = Console.ReadLine();
            return studentName;
        }

        static String getStudentSex()
        {
            Console.WriteLine("请输入性别：");
            String studentSex = Console.ReadLine();
            return studentSex;
        }

        static int getStudentAge()
        {
            Console.WriteLine("请输入学生年纪：");
            int age = Convert.ToInt32(Console.ReadLine());
            return age;
        }

        static int setStudentAge(int a)
        {
            return a;
        }
    }
}

