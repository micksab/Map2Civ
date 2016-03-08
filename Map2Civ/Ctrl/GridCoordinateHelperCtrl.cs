﻿
using Map2Civilization.Properties;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl
{
    static class GridCoordinateHelperCtrl
    {

        static float _currentZoomFactor = 1f;
        static float _zoomStep = Map2Civilization.Properties.Settings.Default.ZoomStepPercent / 100f;
        static float _zoomMax = Map2Civilization.Properties.Settings.Default.MaxZoomPercent / 100f;
        static float _zoomMin = Map2Civilization.Properties.Settings.Default.MinZoomPercent / 100f;

        public static float GetZoomFactor()
        {
            return _currentZoomFactor;
        }

        public static void SetZoomFactor(float value)
        {
            if (value > _zoomMax)
            {
                _currentZoomFactor = _zoomMax;
            }
            else if (value < _zoomMin)
            {
                _currentZoomFactor = _zoomMin;
            }
            else
            {
                _currentZoomFactor = value;
            }
        }

        public static float GetNextZoomInFactor()
        {
            
            float newZoomFactor = _currentZoomFactor + _zoomStep;
            if (newZoomFactor >= _zoomMax)
            {
                newZoomFactor = _zoomMax;
            }

            return newZoomFactor;
        }

        public static float GetNextZoomOutFactor()
        {
            float newZoomFactor = _currentZoomFactor - _zoomStep;
            if (newZoomFactor <= _zoomMin)
            {
                newZoomFactor = _zoomMin;
            }

            return newZoomFactor;
        }


        /// <summary>
        /// Given the pixel location of a point, this method returns the Plot location of
        /// the corresponding plot
        /// </summary>
        /// <param name="pixelX">The X coordinate of the point</param>
        /// <param name="pixelY">The Y coordinate of the point</param>
        /// <returns>A pair of integers. The first value is the X component of the plot's name
        /// and the second value is the Y component of the plot's name</returns>
        public static PlotId ConvertPixelLocationToPlotId(int pixelX, int pixelY)
        {
            float zoomMultiplier = _currentZoomFactor;
            float plotWidth = (int)ModelCtrl.GetPlotWidthPixels()* zoomMultiplier;
            float plotHeight = (int)ModelCtrl.GetPlotHeightPixels()*zoomMultiplier;
            MapDimension mapSize = ModelCtrl.GetMapSize();
            GridType.Enumeration gridType = ModelCtrl.GetGridType();


            int currentPlotX = 0;
            int currentPlotY = 0;

            switch (gridType)
            {
                case GridType.Enumeration.Square:
                    currentPlotX = (int)(pixelX / plotWidth);
                    int tempPlotY = (int)(pixelY / plotHeight);
                    currentPlotY = Math.Abs(tempPlotY - mapSize.HeightPlots + 1);
                    return new PlotId(currentPlotX, currentPlotY);
                case GridType.Enumeration.HexagonalPT:
                    PlotId shortestDistanceCenterPlotId = new PlotId(0, 0);
                    float minDistance = float.MaxValue;

                    foreach (Plot tempPlot in ModelCtrl.GetDataModel().PlotCollection.getPlots())
                    {
                        float distance = CalculatePointDistanceFromPlotCenter(tempPlot.Id, new PointF((float)pixelX, (float)pixelY), gridType);

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            shortestDistanceCenterPlotId = tempPlot.Id;
                        }
                    }

                    return shortestDistanceCenterPlotId;
                case GridType.Enumeration.Rhombus:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Unknown Grid Type");
            }

        }


     

        public static PointF ConvertPlotIdToPixelLocation(PlotId id, MapDimension mapSize, GridType.Enumeration gridType, Boolean useZoom)
        {
            float zoomMultiplier = 0;
            if (useZoom)
            {
                zoomMultiplier = _currentZoomFactor;
            }
            else
            {
                zoomMultiplier = 1f; 
            }

            
            float plotWidthPixels = GridType.Singleton.GetPlotWidthPixels(gridType) * zoomMultiplier;
            float plotHeightPixels = GridType.Singleton.GetPlotHeightPixels(gridType) * zoomMultiplier;

            switch (gridType)
            {
                case GridType.Enumeration.Square:
                    float currentPlotXPixel = id.X * plotWidthPixels;
                    float currentPlotYPixel = Math.Abs((mapSize.HeightPlots - id.Y - 1) * plotHeightPixels);
                    return new PointF(currentPlotXPixel, currentPlotYPixel);
                case GridType.Enumeration.HexagonalPT:
                    int baseYPlot = Math.Abs(mapSize.HeightPlots - id.Y - 1);
                    //if the base plot is the first one
                    if (id.Y == 0)
                    {
                        return new PointF(id.X * plotWidthPixels, (3f/4f)*baseYPlot*plotHeightPixels);
                    }
                    else
                    {
                        //For info on checking odd/even numbers, check http://cc.davelozinski.com/c-sharp/fastest-way-to-check-if-a-number-is-odd-or-even
                        //If the current y plot is even..
                        if(id.Y % 2 == 0)
                        {
                            return new PointF(id.X * plotWidthPixels, (3f / 4f) * baseYPlot * plotHeightPixels);
                        }
                        //if the current y plot is odd
                        else
                        {
                            return new PointF((id.X * plotWidthPixels) + plotWidthPixels / 2f, (3f / 4f) * baseYPlot * plotHeightPixels);
                        }
                    }
                    
                case GridType.Enumeration.Rhombus:
                    throw new NotImplementedException(Resources.Str_BitmapOperations_RhombusNotSupported);
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        /// <summary>
        /// Method that given a plot's id, returns the location of the plot on the image
        /// *CAUTION* This method should be used only when there is an active fully initialized model.
        /// </summary>
        /// <param name="id">The PlotId of the plot whose location we wish to find</param>
        /// <returns>The point of the upper-left corner of the rectangle that contains the plot's shape</returns>
        public static PointF ConvertPlotIdToPixelLocation(PlotId id, Boolean useZoom)
        {
            return ConvertPlotIdToPixelLocation(id, ModelCtrl.GetMapSize(), ModelCtrl.GetGridType(), useZoom);
        }




        public static Boolean VerifyPlotLocationValidity(PlotId id)
        {
            MapDimension mapSize = ModelCtrl.GetMapSize();


            if ((id.X >= 0) && (id.X <= (mapSize.WidthPlots - 1)) && (id.Y >= 0) && (id.Y <= mapSize.HeightPlots - 1))
            {
                return true;
            }

            return false;
        }


        public static PointF[] GetPlotPolygonPoints(PlotId id, GridType.Enumeration gridType, MapDimension mapDimension)
        {
            List<PointF> toReturn = new List<PointF>();
            PointF UpperLeftCornerPoint = ConvertPlotIdToPixelLocation(id, mapDimension, gridType, false);
            float plotWidth = GridType.Singleton.GetPlotWidthPixels(gridType);
            float plotHeight = GridType.Singleton.GetPlotHeightPixels(gridType);

            switch (gridType)
            {
                case GridType.Enumeration.Square:
                    toReturn.Add(UpperLeftCornerPoint);
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + plotWidth, UpperLeftCornerPoint.Y));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + plotWidth, UpperLeftCornerPoint.Y + plotHeight));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X, UpperLeftCornerPoint.Y + plotHeight));
                    
                    break;
                case GridType.Enumeration.HexagonalPT:
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + (plotWidth / 2), UpperLeftCornerPoint.Y));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + plotWidth, UpperLeftCornerPoint.Y+(plotHeight/4)));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + plotWidth, UpperLeftCornerPoint.Y + (3*plotHeight / 4)));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X + (plotWidth/2), UpperLeftCornerPoint.Y + plotHeight));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X, UpperLeftCornerPoint.Y + (3 * plotHeight / 4)));
                    toReturn.Add(new PointF(UpperLeftCornerPoint.X, UpperLeftCornerPoint.Y + (plotHeight / 4)));
                    break;
                case GridType.Enumeration.Rhombus:
                    throw new NotImplementedException(Resources.Str_BitmapOperations_RhombusNotSupported);
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }

            return toReturn.ToArray();
        }


        /// <summary>
        /// Method that given the id of the plot returns the points of the polygon that 
        /// represents it.
        /// ***CAUTION*** This overload of the method is intented to be used when examining an allready 
        /// initialized model! DO NOT use it when creating a new model.
        /// </summary>
        /// <param name="id">The id of the plot whose polygon points we wish to retreive</param>
        /// <returns></returns>
        public static PointF[] GetPlotPolygonPoints(PlotId id)
        {
            PointF[] toReturn = GetPlotPolygonPoints(id, ModelCtrl.GetGridType(), ModelCtrl.GetMapSize());
            return toReturn;
        }



        private static float CalculatePointDistanceFromPlotCenter(PlotId plotId, PointF point, GridType.Enumeration gridType)
        {
            float zoomMultiplier = _currentZoomFactor;

            PointF plotUpperLeftCorner = ConvertPlotIdToPixelLocation(plotId, true);
            float plotWidthPixels = GridType.Singleton.GetPlotWidthPixels(gridType)* zoomMultiplier;
            float plotHeightPixels = GridType.Singleton.GetPlotHeightPixels(gridType)* zoomMultiplier;

            float distanceX = Math.Abs((plotUpperLeftCorner.X+(plotWidthPixels/2f)) - point.X);
            float distanceY = Math.Abs((plotUpperLeftCorner.Y+(plotHeightPixels/2f)) - point.Y);

            return (float)Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
        }
    }
}