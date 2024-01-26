using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVC
{
    public class Controller
    {
        private NumberModel _model;
        public NumberModel NumberModel
        {
            get { return _model; }
        }

        public Controller(NumberModel model)
        {
            this._model = model;
        }

        public void UpdateNumber(int number)
        {
            _model.Number = number;
        }
    }
}
