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
using System;
using System.ComponentModel;

namespace Map2CivilizationCtrl.Enumerations
{
    public class ProcessedMapControlModeEnumWrapper : EnrichedEnumWrapper
    {
        public enum ProcessedMapControlMode
        {
            Unspecified = 0,
            ColorEditor = 1,
            PlotEditor = 2
        }

        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static ProcessedMapControlModeEnumWrapper _singleInstance;

        /// <summary>
        ///  constructor
        /// </summary>
        private ProcessedMapControlModeEnumWrapper()
        { }

        public static ProcessedMapControlModeEnumWrapper Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new ProcessedMapControlModeEnumWrapper();
                }
                return _singleInstance;
            }
        }


        #endregion Singleton methods


        #region base abstract class implementations

        override public Type EnumType
        {
            get
            {
                return typeof(ProcessedMapControlMode);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal string GetEnumSpecificDescription(System.Enum value)
        {
            switch ((ProcessedMapControlMode)value)
            {
                case ProcessedMapControlMode.ColorEditor:
                    return Resources.Str_ProcessedMapControlMode_Description_ColorEditor;

                case ProcessedMapControlMode.PlotEditor:
                    return Resources.Str_ProcessedMapControlMode_Description_PlotEditors;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal bool GetEnumSpecificEnabledStatus(System.Enum value)
        {
            switch ((ProcessedMapControlMode)value)
            {
                case ProcessedMapControlMode.ColorEditor:
                    return true;

                case ProcessedMapControlMode.PlotEditor:
                    return false;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal bool GetEnumSpecificDefaultStatus(System.Enum value)
        {
            switch ((ProcessedMapControlMode)value)
            {
                case ProcessedMapControlMode.ColorEditor:
                    return true;

                case ProcessedMapControlMode.PlotEditor:
                    return false;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }


        #endregion
    }
}