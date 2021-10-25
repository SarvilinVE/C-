using System;

// класс к заданию №5

namespace WF_lesson8
{
    public class Adress
    {
        public string city;
        public string street;
        public string house;
        public Adress(string _city,string _street,string _house)
        {
            city = _city;
            street = _street;
            house = _house;
        }
        public Adress()
        {

        }
    }
    [Serializable]
    public class Students
    {
        public string firstName;
        public string lastName;
        public string university;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public Adress adress;

        public Students()
        {

        }
        public Students(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city, string street, string house)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            adress = new Adress(city, street, house);
        }
        
    }
    
}
