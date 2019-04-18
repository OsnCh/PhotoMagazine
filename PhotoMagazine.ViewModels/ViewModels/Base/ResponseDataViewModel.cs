using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.ViewModels.Base
{
    public class ResponseDataViewModel
    {
        public ResponseDataViewModel()
        {

        }

        public ResponseDataViewModel(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
