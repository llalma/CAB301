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
        private int release_date;
        private Genere genere;
        private Classification classifcation;
        private int copies;
        private int times_rented;


        public Movie(string title, string starring, string director, int duration, int release_date, Genere genere, Classification classifcation, int copies)
        {
            this.Title = title.ToUpper();
            this.Starring = starring;
            this.Director = director;
            this.Duration = duration;
            this.Release_date = release_date;
            this.Genere = genere;
            this.Classifcation = classifcation;
            this.Copies = copies;
        }

        public string Title { get => title; set => title = value; }
        public string Starring { get => starring; set => starring = value; }
        public string Director { get => director; set => director = value; }
        public int Duration { get => duration; set => duration = value; }
        public Genere Genere { get => genere; set => genere = value; }
        public Classification Classifcation { get => classifcation; set => classifcation = value; }
        public int Release_date { get => release_date; set => release_date = value; }
        public int Copies { get => copies; set => copies = value; }
        public int Times_rented { get => times_rented; set => times_rented = value; }

        public override string ToString()
        {
            return @"Title : " + title +
                            "\nStarring: " + starring +
                            "\nDirector: " + director +
                            "\nGenere: " + genere +
                            "\nClassification: " + classifcation +
                            "\nDuration: " + duration +
                            "\nRelease Date: " + release_date +
                            "\nCopies Avaliable: " + copies +
                            "\nTimes Rented: " + Times_rented;
        }

        public void Increase_times_rented()
        {
            //Everytime the movie is rented, remove 1 from copies.
            copies--;
            times_rented++;
        }
    }
}
