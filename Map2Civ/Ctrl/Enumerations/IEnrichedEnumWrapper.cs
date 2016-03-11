using System;

namespace Map2CivilizationCtrl.Enumerations
{
    public interface IEnrichedEnumWrapper
    {
        Type EnumType { get; }

        String GetEnumValueDescription(System.Enum value);
        Boolean GetEnumValueEnabledStatus(System.Enum value);
        Boolean GetEnumValueDefaultStatus(System.Enum value);


    }
}
