using System;
using System.Collections.Generic;
using System.Text;
using Enums;

namespace CAB301
{
    public class Movie
    {
        private String title;
        private string starring;
        private string director;
        private int duration;
        private Genere genere;
        private Classification classifcation;


        public Movie(string title, string starring, string director, int duration, Genere genere, Classification classifcation)
        {
            this.Title = title;
            this.Starring = starring;
            this.Director = director;
            this.Duration = duration;
            this.Genere = genere;
            this.Classifcation = classifcation;
        }

        public int get_sum_of_title()
        {
            int sum = 0;
            for(int i = 0; i < title.Length; i++) 
            {
                sum += (int)title[i];
            }
            return sum;
        }

        public string Title { get => title; set => title = value; }
        public string Starring { get => starring; set => starring = value; }
        public string Director { get => director; set => director = value; }
        public int Duration { get => duration; set => duration = value; }
        public Genere Genere { get => genere; set => genere = value; }
        public Classification Classifcation { get => classifcation; set => classifcation = value; }
    }
}
