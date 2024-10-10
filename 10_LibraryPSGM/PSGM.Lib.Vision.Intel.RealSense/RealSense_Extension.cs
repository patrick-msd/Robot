using Intel.RealSense;

namespace PSGM.Vision.Intel.RealSense
{
    /// <summary>
    /// Converts between 2D and 3D RealSense coordinates.
    /// </summary>
    public static class CoordinateMapper
    {
        /// <summary>
        /// Maps the specified 3D point to the 2D space.
        /// </summary>
        /// <param name="intrinsics">The camera intrinsics to use.</param>
        /// <param name="point">The 3D point to map.</param>
        /// <returns>The corresponding 2D point.</returns>
        public static Vector2D Map3DTo2D(this Intrinsics intrinsics, Vector3D point)
        {
            Vector2D pixel = new Vector2D();
            float x = point.X / point.Z;

            float y = point.Y / point.Z;
            if (intrinsics.model == Distortion.ModifiedBrownConrady)
            {
                float r2 = x * x + y * y;
                float f = 1f + intrinsics.coeffs[0] * r2 + intrinsics.coeffs[1] * r2 * r2 + intrinsics.coeffs[4] * r2 * r2 * r2;
                x *= f;
                y *= f;
                float dx = x + 2f * intrinsics.coeffs[2] * x * y + intrinsics.coeffs[3] * (r2 + 2 * x * x);
                float dy = y + 2f * intrinsics.coeffs[3] * x * y + intrinsics.coeffs[2] * (r2 + 2 * y * y);
                x = dx;
                y = dy;
            }

            if (intrinsics.model == Distortion.Ftheta)
            {
                float r = (float)System.Math.Sqrt(x * x + y * y);
                float rd = (1f / intrinsics.coeffs[0] * (float)System.Math.Atan(2f * r * (float)System.Math.Tan(intrinsics.coeffs[0] / 2f)));
                x *= rd / r;
                y *= rd / r;
            }

            pixel.X = x * intrinsics.fx + intrinsics.ppx;
            pixel.Y = y * intrinsics.fy + intrinsics.ppy;

            return pixel;
        }

        /// <summary>
        /// Maps the specified 2D point to the 3D space.
        /// </summary>
        /// <param name="intrinsics">The camera intrinsics to use.</param>
        /// <param name="pixel">The 2D point to map.</param>
        /// <param name="depth">The depth of the 2D point to map.</param>
        /// <returns>The corresponding 3D point.</returns>
        public static Vector3D Map2DTo3D(this Intrinsics intrinsics, Vector2D pixel, float depth)
        {
            Vector3D point = new Vector3D();
            float x = (pixel.X - intrinsics.ppx) / intrinsics.fx;
            float y = (pixel.Y - intrinsics.ppy) / intrinsics.fy;

            if (intrinsics.model == Distortion.InverseBrownConrady)
            {
                float r2 = x * x + y * y;
                float f = 1 + intrinsics.coeffs[0] * r2 + intrinsics.coeffs[1] * r2 * r2 + intrinsics.coeffs[4] * r2 * r2 * r2;
                float ux = x * f + 2 * intrinsics.coeffs[2] * x * y + intrinsics.coeffs[3] * (r2 + 2 * x * x);
                float uy = y * f + 2 * intrinsics.coeffs[3] * x * y + intrinsics.coeffs[2] * (r2 + 2 * y * y);
                x = ux;
                y = uy;
            }

            point.X = depth * x;
            point.Y = depth * y;
            point.Z = depth;

            return point;
        }
    }

    /// <summary>
    /// Represensts a 2D vector/point.
    /// </summary>
    public struct Vector2D
    {
        public float X;
        public float Y;
    }

    /// <summary>
    /// Represensts a 3D vector/point.
    /// </summary>
    public struct Vector3D
    {
        public float X;
        public float Y;
        public float Z;
    }
}
