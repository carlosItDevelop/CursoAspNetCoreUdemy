
using System;
using System.Linq;
using System.Reflection;

namespace Cooperchip.ITDeveloper.DomainCore.Extensions
{
    public static class GenericEnumExtensionDescription
    {
        public static string ObterDescricao(this Enum _enum)
        {
            Type generEnumType = _enum.GetType();
            MemberInfo[] memberInfo = generEnumType.GetMember(_enum.ToString());
            if ((memberInfo.Length <= 0)) return _enum.ToString();

            var attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel
                .DescriptionAttribute), false);

            return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs
                .ElementAt(0)).Description : _enum.ToString();

        }
    }
}