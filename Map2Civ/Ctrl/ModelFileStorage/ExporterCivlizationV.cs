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
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System;
using System.IO;
using System.Text;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    internal class ExporterCivlizationV : ExporterBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public override void ExportModel(DataModel dataModel, string fullFilePath)
        {
            using (FileStream fs = File.Open(fullFilePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.ASCII))
            {
                MapDimension mapSize = ModelCtrl.GetMapSize();
                int widthPlots = mapSize.WidthPlots;
                int heightPlots = mapSize.HeightPlots;

                //Byte - map version
                writer.Write(Convert.ToByte(140));
                //int - map width plots
                writer.Write(widthPlots);
                //int - map height plots
                writer.Write(heightPlots);

                Byte[] block1Bytes = Map2Civilization.Properties.Resources.Block1_v5;

                writer.Write(block1Bytes);

                for (int y = 0; y < heightPlots; y++)
                {
                    for (int x = 0; x < widthPlots; x++)
                    {
                        PlotId id = new PlotId(x, y);
                        TerrainTypeEnumWrapper.TerrainType descriptor =
                            Map2CivilizationCtrl.PlotListCtrl.getPlotCombinedTerrainDescriptor(id);
                        switch (descriptor)
                        {
                            case TerrainTypeEnumWrapper.TerrainType.Ocean:
                                writer.Write(Convert.ToByte(6));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                break;

                            case TerrainTypeEnumWrapper.TerrainType.Coast:
                                writer.Write(Convert.ToByte(5));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                break;

                            case TerrainTypeEnumWrapper.TerrainType.Flat:
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(4));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                break;

                            case TerrainTypeEnumWrapper.TerrainType.Hills:
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(1));
                                writer.Write(Convert.ToByte(4));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                break;

                            case TerrainTypeEnumWrapper.TerrainType.Mountains:
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                writer.Write(Convert.ToByte(2));
                                writer.Write(Convert.ToByte(4));
                                writer.Write(Convert.ToByte(255));
                                writer.Write(Convert.ToByte(0));
                                break;

                            default:
                                throw new NotImplementedException();
                        }
                    }
                }

                Byte[] block2Bytes = Map2Civilization.Properties.Resources.Block2_v5;

                writer.Write(block2Bytes);
            }

            string presentableFilename = VariousUtilityMethods.ExtractDisplayableModelFilePath(fullFilePath);
            RegisteredListenersCtrl.CentralFormPublishNewInfoMessage(Resources.Str_ExporterCivilizationV_ExportedMessage +
                presentableFilename);
        }

        #region usefull documentation on the format of CivV map files

        /******************************************************************************************************************/
        /******            Code used to fetch portions of a valid map file - For dev puproses only                       **/
        /******************************************************************************************************************/

        //Byte[] allBytes;
        //allBytes = File.ReadAllBytes(@"C:\Users\Michael\Documents\My Games\Sid Meier's Civilization 5\Maps\HugeMountains.Civ5Map");
        //int startIndex = 9;
        //int length = 1269;
        //Byte[] blockBytes = allBytes.Skip(startIndex).Take(length).ToArray();

        //File.WriteAllBytes(@"C:\Users\Michael\Documents\My Games\Sid Meier's Civilization 5\Maps\Block1_v5.bin", blockBytes);

        //string test = "test";

        /******************************************************************************************************************/
        /******************************************************************************************************************/

        /******************************************************/
        /*   http://forums.civfanatics.com/showthread.php?t=418566
        /*   Very nice resource regarding the format of the map file/
        /*******************************************************/
        //            Civ5Map File Format

        //Map Header

        //byte --Type / version indicator.See Notes below.
        //int --Map Width
        //int --Map Height
        //byte --Possibly number of players for scenario.
        //int-- Unknown; seems to be a world wrap indicator(1 if wrap, 0 if no wrap)
        //int --Length of Terrain type list
        //int --Length of 1st Feature type list
        //int --Length of 2nd Feature type list
        //int --Length of Resource type list
        //int --Unknown
        //int --Length of Map Name string
        //int --Length of Description string
        //string[] --Terrain type list
        //string[] --1st Feature type list
        //string[] --2nd Feature type list
        //string[] --Resource type list
        //string --Map Name string
        //string --Description string
        //int --Length of string3 (only present in version xB or later)
        //string --string3(only present in version xB or later)

        //Map Data
        //Map data is just a list of plots, where a plot is an array of 8 bytes.It starts at plot (0, 0), continues along the x-axis until the row is done, then moves on to (0, 1), etc.So a useful way to read it is to loop the y values from 0 to Height-1 and inside that loop the x values from 0 to Width-1; then you can simply read the next 8 bytes to get the info for plot(x, y) and do whatever you need to with it.

        //A plot array looks like this:
        //byte 0-- Terrain type ID(index into list of Terrain types read from header)
        //byte 1-- Resource type ID; 0xFF if none
        //byte 2-- 1st Feature type ID; 0xFF if none
        //byte 3-- River indicator (non - zero if tile borders a river; actual value probably indicates direction)
        //byte 4-- Elevation(0 = Flat, 1 = Hill, 2 = Mountain)
        //byte 5-- Unknown(possibly related to continent art style)
        //byte 6-- 2nd Feature type ID; 0xFF if none
        //byte 7-- Unknown

        //Scenario Header and Data
        //If there is any scenario data present, it will appear after the map. I haven't really needed to use this part of the file, so info here is more sparse.

        //84 unknown bytes
        //int --Length of Improvement type list
        //int --Length of Unit type list
        //int --Length of Tech type list
        //int --Length of Policy type list
        //int --Length of Building type list
        //int --Length of Promotion type list
        //20 unknown bytes
        //string[] --Improvement type list
        //string[] --Unit type list
        //string[] --Tech type list
        //string[] --Policy type list
        //string[] --Building type list
        //string[] --Promotion type list

        //That's about where I lose track of things. The next section seems to relate to player data but from here on I just didn't have the time or interest to try and work out what everything is in this part of the file.

        //Notes:
        //            The first byte (which I call a type / version indicator) seems to have a high nybble of 0 if the map is just a bare terrain map and a high nybble of 8 if the map also contains scenario information-- i.e.cities, units, etc.The low nybble was xA for older maps (prior to the December patch) and is xB for maps exported from the current game(patch 1.0.1.221).
        //           All integers are 4 - byte little Endian; I generally treat them all as signed.
        //             All strings are null - terminated.
        //             The "type lists" are blocks of known size which contain several null - terminated strings.For example, if I use a period to represent the null byte, the Terrain type list might look like this:
        //Code:
        //            TERRAIN_GRASS.TERRAIN_PLAINS.TERRAIN_DESERT.TERRAIN_TUNDRA.TERRAIN_SNOW.TERRAIN_COAST.TERRAIN_OCEAN.
        //            These blocks can be read en masse and then split on the nulls into an array of type names.
        //            The int/ string combination for string3 was apparently added for version xB maps as it is not present in any version xA maps that I've looked at.
        //             Plots only seem to have 1 of the 2 feature types present.For exported maps, if a plot has a "normal" feature(forest, jungle, flood plain) it'll be the first feature; if instead it has a Natural Wonder feature, it'll be the second feature.

        #endregion usefull documentation on the format of CivV map files
    }
}