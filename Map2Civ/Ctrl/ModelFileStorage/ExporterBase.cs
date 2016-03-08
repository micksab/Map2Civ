using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    public abstract class ExporterBase
    {
        public static ExporterBase GetExporter(CivilizationVersion.Enumeration civilizationVersion)
        {
            switch (civilizationVersion)
            {
                case CivilizationVersion.Enumeration.Civilization1:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersion.Enumeration.Civilization2:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersion.Enumeration.Civilization3:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersion.Enumeration.Civilization4:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                case CivilizationVersion.Enumeration.Civilization5:
                    return new ExporterCivlizationV();
                case CivilizationVersion.Enumeration.CivilizationBE:
                    throw new NotImplementedException(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        civilizationVersion.ToString() + Resources.Str_ExporterBase_NotSupportedMessagePart2);
                default:
                    throw new InvalidEnumArgumentException("Invalid or empty parameter value 'civilizationVersion'");
            }
        }


        public abstract void ExportModel(Map2CivilizationModel.DataModel dataModel, String fullFilePath);
    }
}
