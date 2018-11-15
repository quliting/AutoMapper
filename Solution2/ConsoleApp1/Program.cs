﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                Age = 10,
                Name = "123"
            };

            Teacher teacher = student.MapTo<Teacher>();

            Console.WriteLine(teacher.Name);
            Console.WriteLine(teacher.Age);
            Console.ReadLine();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static class Extension
    { 
        /// <summary>
        /// 集合对集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }
            Mapper.Initialize(item => item.CreateMap(self.GetType(), typeof(TResult)));
            return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
        }
        /// <summary>
        /// 对象对对象
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.Initialize(item => item.CreateMap(self.GetType(), typeof(TResult)));
            return (TResult)Mapper.Instance.Map(self, self.GetType(), typeof(TResult));
        }
    }
}
