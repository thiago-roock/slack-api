using Refit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BuildingBlock.Token.Sts.Refit
{
    public class CustomUrlParameterFormatter : DefaultUrlParameterFormatter
    {
        public override string Format(object parameterValue, ParameterInfo parameterInfo)
        {
            if (parameterValue == null)
                return null;

            if (parameterInfo.Name == "token")
            {
                return parameterInfo.Name;
            }

            return base.Format(parameterValue, parameterInfo);
        }
    }
}
