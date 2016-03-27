using System.Data;
using System.Globalization;
using Map2CivilizationCtrl.Enumerations;


namespace Map2CivilizationCtrl.ModelFileStorage
{
    internal static class ModelDataSet
    {
        public const string GlobalTableName = "Global";
        public const string GlobalTableAppVersionColName = "AppVersion";
        public const string GlobalTableSelectedMapSizeColName = "SelectedMapSize";
        public const string GlobalTableDataSourceImageColName = "DataSourceImage";
        public const string GlobalTableGridTypeColName = "GridType";
        public const string GlobalTableMapDataSourceColName = "MapDataSource";
        public const string GlobalTableCivilizationVersionColName = "CivilizationVersion";

        public const string PlotTableName = "Plot";
        public const string PlotTableIdColName = "Id";
        public const string PlotTableTerrainColName = "Terrain";
        public const string PlotTableLockedColName = "Locked";
        public const string PlotTableColorColName = "Color";

        public const string ColorTableName = "Color";
        public const string ColorTableIdColName = "Id";
        public const string ColorTableTerrainColName = "Terrain";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static DataSet GetModelEmptyDataSet()
        {
            
            DataSet dataSet = new DataSet("Map2CivModel");
            dataSet.Locale = CultureInfo.InvariantCulture;

            /******************* Singleton Model Variables *******************/
            dataSet.Tables.Add(GlobalTableName);
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableAppVersionColName, typeof(string));
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableSelectedMapSizeColName, typeof(string));
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableDataSourceImageColName, typeof(string));
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableGridTypeColName, typeof(GridType.Enumeration));
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableMapDataSourceColName, typeof(MapDataSource.Enumeration));
            dataSet.Tables[GlobalTableName].Columns.Add(GlobalTableCivilizationVersionColName, typeof(CivilizationVersion.Enumeration));


            /******************* Plot Data *******************/
            dataSet.Tables.Add(PlotTableName);
            //PlotId
            dataSet.Tables[PlotTableName].Columns.Add(PlotTableIdColName, typeof(string));
            //Terrain Type
            dataSet.Tables[PlotTableName].Columns.Add(PlotTableTerrainColName, typeof(TerrainType.Enumeration));
            //Is Locked
            dataSet.Tables[PlotTableName].Columns.Add(PlotTableLockedColName, typeof(bool));
            //---------PlotReliefMap specific field(s)
            // Detected color Hex representation
            dataSet.Tables[PlotTableName].Columns.Add(PlotTableColorColName, typeof(string));


            /******************* Detected Colors Collection *******************/
            dataSet.Tables.Add(ColorTableName);
            //Hex code of color
            dataSet.Tables[ColorTableName].Columns.Add(ColorTableIdColName, typeof(string));
            // Terrain Type
            dataSet.Tables[ColorTableName].Columns.Add(ColorTableTerrainColName, typeof(TerrainType.Enumeration));


            return dataSet;
        }
    }
}
