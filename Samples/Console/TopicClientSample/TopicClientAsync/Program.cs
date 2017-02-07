using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicClientAsync
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    internal class RandomText
    {
        #region Fields

        private Random _random;
        private List<string> _text;

        #endregion

        #region Constructors

        public RandomText()
        {
            _random = new Random();

            _text = new List<string>();

            _text.Add("I had a wonderful experience! The rooms were wonderful and the staff were helpful.");
            _text.Add("I had a terrible time at the hotel. The staff were rude and the food was awful.");
        }

        #endregion

        #region Methods

        public string Next()
        {
            var index = _random.Next(0, 2);
            return _text[index];
        }

        #endregion
    }
}
