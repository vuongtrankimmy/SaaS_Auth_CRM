using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Data.Html
{
    public static class HtmlPathFactory
    {
        private static HtmlConfig configV1 = new HtmlConfig { Channel = HtmlChannel.Mobile, Version = "v1" };
        #region Auth
        public static string SigninPageV1 = HtmlPath.Get(configV1, HtmlModule.Auth, "Signin");
        #endregion
    }
}
