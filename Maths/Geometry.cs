namespace RSLib.CSharp.Maths
{
    using static System.Math;

    public static class Geometry
    {
        #region CIRCLE

        /// <summary>
        /// Computes the area of a circle as a double.
        /// </summary>
        /// <param name="r">Radius.</param>
        /// <returns>Circle's area as a double.</returns>
        public static double ComputeCircleAreaToDouble(this double r)
        {
            return PI * r * r;
        }

        /// <summary>
        /// Computes the area of a circle as a float.
        /// </summary>
        /// <param name="r">Radius.</param>
        /// <returns>Circle's area as a float.</returns>
        public static float ComputeCircleAreaToFloat(this float r)
        {
            return (float)(PI * r * r);
        }

        /// <summary>
        /// Computes the circumference of a circle as a double.
        /// </summary>
        /// <param name="r">Radius.</param>
        /// <returns>Circle's circumference as a double.</returns>
        public static double ComputeCircleCircumferenceToDouble(this double r)
        {
            return 2 * PI * r;
        }

        /// <summary>
        /// Computes the circumference of a circle as a float.
        /// </summary>
        /// <param name="r">Radius.</param>
        /// <returns>Circle's circumference as a float.</returns>
        public static float ComputeCircleCircumferenceToFloat(this float r)
        {
            return (float)(2 * PI * r);
        }

        /// <summary>
        /// Computes the distance between points around a circle as a double.
        /// </summary>
        /// <param name="r">Circle's radius.</param>
        /// <param name="n">Number of points.</param>
        /// <returns>Computed distance as a double.</returns>
        public static double ComputePointsDistanceAroundCircleToDouble(double r, double n)
        {
            return 2 * r * Sin(PI / n);
        }

        /// <summary>
        /// Computes the distance between points around a circle as a float.
        /// </summary>
        /// <param name="r">Circle's radius.</param>
        /// <param name="n">Number of points.</param>
        /// <returns>Computed distance as a float.</returns>
        public static float ComputePointsDistanceAroundCircleToFloat(float r, float n)
        {
            return 2 * r * (float)Sin(PI / n);
        }

        /// <summary>
        /// Checks if a point is inside a circle of center (0,0).
        /// </summary>
        /// <param name="px">Point x.</param>
        /// <param name="py">Point y.</param>
        /// <param name="r">Circle's radius.</param>
        /// <param name="strictly">Point can't be right on the circle.</param>
        /// <returns>True if the point is inside.</returns>
        public static bool IsPointInsideCircle(float px, float py, float r, bool strictly = false)
        {
            return IsPointInsideCircle(px, py, r, 0, 0, strictly);
        }

        /// <summary>
        /// Checks if a point is inside a circle.
        /// </summary>
        /// <param name="px">Point x.</param>
        /// <param name="py">Point y.</param>
        /// <param name="r">Circle's radius.</param>
        /// <param name="cx">Circle's center x.</param>
        /// <param name="cy">Circle's center y.</param>
        /// <param name="strictly">Point can't be right on the circle.</param>
        /// <returns>True if the point is inside.</returns>
        public static bool IsPointInsideCircle(float px, float py, float r, float cx, float cy, bool strictly = false)
        {
            float sqrDist = (cx - px) * (cx - px) + (cy - py) * (cy - py);
            return strictly ? sqrDist < r * r : sqrDist <= r * r;
        }

        /// <summary>
        /// Checks if a point is outside of a circle.
        /// </summary>
        /// <param name="px">Point x.</param>
        /// <param name="py">Point y.</param>
        /// <param name="r">Circle's radius.</param>
        /// <param name="strictly">Point can't be right on the circle.</param>
        /// <returns>True if the point is outside.</returns>
        public static bool IsPointOutsideCircle(float px, float py, float r, bool strictly = false)
        {
            return IsPointOutsideCircle(px, py, r, 0, 0, strictly);
        }

        /// <summary>
        /// Checks if a point is outside of a circle.
        /// </summary>
        /// <param name="px">Point x.</param>
        /// <param name="py">Point y.</param>
        /// <param name="r">Circle's radius.</param>
        /// <param name="cx">Circle's center x.</param>
        /// <param name="cy">Circle's center y.</param>
        /// <param name="strictly">Point can't be right on the circle.</param>
        /// <returns>True if the point is outside.</returns>
        public static bool IsPointOutsideCircle(float px, float py, float r, float cx, float cy, bool strictly = false)
        {
            return !IsPointInsideCircle(px, py, r, cx, cy, strictly);
        }

        /// <summary>
        /// Computes points positions around a circle.
        /// </summary>
        /// <param name="pointsCount">Points count to compute, that must be 3 or higher.</param>
        /// <param name="radius">Circle radius.</param>
        /// <param name="angleOffset">Angle offset applied to circle in degrees.</param>
        /// <returns>Array of points around circle.</returns>
        public static System.Tuple<float, float>[] ComputePointsAroundCircle(int pointsCount, float radius, float angleOffset = 0f)
        {
            if (pointsCount < 3)
            {
                return System.Array.Empty<System.Tuple<float, float>>();
            }

            System.Tuple<float, float>[] points = new System.Tuple<float, float>[pointsCount];
            float angleOffsetRad = angleOffset * 0.017453292f; // Degrees to radians.
            
            for (int i = 0; i < pointsCount; ++i)
            {
                float theta = (System.MathF.PI * 2 * i) / pointsCount + angleOffsetRad;
                float x = System.MathF.Sin(theta) * radius;
                float y = System.MathF.Cos(theta) * radius;
                points[i] = new System.Tuple<float, float>(x, y);
            }

            return points;
        }

        #endregion // CIRCLE

        #region DOT PRODUCT

        /// <summary>
        /// Computes the rounded dot product of two vectors.
        /// </summary>
        /// <param name="ax">First vector x.</param>
        /// <param name="ay">First vector y.</param>
        /// <param name="bx">Second vector x.</param>
        /// <param name="by">Second vector y.</param>
        /// <returns>Rounded dot product.</returns>
        public static float ComputeDotProduct(float ax, float ay, float bx, float by)
        {
            return ax * bx + ay * by;
        }

        #endregion // DOT PRODUCT

        #region GENERAL

        /// <summary>
        /// Returns the closest point on a segment to a reference point using an algorithm explained here: https://diego.assencio.com/?index=ec3d5dfdfc0b6a0d147a656f0af332bd.
        /// </summary>
        /// <param name="ax">Segment first point x.</param>
        /// <param name="ay">Segment first point y.</param>
        /// <param name="bx">Segment second point x.</param>
        /// <param name="by">Segment second point y.</param>
        /// <param name="px">Reference point x.</param>
        /// <param name="py">Reference point y.</param>
        /// <returns>Closest point to point p on the segment.</returns>
        public static System.Tuple<float, float> ComputeClosestPointOnSegment(float ax, float ay, float bx, float by, float px, float py)
        {
            float d = ComputeDotProduct(px - ax, py - ay, bx - ax, by - ay) / ComputeDotProduct(bx - ax, by - ay, bx - ax, by - ay);
            d = d < 0f ? 0f : d > 1f ? 1f : d;
            return System.Tuple.Create(ax + d * (bx - ax), ay + d * (by - ay));
        }

        /// <summary>
        /// Returns the distance from a point to its closest point on a segment.
        /// </summary>
        /// <param name="ax">Segment first point x.</param>
        /// <param name="ay">Segment first point y.</param>
        /// <param name="bx">Segment second point x.</param>
        /// <param name="by">Segment second point y.</param>
        /// <param name="px">Reference point x.</param>
        /// <param name="py">Reference point y.</param>
        /// <returns>Distance from the closest point on the segment to point p.</returns>
        public static float ComputePointDistanceToSegment(float ax, float ay, float bx, float by, float px, float py)
        {
            return System.MathF.Sqrt(ComputePointSqrDistanceToSegment(ax, ay, bx, by, px, py));
        }
        
        /// <summary>
        /// Returns the squared distance from a point to its closest point on a segment.
        /// </summary>
        /// <param name="ax">Segment first point x.</param>
        /// <param name="ay">Segment first point y.</param>
        /// <param name="bx">Segment second point x.</param>
        /// <param name="by">Segment second point y.</param>
        /// <param name="px">Reference point x.</param>
        /// <param name="py">Reference point y.</param>
        /// <returns>Squared distance from the closest point on the segment to point p.</returns>
        public static float ComputePointSqrDistanceToSegment(float ax, float ay, float bx, float by, float px, float py)
        {
            float dx = bx - ax;
            float dy = by - ay;

            if (dx == 0 && dy == 0) // Segment is actually a point.
            {
                dx = px - ax;
                dy = py - ay;
                return dx * dx + dy * dy;
            }

            float t = ((px - ax) * dx + (py - ay) * dy) / (dx * dx + dy * dy);

            if (t < 0f)
            {
                dx = px - ax;
                dy = py - ay;
            }
            else if (t > 1f)
            {
                dx = px - bx;
                dy = py - by;
            }
            else
            {
                dx = px - (ax + t * dx);
                dy = py - (ay + t * dy);
            }

            return dx * dx + dy * dy;
        }
        
        /// <summary>
        /// Computes the intersection point of two segments in 2D space.
        /// </summary>
        /// <param name="a1x">First segment first point x.</param>
        /// <param name="a1y">First segment first point y.</param>
        /// <param name="a2x">First segment second point.</param>
        /// <param name="a2y">First segment second point.</param>
        /// <param name="b1x">Second segment first point x.</param>
        /// <param name="b1y">Second segment first point y.</param>
        /// <param name="b2x">Second segment second point x.</param>
        /// <param name="b2y">Second segment second point y.</param>
        /// <param name="intersection">Intersection point (equal to (-1,-1) if there's no intersection).</param>
        /// <returns>True if there is an intersection, else false.</returns>
        public static bool ComputeSegmentsIntersection(float a1x, float a1y, float a2x, float a2y, float b1x, float b1y, float b2x, float b2y, out System.Tuple<float, float> intersection)
        {
            float d = (a2x - a1x) * (b2y - b1y) - (a2y - a1y) * (b2x - b1x);
            if (d == 0f)
            {
                intersection = new System.Tuple<float, float>(-1f, -1f);
                return false;
            }

            float u = ((b1x - a1x) * (b2y - b1y) - (b1y - a1y) * (b2x - b1x)) / d;
            float v = ((b1x - a1x) * (a2y - a1y) - (b1y - a1y) * (a2x - a1x)) / d;

            if (u < 0f || u > 1f || v < 0f || v > 1f)
            {
                intersection = new System.Tuple<float, float>(-1f, -1f);
                return false;
            }

            intersection = new System.Tuple<float, float>(a1x + u * (a2x - a1x), a1y + u * (a2y - a1y));
            return true;
        }
        
        /// <summary>
        /// Checks if a point is left to an edge, using an algorithm explained here http://geomalgorithms.com/a03-_inclusion.html.
        /// </summary>
        /// <param name="ax">Segment first point x.</param>
        /// <param name="ay">Segment first point y.</param>
        /// <param name="bx">Segment second point x.</param>
        /// <param name="by">Segment second point y.</param>
        /// <param name="px">Point x.</param>
        /// <param name="py">Point y.</param>
        /// <returns>1 if it is left, -1 if not, 0 if it is right on the segment.</returns>
        public static int IsPointLeftToSegment(float ax, float ay, float bx, float by, float px, float py)
        {
            float positionFactor = (by - ay) * (px - ax) - (py - ay) * (bx - ax);
            return positionFactor > 0f ? 1 : positionFactor < 0f ? -1 : 0;
        }
        
        
        /// <summary>
        /// Computes a point winding number according to a given polygon.
        /// </summary>
        /// <param name="polygon">Polygon to check.</param>
        /// <param name="point">Point position to compute the winding number from.</param>
        /// <returns>Winding number (0 means the point is outside).</returns>
        public static int ComputeWindingNumber(System.Tuple<float, float>[] polygon, System.Tuple<float, float> point)
        {
            int windingNumber = 0;

            System.Tuple<float, float>[] polygonCopy = new System.Tuple<float, float>[polygon.Length + 1];
            for (int i = 0; i < polygon.Length; ++i)
                polygonCopy[i] = polygon[i];

            polygonCopy[polygon.Length] = polygon[0];

            for (int i = polygon.Length - 1; i >= 0; --i)
            {
                if (polygonCopy[i].Item1 <= point.Item1)
                {
                    if (polygonCopy[i + 1].Item1 > point.Item1)
                        if (IsPointLeftToSegment(polygonCopy[i].Item1, polygonCopy[i].Item2, polygonCopy[i + 1].Item1, polygonCopy[i + 1].Item2, point.Item1, point.Item2) > 0)
                            windingNumber++;
                }
                else
                {
                    if (polygonCopy[i + 1].Item1 <= point.Item1)
                        if (IsPointLeftToSegment(polygonCopy[i].Item1, polygonCopy[i].Item2, polygonCopy[i + 1].Item1, polygonCopy[i + 1].Item2, point.Item1, point.Item2) < 0)
                            windingNumber--;
                }
            }

            return windingNumber;
        }

        #endregion // GENERAL
    }
}