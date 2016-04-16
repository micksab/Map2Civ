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


using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.ComponentModel;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    public abstract class ExporterBase
    {
        public static ExporterBase GetExporter(CivilizationVersionEnumWrapper.CivilizationVersion civilizationVersion)
        {
            switch (civilizationVersion)
            {
                case CivilizationVersionEnumWrapper.CivilizationVersion.Civilization1:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersionEnumWrapper.CivilizationVersion.Civilization2:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersionEnumWrapper.CivilizationVersion.Civilization3:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersionEnumWrapper.CivilizationVersion.Civilization4:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersionEnumWrapper.CivilizationVersion.Civilization5:
                    return new ExporterCivlizationV();

                case CivilizationVersionEnumWrapper.CivilizationVersion.CivilizationBE:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                default:
                    throw new InvalidEnumArgumentException("Invalid or empty parameter value 'civilizationVersion'");
            }
        }

        public abstract void ExportModel(Map2CivilizationModel.DataModel dataModel, string fullFilePath);
    }
}