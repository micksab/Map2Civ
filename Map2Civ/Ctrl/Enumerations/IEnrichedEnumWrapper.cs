using System;

namespace Map2CivilizationCtrl.Enumerations
{
    public interface IEnrichedEnumWrapper
    {
        Type EnumType { get; }

        string GetEnumValueDescription(System.Enum value);
        Boolean GetEnumValueEnabledStatus(System.Enum value);
        Boolean GetEnumValueDefaultStatus(System.Enum value);


    }
}
