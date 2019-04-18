using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.ViewModels.Base
{
    public class ResponseViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }

        public object Data { get; set; }
    }
}
