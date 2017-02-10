using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Helpers
{
    public class RandomText
    {
        #region Fields

        private Random _random;
        private List<string> _source;

        #endregion Fields

        #region Constructors

        public RandomText(List<string> source)
        {
            _random = new Random();
            _source = source;
        }

        #endregion Constructors

        #region Methods

        public string Next()
        {
            if (_source == null || _source.Count == 0)
            {
                return "";
            }

            var index = _random.Next(0, _source.Count);
            return _source[index];
        }

        #endregion Methods
    }
}
