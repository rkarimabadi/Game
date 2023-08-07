using Game.WordGame.Helpers;
using System.Collections;
using System.Reflection;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

        string description = value.ToString();
        FieldInfo fieldInfo = value.GetType().GetField(description);
        EnumDescriptionAttribute[] attributes =
           (EnumDescriptionAttribute[])
         fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
        {
            description = attributes[0].Description;
        }
        return description;
    }

    public static IList ToList(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }

        ArrayList list = new ArrayList();
        Array enumValues = Enum.GetValues(type);

        foreach (Enum value in enumValues)
        {
            list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
        }

        return list;
    }
}