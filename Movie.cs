using System;
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
            title = this.title;
            starring = this.starring;
            director = this.director;
            duration = this.duration;
            genere = this.genere;
            classifcation = this.classifcation;
        }

        pubilc Show_data()
        {
            Console.Out.WriteLine(title);
        }

    }
}
