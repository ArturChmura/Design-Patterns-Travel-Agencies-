//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Interfaces;

namespace TravelAgencies.Decorators
{
    class FranceReviewDecorator : IReview
    {
        IReview review;
        public FranceReviewDecorator(IReview review)
        {
            this.review = review;
        }
        public string Text
        {
            get
            {
                string[] words = review.Text.Split(new char[] { ' ' });
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length < 4) words[i] = "la";
                    stringBuilder.Append(words[i] + " ");
                }
                return stringBuilder.ToString();
            }
        }

        public string Author { get { return review.Author; } }
    }



}
