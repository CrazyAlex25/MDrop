using System;
using System.Collections.Generic;
using System.Text;

namespace MDrop.MagicDrop
{
    static class MagicDropApiEndpoints
    {
        private const string baseUrl = "https://magicdrop.top";

        public const string FreeCase = baseUrl + "/case/free";
        public const string FreeCaseReg = baseUrl + "/ajax.php?do=freecase_reg";
        public const string Login = baseUrl + "/login";
    }
}
