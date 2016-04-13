using Map2Civilization.Properties;
using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Map2CivilizationCtrl
{
    internal static class BitmapOperationsCtrl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap InitializeDataSourceImage(SourceReliefMapSettings settings, MapDimension mapSize,
            GridType.Enumeration gridTypeEnum)
        {
            Size imageSize = GridCoordinateHelperCtrl.CalculateImageSize(mapSize, gridTypeEnum);

            Bitmap resizedBmp = new Bitmap(imageSize.Width, imageSize.Height);

            using (Graphics g = Graphics.FromImage(resizedBmp))
            {
                g.InterpolationMode = settings.InterpolationMode;
                g.CompositingQuality = settings.CompositingQuality;
                g.SmoothingMode = settings.SmoothingMode;

                g.DrawImage(settings.OriginalMapBitmap, new Rectangle(0, 0, imageSize.Width, imageSize.Height));
            }

            resizedBmp.SetResolution(96, 96);

            return resizedBmp;
        }

        public static Bitmap InitializeProcessedMapImage(MapDimension mapDimension, GridType.Enumeration gridTypeEnum)
        {
            Size imageSize = GridCoordinateHelperCtrl.CalculateImageSize(mapDimension, gridTypeEnum);
            Bitmap toReturn = new Bitmap(imageSize.Width, imageSize.Height);
            toReturn.SetResolution(96, 96);

            using (Graphics g = Graphics.FromImage(toReturn))
            {
                g.Clear(Color.Black);
            }

            return toReturn;
        }

        public static Bitmap GenerateAnalysisImage(Bitmap modelBitmap, SourceReliefMapSettings settings)
        {
            switch (modelBitmap.PixelFormat == settings.PixelFormat)
            {
                case false:
                    using (Bitmap intermediateBitmap = SafeCloneStreamBasedBitmap(modelBitmap))
                    {
                        Bitmap toReturn = intermediateBitmap.Clone(new Rectangle(0, 0,
                               modelBitmap.Width, modelBitmap.Height), settings.PixelFormat);

                        return toReturn;
                    }
                    // new Bitmap(modelBitmap);
                   

                    /******** TEST CODE - REMEMBER TO REMOVE ********/
                    //toReturn.Save(System.IO.Path.Combine(savePath, string.Concat(timeStampStr, "Returned", ".bmp")));
                    /************************************************/

                    

                default:
                    /******** TEST CODE - REMEMBER TO REMOVE ********/
                    //modelBitmap.Save(System.IO.Path.Combine(savePath, string.Concat(timeStampStr, "Returned", ".bmp")));
                    /************************************************/
                    return modelBitmap;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap ResizeCanvas(Bitmap bmp, Color backgroundColor, int width, int height)
        {
            Bitmap toReturn = new Bitmap(width, height, bmp.PixelFormat);
            toReturn.SetResolution(96, 96);
            int bmpWidth = bmp.Width;
            int bmpHeight = bmp.Height;
            int origBmpNewCoordinatesX = (width - bmpWidth) / 2;
            int origBmpNewCoordinatesY = (height - bmpHeight) / 2;

            using (SolidBrush brushToUse = new SolidBrush(backgroundColor))
            {
                using (Graphics grp = Graphics.FromImage(toReturn))
                {
                    grp.FillRectangle(
                           brushToUse, 0, 0, width, height);

                    grp.DrawImage(bmp, (float)origBmpNewCoordinatesX, (float)origBmpNewCoordinatesY);
                }
            }

            return toReturn;
        }

        public static Bitmap DrawGridLines(Bitmap bmp)
        {
            using (Pen gridPen = new Pen(Settings.Default.MapGridColorModel, 1))
            {
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    foreach (Plot plot in ModelCtrl.GetDataModel().PlotCollection.GetPlots())
                    {
                        PointF[] points = GridCoordinateHelperCtrl.GetPlotPolygonPoints(plot.Id);
                        graphics.DrawPolygon(gridPen, points);
                    }
                }
            }

            return bmp;
        }

        public static Color CalcDominantColor(Bitmap bmp)
        {
            Dictionary<Color, int> colorList = new Dictionary<Color, int>();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color tempColor = bmp.GetPixel(x, y);

                    if (tempColor != Color.Transparent)
                    {
                        if (colorList.ContainsKey(tempColor))
                        {
                            colorList[tempColor] += 1;
                        }
                        else
                        {
                            colorList.Add(tempColor, 1);
                        }
                    }
                }
            }

            List<KeyValuePair<Color, int>> orderedList = colorList.ToList();

            orderedList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            });

            Color toReturn = orderedList[orderedList.Count - 1].Key;

            bmp.Dispose();
            colorList = null;
            orderedList = null;

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap CreateSolidColorBitmap(string colorHex)
        {
            ColorConverter conv = new ColorConverter();
            Color color = (Color)conv.ConvertFromString(colorHex);

            Bitmap toReturn = new Bitmap(1, 1);
            toReturn.SetResolution(96, 96);

            using (SolidBrush brushToUse = new SolidBrush(color))
            {
                using (Graphics grp = Graphics.FromImage(toReturn))
                {
                    grp.FillRectangle(
                           brushToUse, 0, 0, 1, 1);
                }
            }

            conv = null;

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap FetchRegionOfBitmap(Bitmap sourceBmp, Point upperLeftCorner, int width, int height)
        {
            Bitmap toReturn = new Bitmap(width, height);
            toReturn.SetResolution(96, 96);
            using (Graphics g = Graphics.FromImage(toReturn))
            {
                g.DrawImage(sourceBmp, 0, 0,
                    new Rectangle(upperLeftCorner.X, upperLeftCorner.Y, width, height), GraphicsUnit.Pixel);
            }

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap RebuidProcessedBitmap(List<PlotId> plotIds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Pen UnassignedPen = new Pen(Settings.Default.ProcessedMapUnAssignedPlotGridColor, 1);
            Pen bluePen = new Pen(Color.Blue, 1);

            Bitmap toReturn = ModelCtrl.GetProcessedBitmap();
            Bitmap oceanBmp = TerrainType.Singleton.OceanPlotBitmap;
            Bitmap coastBmp = TerrainType.Singleton.CoastPlotBitmap;
            Bitmap flatBmp = TerrainType.Singleton.FlatPlotBitmap;
            Bitmap hillBmp = TerrainType.Singleton.HillPlotBitmap;
            Bitmap mountainBmp = TerrainType.Singleton.MountainPlotBitmap;
            Bitmap lockBmp = new Bitmap(Resources.LockedTile_Image);

            using (Graphics grp = Graphics.FromImage(toReturn))
            {
                foreach (PlotId tempPlotId in plotIds)
                {
                    SolidBrush brushToUse;

                    if (ModelCtrl.GetDataModel().MapDataSource == MapDataSource.Enumeration.ReliefMapImage)
                    {
                        brushToUse =
                            new SolidBrush(((PlotReliefMap)ModelCtrl.GetDataModel().PlotCollection.GetPlot(tempPlotId)).DominantColor);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    PointF plotPoint = GridCoordinateHelperCtrl.ConvertPlotIdToPixelLocation(tempPlotId, false);
                    float xRefPix = plotPoint.X;
                    float yRefPix = plotPoint.Y;

                    PointF[] points = GridCoordinateHelperCtrl.GetPlotPolygonPoints(tempPlotId).ToArray();

                    grp.FillPolygon(brushToUse, points.ToArray());

                    switch (ModelCtrl.GetDataModel().PlotCollection.GetPlot(tempPlotId).TerrainDescriptor)
                    {
                        case TerrainType.Enumeration.NotDefined:
                            grp.DrawPolygon(UnassignedPen, points);
                            break;

                        case TerrainType.Enumeration.Flat:
                            grp.DrawImage(flatBmp, xRefPix, yRefPix);
                            break;

                        case TerrainType.Enumeration.Hills:
                            grp.DrawImage(hillBmp, xRefPix, yRefPix);
                            break;

                        case TerrainType.Enumeration.Mountains:
                            grp.DrawImage(mountainBmp, xRefPix, yRefPix);
                            break;

                        case TerrainType.Enumeration.Coast:
                            grp.DrawImage(coastBmp, xRefPix, yRefPix);
                            break;

                        case TerrainType.Enumeration.Ocean:
                            grp.DrawImage(oceanBmp, xRefPix, yRefPix);
                            break;

                        default:
                            throw new InvalidEnumArgumentException(
                                "Invalid terrain descriptor value for plot " + tempPlotId);
                    }

                    if (ModelCtrl.GetDataModel().PlotCollection.GetPlot(tempPlotId).IsLocked)
                    {
                        grp.DrawImage(lockBmp,
                            xRefPix + (GridType.Singleton.GetPlotWidthPixels(ModelCtrl.GetGridType()) / 2f) - 3.5f,
                            yRefPix + (GridType.Singleton.GetPlotHeightPixels(ModelCtrl.GetGridType()) / 2f) - 3.5f);
                    }
                }
            }

            UnassignedPen.Dispose();
            bluePen.Dispose();
            lockBmp.Dispose();

            stopWatch.Stop();
            Console.WriteLine("Created processed bitmap in {0} millis", stopWatch.ElapsedMilliseconds);
            return toReturn;
        }

        public static string HexFromColor(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2", System.Threading.Thread.CurrentThread.CurrentCulture) +
                c.G.ToString("X2", System.Threading.Thread.CurrentThread.CurrentCulture) +
                c.B.ToString("X2", System.Threading.Thread.CurrentThread.CurrentCulture);
        }

        public static Color ColorFromHex(string hex)
        {
            ColorConverter conv = new ColorConverter();
            Color toReturn = (Color)conv.ConvertFromString(hex);
            conv = null;

            return toReturn;
        }

        public static string GetBase64stringFromBitmap(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            return Convert.ToBase64String((byte[])converter.ConvertTo(image, typeof(byte[])));
        }

        public static Bitmap GetBitmapFromBase64string(string imagestring)
        {
            Bitmap toReturn;

            byte[] bytes = Convert.FromBase64String(imagestring);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                toReturn = (Bitmap)Image.FromStream(ms);
            }

            bytes = null;

            toReturn.SetResolution(96, 96);

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap CreateHighlightedColorsProcessedBitmap(List<PlotId> plotCoordinatePairs)
        {
            Color highlightedGridColor = Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridColor;
            int gridLineWidthPixels = Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridWidthPixels;
            Size mapSizePixels = GridCoordinateHelperCtrl.CalculateImageSize(ModelCtrl.GetMapSize(), ModelCtrl.GetGridType());
            Bitmap toReturn = new Bitmap(mapSizePixels.Width, mapSizePixels.Height);
            toReturn.SetResolution(96, 96);

            using (Pen gridPen = new Pen(highlightedGridColor, (float)gridLineWidthPixels))
            using (Graphics grp = Graphics.FromImage(toReturn))
            {
                grp.Clear(Color.Transparent);
                foreach (PlotId pair in plotCoordinatePairs)
                {
                    //PointF topCornerCoordinates = GridCoordinateHelperCtrl.ConvertPlotIdToPixelLocation(pair, false);
                    PointF[] gridCoordinates = GridCoordinateHelperCtrl.GetPlotPolygonPoints(pair);

                    grp.DrawPolygon(gridPen, gridCoordinates);
                }
            }

            return toReturn;
        }

        //Base On Source: http://csharphelper.com/blog/2014/09/copy-an-irregular-area-from-one-picture-to-another-in-c/
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap GetPlotArea(Image source, PlotId id, Brush brush, GridType.Enumeration gridType, MapDimension mapDimension)
        {
            Bitmap toReturn = new Bitmap((int)GridType.Singleton.GetPlotWidthPixels(gridType),
                (int)GridType.Singleton.GetPlotHeightPixels(gridType));
            toReturn.SetResolution(96, 96);

            PointF[] points = GridCoordinateHelperCtrl.GetPlotPolygonPoints(id, gridType, mapDimension);

            // Find the bounds of the selected area.
            Rectangle source_rect = GetPointListBounds(points);
            // Make a bitmap that only holds the selected area.

            using (Graphics gr = Graphics.FromImage(toReturn))
            {
                // Set the background color.
                gr.Clear(Color.Transparent);

                // Make a brush out of the original image.

                // Fill the selected area with the brush.
                gr.FillPolygon(brush, points);

                Rectangle dest_rect = new Rectangle(0, 0,
                    source_rect.Width, source_rect.Height);
                gr.DrawImage(source, dest_rect,
                    source_rect, GraphicsUnit.Pixel);
            }
            return toReturn;
        }

        private static Rectangle GetPointListBounds(PointF[] points)
        {
            float xmin = points[0].X;
            float xmax = xmin;
            float ymin = points[0].Y;
            float ymax = ymin;

            for (int i = 1; i < points.Length; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }

            return new Rectangle((int)xmin, (int)ymin, (int)(xmax - xmin), (int)(ymax - ymin));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static Bitmap GetAssignedPlotBitmap(GridType.Enumeration gridType, TerrainType.Enumeration terrainType, float width, float height)
        {
            Bitmap toReturn = new Bitmap((int)Math.Ceiling(width), (int)Math.Ceiling(height));
            float circleRadious = 0;
            float rectOffsetWidth = 0;
            float rectOffsetHeight = 0;

            switch (gridType)
            {
                case GridType.Enumeration.Square:
                    rectOffsetWidth = width * (10f / 100f);
                    rectOffsetHeight = height * (10f / 100f);
                    circleRadious = width * (80f / 100f);
                    break;

                case GridType.Enumeration.HexagonalPT:
                    rectOffsetWidth = width * (15f / 100f);
                    rectOffsetHeight = (2f * rectOffsetWidth) / ((float)Math.Sqrt(3));
                    circleRadious = (width - (2f * rectOffsetWidth));
                    break;

                case GridType.Enumeration.Rhombus:
                    throw new NotImplementedException(Resources.Str_BitmapOperations_RhombusNotSupported);
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }

            Color fillColor;

            switch (terrainType)
            {
                case TerrainType.Enumeration.Ocean:
                    fillColor = Map2Civilization.Properties.Settings.Default.PlotColorOcean;
                    break;

                case TerrainType.Enumeration.Coast:
                    fillColor = Map2Civilization.Properties.Settings.Default.PlotColorCoast;
                    break;

                case TerrainType.Enumeration.Flat:
                    fillColor = Map2Civilization.Properties.Settings.Default.PlotColorFlat;
                    break;

                case TerrainType.Enumeration.Hills:
                    fillColor = Map2Civilization.Properties.Settings.Default.PlotColorHill;
                    break;

                case TerrainType.Enumeration.Mountains:
                    fillColor = Map2Civilization.Properties.Settings.Default.PlotColorMountain;
                    break;

                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }

            using (Graphics g = Graphics.FromImage(toReturn))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                Pen blackPen = new Pen(Color.Black);
                blackPen.Width = 2;
                SolidBrush brushToUse = new SolidBrush(fillColor);
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawEllipse(blackPen, rectOffsetWidth, rectOffsetHeight, circleRadious, circleRadious);
                g.FillEllipse(brushToUse, rectOffsetWidth + 1f, rectOffsetHeight + 1f, circleRadious - 2f, circleRadious - 2f);
            }
            toReturn.SetResolution(96, 96);

            return toReturn;
        }

        public static Bitmap SafeCloneStreamBasedBitmap(Bitmap sourceBitmap)
        {
            Bitmap toReturn = new Bitmap(sourceBitmap.Width,
                sourceBitmap.Height);
            //Due to a GID+ feature according to which if a bitmap is opened from a stream, the stream should be available for
            // the lifetime of the bitmap's instance (and that applies to cloned instances of the original bitmap),
            // we would get a misleading "Out of Memory" exception on any method that would
            // use its graphics, so we create a copy that is independent of the underlying stream
            // used to load the image into the system. For more info check
            //https://social.msdn.microsoft.com/Forums/en-US/4aac43fa-cccb-4bf7-b37e-58ec5351ab80/outofmemoryexception-when-using-graphicsfromimage
            using (Graphics g = Graphics.FromImage(toReturn))
            {
                g.DrawImageUnscaled(sourceBitmap, 0, 0);
            }

            return toReturn;
        }
    }
}