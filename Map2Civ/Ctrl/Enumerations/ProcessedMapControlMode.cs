﻿using Map2Civilization.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.Enumerations
{
    public class ProcessedMapControlMode : IEnrichedEnumWrapper
    {
        public enum Enumeration
        {
            Unspecified,
            ColorEditor,
            PlotEditor
        }

        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static ProcessedMapControlMode _singleInstance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private ProcessedMapControlMode() { }

        


        public static ProcessedMapControlMode Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new ProcessedMapControlMode();
                }

                return _singleInstance;
            }
        }

        public Type EnumType
        {
            get
            {
                return typeof(Enumeration);
            }
        }

        public String GetEnumValueDescription(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.ColorEditor:
                    return Resources.Str_ProcessedMapControlMode_Description_ColorEditor;
                case Enumeration.PlotEditor:
                    return Resources.Str_ProcessedMapControlMode_Description_PlotEditors;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        public Boolean GetEnumValueEnabledStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.ColorEditor:
                    return true;
                case Enumeration.PlotEditor:
                    return false;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }


        public Boolean GetEnumValueDefaultStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.ColorEditor:
                    return true;
                case Enumeration.PlotEditor:
                    return false;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion
    }
}