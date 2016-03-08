using Map2CivilizationCtrl.Enumerations;
using System.Data;
using System.Globalization;


namespace Map2CivilizationCtrl.ModelFileStorage
{
    internal static class ModelDataSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static DataSet GetModelEmptyDataSet()
        {
            DataSet dataSet = new DataSet("Map2CivModel");
            dataSet.Locale = CultureInfo.InvariantCulture;

            /******************* Singleton Model Variables *******************/
            dataSet.Tables.Add("Global");
            dataSet.Tables["Global"].Columns.Add("AppVersion", typeof(string));
            dataSet.Tables["Global"].Columns.Add("SelectedMapSize", typeof(string));
            dataSet.Tables["Global"].Columns.Add("DataSourceImage", typeof(string));
            dataSet.Tables["Global"].Columns.Add("GridType", typeof(GridType.Enumeration));
            dataSet.Tables["Global"].Columns.Add("MapDataSource", typeof(MapDataSource.Enumeration));
            dataSet.Tables["Global"].Columns.Add("CivilizationVersion", typeof(CivilizationVersion.Enumeration));


            /******************* Plot Data *******************/
            dataSet.Tables.Add("Plot");
            //PlotId
            dataSet.Tables["Plot"].Columns.Add("Id", typeof(string));
            //Terrain Type
            dataSet.Tables["Plot"].Columns.Add("Terrain", typeof(TerrainType.Enumeration));
            //Is Locked
            dataSet.Tables["Plot"].Columns.Add("Locked", typeof(bool));
            //---------PlotReliefMap specific field(s)
            // Detected color Hex representation
            dataSet.Tables["Plot"].Columns.Add("Color", typeof(string));


            /******************* Detected Colors Collection *******************/
            dataSet.Tables.Add("Color");
            //Hex code of color
            dataSet.Tables["Color"].Columns.Add("Id", typeof(string));
            // Terrain Type
            dataSet.Tables["Color"].Columns.Add("Terrain", typeof(TerrainType.Enumeration));


            return dataSet;
        }
    }
}
