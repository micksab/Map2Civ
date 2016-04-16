/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/


using System;
using System.ComponentModel;

namespace Map2CivilizationCtrl.Enumerations
{
    public abstract class EnrichedEnumWrapper
    {
        public abstract  Type EnumType { get; }

        public void VerifyEnumTypeCompatible(System.Enum value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Invalid null value.");

            if (!value.GetType().Equals(EnumType))
                throw new InvalidEnumArgumentException(string.Concat("Incompatible enum type. Needed type '", EnumType,"' and found ",value.GetType()));
        }


        public string GetEnumValueDescription(System.Enum value)
        {
            VerifyEnumTypeCompatible(value);

            return GetEnumSpecificDescription(value);
        }


        public bool GetEnumValueEnabledStatus(System.Enum value)
        {
            VerifyEnumTypeCompatible(value);

            return GetEnumSpecificEnabledStatus(value);
        }


        public bool GetEnumValueDefaultStatus(System.Enum value)
        {
            VerifyEnumTypeCompatible(value);

            return GetEnumSpecificDefaultStatus(value);
        }


        protected internal abstract string GetEnumSpecificDescription(System.Enum value);

        protected internal abstract bool GetEnumSpecificEnabledStatus(System.Enum value);

        protected internal abstract bool GetEnumSpecificDefaultStatus(System.Enum value);
    }
}